import React, { Component } from 'react';
import axios from 'axios'
import $ from 'jquery'
import { ExtractErrorMessage } from '../../../GeneralMethods.js';

class PayINAddEdit extends Component {
    constructor(props){
        super(props);
        var selectedMoneyAccount=props.selectedMoneyAccountID?props.selectedMoneyAccountID:props.moneyAccountList[0].id;
        if(props.PayIN){
            const payin=props.PayIN;
            this.state={
                Id:payin.Id,
                Date:payin.Date,
                MoneyAccountId :payin.MoneyAccountId,
                Description :payin.Description,
                Currency :payin.Currency,
                Value :payin.Value,
                ExchangeRate :payin.exchangeRate,
                Notes :payin.Notes,
                fetchDone:false
            }
        }
        else{
            this.state={
                Id:undefined,
                Date:undefined,
                MoneyAccountId :selectedMoneyAccount,
                Description :'',
                Currency :props.currencyList[0],
                Value :0,
                ExchangeRate :props.currencyList[0].exchangeRate,
                Notes :'',
                fetchDone:false
            }
        }
    }
    componentDidMount(){
        if(this.props.OperationId &&this.props.OperationType){
            //fetch operation info
        }
        else this.setState({fetchDone:true})

    }
    onChangeInput=async(e)=>{  
        if(e.target.name==="ExchangeRate" && isNaN (e.target.value) ) return;
        if(e.target.name==="Value" && isNaN (e.target.value) ) return;
        if(e.target.name==="Currency" ) {
            const currency=this.props.currencyList.find(c=> c.id===Number(e.target.value));
            this.setState({
                Currency:currency,
                ExchangeRate:currency.exchangeRate
            })
            return;
                
        }
        this.setState({
            [e.target.name]:e.target.value 
        });
    
    }
    addPayIN=async ()=>{
        document.getElementById('buttonAdd').disabled=true;
        var div=document.getElementById('PayinAdd_displaymessage');
        var payin={
            Id:this.state.Id,
            MoneyAccountId :this.state.MoneyAccountId,
            Description :this.state.Description,
            CurrencyId :this.state.Currency.id,
            Value :this.state.Value,
            ExchangeRate :this.state.ExchangeRate,
            Notes :this.state.Notes
        }
        await axios.post("https://localhost:5001/Accounting/PayIN/Add",payin)
        .then(res=>
                $(div).css('background-color','green').text('PayIN Added').fadeIn(500)
                .delay(1500).fadeOut(500,this.props.closePopUpComponent)
            )
        .catch(err=>$(div).css('background-color','red').text(ExtractErrorMessage(err)).fadeIn(500)
            .delay(2000).fadeOut(500))

        document.getElementById('buttonAdd').disabled=false;

    }
    updatePayIN=()=>{
        
    }
    render() {
        if(this.state.fetchDone===false){
            return(
                <div  className="App">
                    Loading.......
                </div>
            )
        }
        if(this.props.currencyList.length===0){
            return (
                <div className='error-div'>
                    no currencies found<br/>
                    <button on onClick={this.props.closePopUpComponent}>Close</button>
                </div>
            )
        }
        if(this.props.moneyAccountList.length===0){
            return (
                <div className='error'>
                    no money accounts found<br/>
                    <button on onClick={this.props.closePopUpComponent}>Close</button>
                </div>
            )
        }
        return (
            <div id="PayinAdd " style={{backgroundColor:"palegreen"}}  >
                <div id="PayinAdd_displaymessage" className="App error-div">
            </div>                                        
                <div >
                    <div  className="form-group" >
                        <div >
                            <label>Monney Account:</label><br/>
                            <select className="color-yellow bordered" 
                                 onChange={this.onChangeInput}
                                 name="MoneyAccountId"
                            >
                                {
                                    this.props.moneyAccountList.map((account,index)=>{
                                        return (
                                            <option key={index} value={account.id}>{account.name}</option>
                                        )
                                    })
                                }
                            </select>
                        </div>
                        <div>
                            <label>Description:</label>
                            <input id="Description" type="text" name="Description"
                            required className="form-control" 
                            value={this.state.Description}
                            onChange={this.onChangeInput}
                            />
                            {this.state.verifyError?.nameError&&          
                            <label className='form-input-err' >{this.state.verifyError.nameError}</label>
                            }
                        </div>
                        
                        <div>
                            <div className="div-inlineblock" style={{maxWidth:175}}>
                                <label>Value:</label>
                                <input id="Value" type="text" name="Value"
                                required className="form-control" 
                                value={this.state.Value}
                                onChange={this.onChangeInput}
                                />
                                {this.state.verifyError?.symbolError&&          
                                <label className='form-input-err' >{this.state.verifyError.symbolError}</label>
                                }
                            </div>
                            <div className="div-inlineblock">
                                <label>Currency:</label><br/>
                                <select className="color-yellow bordered" style={{padding:7}}
                                value={this.state.Currency.id}
                                name="Currency"
                                onChange={this.onChangeInput}>
                                    {
                                        this.props.currencyList.map((currency,index)=>{
                                            return (
                                                <option key={index} value={currency.id}>{currency.name}</option>
                                            )
                                        })
                                    }
                                </select>
                            </div>
                            <div className="div-inlineblock" style={{maxWidth:125}}>
                                <label>ExchangeRate:</label>
                                <input type="text" id='ExchangeRate' name="ExchangeRate"
                                required className="form-control" readOnly
                                value={this.state.ExchangeRate}
                                onChange={this.onChangeInput}
                                />
                                {this.state.verifyError?.exchangeRateError&&          
                                <label className='form-input-err' >{this.state.verifyError.exchangeRateError}</label>
                                }                       
                            </div>
                            
                        </div>
                        
                        <div>
                            <label>Notes:</label>
                            <input id="Notes" type="text" name="Notes"
                            required className="form-control" 
                            value={this.state.Notes}
                            onChange={this.onChangeInput}
                            />
                            {this.state.verifyError?.nameError&&          
                            <label className='form-input-err' >{this.state.verifyError.nameError}</label>
                            }
                        </div>
                    </div>  
                    <div className="form-group">
                        {
                            this.state.Id===undefined?
                            
                        <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} 
                        onClick={this.addPayIN}>
                            Add </button>   :
                            
                        <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} 
                        onClick={this.updatePayIN}>
                            Update </button>   
                        }
                    </div>
                </div> 
            </div>
        );
    }
}

export default PayINAddEdit;