import React, { Component } from 'react';
import axios from 'axios';
import $ from 'jquery'
import { ExtractErrorMessage } from '../../../GeneralMethods.js';

class CurrencyAddEdit extends Component {
    constructor(props){
        super(props);
        if(props.Currency){
            this.state={
                Id:props.Currency.id,
                Name:props.Currency.name,
                Symbol:props.Currency.symbol,
                ExchangeRate:props.Currency.exchangeRate,
                Disabled:props.Currency.disabled
           }
        }else{
            this.state={
                Id:undefined,
                Name:'',
                Symbol:'',
                ExchangeRate:1,
                Disabled:false
            }
        }        
    }
    onChangeInput=async(e)=>{
        if(e.target.name==="Disabled"){
            this.setState({
                Disabled:e.target.checked
             });
        }
        else{  
            if(e.target.name==="ExchangeRate" && isNaN (e.target.value) ) return;
            this.setState({[e.target.name]:e.target.value});
        }
    }
    addCurrency=async ()=>{
        document.getElementById('buttonAdd').disabled=true;
        var currrency={
            name:this.state.Name,
            symbol:this.state.Symbol,
            exchangeRate:this.state.ExchangeRate,
            disabled:this.state.Disabled
        }
        await axios.post("https://localhost:5001/Accounting/Currency/Add",currrency)
        .then(res=>{
            $('#AddCurrency_displaymessage').css('background-color','green').text('Currency Added').fadeIn(500)
            .delay(1500).fadeOut(500);
            this.props.fetchCurrencies();
            this.setState({
                 Id:undefined,
                Name:'',
                Symbol:'',
                ExchangeRate:1,
                Disabled:false
 
            })
        })
        .catch(err=>
            $('#AddCurrency_displaymessage').css('background-color','red')
            .text(ExtractErrorMessage(err)).fadeIn(500)
            .delay(1500).fadeOut(500)
        )
        document.getElementById('buttonAdd').disabled=false;
    }
    updateCurrency=async ()=>{
        document.getElementById('buttonAdd').disabled=true;
        var currrency={
            id:this.state.Id,
            name:this.state.Name,
            symbol:this.state.Symbol,
            exchangeRate:this.state.ExchangeRate,
            disabled:this.state.Disabled
        }
        await axios.put("https://localhost:5001/Accounting/Currency/Update",currrency)
        .then(res=>{
            $('#AddCurrency_displaymessage').css('background-color','green').text('Currency Updated').fadeIn(500)
            .delay(1500).fadeOut(500,()=>{
                this.props.fetchCurrencies();
                this.props.closePopUpComponent();
            });
        })
        .catch(err=>
            $('#AddCurrency_displaymessage').css('background-color','red')
            .text(ExtractErrorMessage(err)).fadeIn(500)
            .delay(1500).fadeOut(500)
        )
        document.getElementById('buttonAdd').disabled=false;
    }
    render() {
        return (
            <div id='AddCurrency' >
            <div id="AddCurrency_displaymessage" className="App error-div">
            </div>                                        
                <div >
                    <div className="form-group" >
                        <div>
                            <label>Name:</label>
                            <input id="Name" type="text" name="Name"
                            required className="form-control" 
                            value={this.state.Name}
                            onChange={this.onChangeInput}
                            />
                        </div>
                        <div>
                            <label>Symbol:</label>
                            <input id="Symbol" type="text" name="Symbol"
                            required className="form-control" 
                            value={this.state.Symbol}
                            onChange={this.onChangeInput}
                            />
                            
                        </div>
                        <div>
                            <label>ExchangeRate:</label>
                            <input type="text" name="ExchangeRate"
                            required className="form-control" 
                            value={this.state.ExchangeRate}
                            onChange={this.onChangeInput}
                            />
                            
                       </div>
                        
                        <br/>
                        <input type="checkbox" name="Disabled"
                        required 
                        checked={this.state.Disabled}
                        onChange={this.onChangeInput} />
                        <label>Disabled</label>
                        
                    </div>  
                    <div className="form-group">
                        {
                            this.state.Id===undefined?
                            
                        <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} 
                        onClick={this.addCurrency}>
                            Add </button>   :
                            
                        <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} 
                        onClick={this.updateCurrency}>
                            Update </button>   
                        }
                    </div>
                </div> 
        </div>
        );
    }
}

export default CurrencyAddEdit;