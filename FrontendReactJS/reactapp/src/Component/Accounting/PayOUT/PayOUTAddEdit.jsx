import React, { Component } from 'react';
import axios from 'axios'
import $ from 'jquery'
import { ExtractErrorMessage } from '../../../GeneralMethods.js';

class PayOUTAddEdit extends Component {
    constructor(props){
        super(props);
        var selectedMoneyAccount=props.selectedMoneyAccountID?props.selectedMoneyAccountID:props.moneyAccountList[0].id;
        const date=new Date();
        if(props.PayOUT){
            const payout=props.PayOUT;
            this.state={
                Id:payout.Id,
                Date:payout.Date,
                MoneyAccountId :payout.MoneyAccountId,
                Description :payout.Description,
                Currency :payout.Currency,
                Value :payout.Value,
                ExchangeRate :payout.exchangeRate,
                Notes :payout.Notes,
                fetchDone:false
            }
        }
        else{
            this.state={
                Id:undefined,
                Date:new Date(props.dateAccount.year,props.dateAccount.month-1,props.dateAccount.day
                   ,date.getHours(),date.getMinutes() ),
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
    addPayOUT=async ()=>{
        document.getElementById('buttonAdd').disabled=true;
        var div=document.getElementById('PayoutAdd_displaymessage');
        let date=this.state.Date;
        date.setHours(new Date().getHours());
        date.setMinutes(new Date().getMinutes())
        const offset=new Date().getTimezoneOffset();
        var payout={
            Id:this.state.Id,
            Date:new Date(date.getTime()-offset*60*1000) ,
            MoneyAccountId :this.state.MoneyAccountId,
            Description :this.state.Description,
            CurrencyId :this.state.Currency.id,
            Value :this.state.Value,
            ExchangeRate :this.state.ExchangeRate,
            Notes :this.state.Notes
        }
        await axios.post("https://localhost:5001/Accounting/PayOUT/Add",payout)
        .then(res=>{
            this.props.fetchAccountInfo();
            this.props.fetchReport();
            $(div).css('background-color','green').text('PayOUT Added').fadeIn(500)
            .delay(1500).fadeOut(500);
            this.setState({
                Id:undefined,
                Description :'',
                Value :0,
                Notes :'',
            })
            }
        )
        .catch(err=>{$(div).css('background-color','red').text(ExtractErrorMessage(err)).fadeIn(500)
            .delay(2000).fadeOut(500)
        })
        document.getElementById('buttonAdd').disabled=false;


    }
    updatePayOUT=async()=>{
        document.getElementById('buttonAdd').disabled=true;
        var div=document.getElementById('PayoutAdd_displaymessage');
        var payout={
            Id:this.state.Id,
            Date:this.state.Date,
            MoneyAccountId :this.state.MoneyAccountId,
            Description :this.state.Description,
            CurrencyId :this.state.Currency.id,
            Value :this.state.Value,
            ExchangeRate :this.state.ExchangeRate,
            Notes :this.state.Notes
        }
        await axios.post("https://localhost:5001/Accounting/PayOUT/Update",payout)
        .then(res=>{
            this.props.fetchAccountInfo();
            this.props.fetchReport();
            $(div).css('background-color','green').text('PayOUT Added').fadeIn(500)
            .delay(1500).fadeOut(500,this.props.closePopUpComponent)
            }
        )
        .catch(err=>$(div).css('background-color','red').text(ExtractErrorMessage(err)).fadeIn(500)
            .delay(2000).fadeOut(500))

        document.getElementById('buttonAdd').disabled=false;

    }
    render() {
        if(this.props.currencyList.length===0){
            return (
                <div className='App error'>
                    no currencies found
                    <br/><br/>
                    <button className="btn btn-primary" onClick={this.props.closePopUpComponent}>Close</button>
                </div>
            )
        }
        if(this.props.moneyAccountList.length===0){
            return (
                <div className='App error'>
                    no money accounts found
                    <br/><br/>
                    <button className="btn btn-primary" onClick={this.props.closePopUpComponent}>Close</button>
                </div>
            )
        }
        if(this.state.fetchDone===false){
            return(
                <div  className="App">
                    Loading.......
                </div>
            )
        }
        
        
        return (
            <div id="PayoutAdd" className="color-red"  >
                <div id="PayoutAdd_displaymessage" className="App error-div">
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
                        <label>Date:</label>
                        <label>{this.state.Date.getDate()+"/"+(this.state.Date.getMonth()+1)+"/"+
                        this.state.Date.getFullYear()}</label>
                        </div>
                        <div>
                            <label>Description:</label>
                            <input id="Description" type="text" name="Description"
                            required className="form-control" 
                            value={this.state.Description}
                            onChange={this.onChangeInput}
                            />
                            
                        </div>
                        
                        <div>
                            <div className="div-inlineblock" style={{maxWidth:175}}>
                                <label>Value:</label>
                                <input id="Value" type="text" name="Value"
                                required className="form-control" 
                                value={this.state.Value}
                                onChange={this.onChangeInput}
                                />
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
                                                   
                            </div>
                            
                        </div>
                        
                        <div>
                            <label>Notes:</label>
                            <input id="Notes" type="text" name="Notes"
                            required className="form-control" 
                            value={this.state.Notes}
                            onChange={this.onChangeInput}
                            />
                            
                        </div>
                    </div>  
                    <div className="form-group">
                        {
                            this.state.Id===undefined?
                            
                        <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} 
                        onClick={this.addPayOUT}>
                            Add </button>   :
                            
                        <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} 
                        onClick={this.updatePayOUT}>
                            Update </button>   
                        }
                    </div>
                </div> 
            </div>
        );
    }
}

export default PayOUTAddEdit;