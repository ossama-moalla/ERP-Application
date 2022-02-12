import React, { Component } from 'react';
import axios from 'axios'
import $ from 'jquery'
import { ExtractErrorMessage } from '../../../GeneralMethods.js';

class MoneyTransformOPRAddEdit extends Component {
    constructor(props){
        super(props);
        this.selectedMoneyAccount=props.moneyAccountList.find(x=>x.id===props.selectedMoneyAccountID);
        this.moneyAccountList= props.moneyAccountList.filter(x=>x.id!==this.selectedMoneyAccount.id);

        const date=new Date();
        if(this.moneyAccountList.length>0){
            if(props.MoneyTransformOPR){
                const moneytransformopr=props.MoneyTransformOPR;
                this.state={
                    Id:moneytransformopr.Id,
                    Date:moneytransformopr.Date,
                    TargetMoneyAccountId :moneytransformopr.TargetMoneyAccountId,
                    Currency :moneytransformopr.Currency,
                    ExchangeRate  :moneytransformopr.ExchangeRate ,
                    Value :moneytransformopr.Value,
                    Notes :moneytransformopr.Notes,
                }
            }
            else{
                this.state={
                    Id:undefined,
                    Date:new Date(props.dateAccount.year,props.dateAccount.month-1,props.dateAccount.day
                       ,date.getHours(),date.getMinutes() ),
                    TargetMoneyAccountId :this.moneyAccountList[0].id,
                    Currency :props.currencyList[0],
                    ExchangeRate :props.currencyList[0].exchangeRate,
                    Value :0,
                    Notes :''
                }
            }
        }
        else this.state={}
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
    addMoneyTransformOPR=async ()=>{
        document.getElementById('buttonAdd').disabled=true;
        var div=document.getElementById('MoneyTransformOPRAdd_displaymessage');
        let date=this.state.Date;
        date.setHours(new Date().getHours());
        date.setMinutes(new Date().getMinutes())
        const offset=new Date().getTimezoneOffset();
        var moneytransformopr={
            id: this.state.Id,
            date:new Date(date.getTime()-offset*60*1000) ,
            sourceMoneyAccountId: this.selectedMoneyAccount.id,
            targetMoneyAccountId: this.state.TargetMoneyAccountId,
            currencyId: this.state.Currency.id,
            exchangeRate: this.state.ExchangeRate,
            value: this.state.Value,
            notes: this.state.Notes
        }
        await axios.post("https://localhost:5001/Accounting/MoneyTransformOPR/Add",moneytransformopr)
        .then(res=>{
            this.props.fetchAccountInfo();
            this.props.fetchReport();
            $(div).css('background-color','green').text('MoneyTransformOPR Added').fadeIn(500)
            .delay(1500).fadeOut(500);
            this.setState({
                Id:undefined,
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
    updateMoneyTransformOPR=async()=>{
        document.getElementById('buttonAdd').disabled=true;
        var div=document.getElementById('MoneyTransformOPRAdd_displaymessage');
        var moneytransformopr={
            Id:this.state.Id,
            Date:this.state.Date,
            SourceMoneyAcount:this.selectedMoneyAccount.id,
            TargetMoneyAccountId :this.state.TargetMoneyAccountId,
            CurrencyId :this.state.Currency.Id,
            ExchangeRate  :this.state.ExchangeRate ,
            Value :this.state.Value,
            Notes :this.state.Notes,
        }
        await axios.post("https://localhost:5001/Accounting/MoneyTransformOPR/Update",moneytransformopr)
        .then(res=>{
            this.props.fetchAccountInfo();
            this.props.fetchReport();
            $(div).css('background-color','green').text('MoneyTransformOPR Added').fadeIn(500)
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
                    No Currencies Found<br/><br/>
                    <button className="btn btn-primary" onClick={this.props.closePopUpComponent}>Close</button>
                </div>
            )
        }
        if(this.moneyAccountList.length===0){
            return (
                <div className='App error'>
                     money accounts must be at least 2<br/>
                    <button className="btn btn-primary" onClick={this.props.closePopUpComponent}>Close</button>
                </div>
            )
        }
        return (
            <div id="MoneyTransformOPRAdd" className="color-cadetblue" style={{padding:10}}  >
                <div id="MoneyTransformOPRAdd_displaymessage" className="App error-div">
            </div>                                        
                <div >
                    <div  className="form-group" >
                        <div className="bordered color-blue">
                            <label>Source Money Acount:
                                <span className="color-yellow bordered" >{this.selectedMoneyAccount.name}</span></label><br/>
                            <label>Date:{this.state.Date.getDate()+"/"+(this.state.Date.getMonth()+1)+"/"+
                            this.state.Date.getFullYear()}</label>
                        </div>
                        <div >
                            <label>Target Monney Account:</label><br/>
                            <select className="color-yellow bordered" 
                                 onChange={this.onChangeInput}
                                 name="TargetMoneyAccountId"
                            >
                                {
                                    this.moneyAccountList.map((account,index)=>{
                                        return (
                                            <option key={index} value={account.id}>{account.name}</option>
                                        )
                                    })
                                }
                            </select>
                        </div>
                        
                        <div>
                            <div className="div-inlineblock" style={{maxWidth:150}}>
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
                            <div className="div-inlineblock" style={{maxWidth:150}}>
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
                        onClick={this.addMoneyTransformOPR}>
                            Add </button>   :
                            
                        <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} 
                        onClick={this.updateMoneyTransformOPR}>
                            Update </button>   
                        }
                    </div>
                </div> 
            </div>
        );
    }
}

export default MoneyTransformOPRAddEdit;