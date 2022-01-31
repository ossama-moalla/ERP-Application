import React, { Component } from 'react';
import axios from 'axios'
import $ from 'jquery'
import { ExtractErrorMessage } from '../../../GeneralMethods.js';

class ExchangeOPRAddEdit extends Component {
    constructor(props){
        super(props);
        var selectedMoneyAccount=props.selectedMoneyAccountID?props.selectedMoneyAccountID:props.moneyAccountList[0].id;
        const date=new Date();
        if(props.currencyList.length>1){
            if(props.ExchangeOPR){
                const exchangeopr=props.ExchangeOPR;
                this.state={
                    Id:exchangeopr.Id,
                    Date:exchangeopr.Date,
                    MoneyAccountId :exchangeopr.MoneyAccountId,
                    SourceCurrency :exchangeopr.SourceCurrency,
                    SourceExchangeRate  :exchangeopr.SourceExchangeRate ,
                    OutValue :exchangeopr.OutValue,
                    TargetCurrency :exchangeopr.TargetCurrency,
                    TargetExchangeRate  :exchangeopr.TargetExchangeRate ,
                    Notes :exchangeopr.Notes,
                }
            }
            else{
                this.state={
                    Id:undefined,
                    Date:new Date(props.dateAccount.year,props.dateAccount.month-1,props.dateAccount.day
                       ,date.getHours(),date.getMinutes() ),
                    MoneyAccountId :selectedMoneyAccount,
                    SourceCurrency :props.currencyList[0],
                    SourceExchangeRate :props.currencyList[0].exchangeRate,
                    OutValue :0,
                    TargetCurrency :props.currencyList[1],
                    TargetExchangeRate :props.currencyList[1].exchangeRate,
                    Notes :'',
                }
            }
        }
        else this.state={}
        
    }
    componentDidMount(){
        

    }
    onChangeInput=async(e)=>{  
        if(e.target.name==="SourceExchangeRate" && isNaN (e.target.value) ) return;
        if(e.target.name==="TargetExchangeRate" && isNaN (e.target.value) ) return;

        if(e.target.name==="OutValue" && isNaN (e.target.value) ) return;
        if(e.target.name==="SourceCurrency" ) {
            const currency=this.props.currencyList.find(c=> c.id===Number(e.target.value));
            this.setState({
                SourceCurrency:currency,
                SourceExchangeRate:currency.exchangeRate
            })
            return;      
        }
        if(e.target.name==="TargetCurrency" ) {
            const currency=this.props.currencyList.find(c=> c.id===Number(e.target.value));
            this.setState({
                TargetCurrency:currency,
                TargetExchangeRate:currency.exchangeRate
            })
            return;      
        }
        this.setState({
            [e.target.name]:e.target.value 
        });
    
    }
    addExchangeOPR=async ()=>{
        document.getElementById('buttonAdd').disabled=true;
        var div=document.getElementById('ExchangeoprAdd_displaymessage');
        var exchangeopr={
            Id:this.state.Id,
            Date:this.state.Date,
            MoneyAccountId :this.state.MoneyAccountId,
            SourceCurrencyId :this.state.SourceCurrency.id,
            SourceExchangeRate :this.state.SourceExchangeRate,
            OutValue :this.state.OutValue,
            TargetCurrencyId :this.state.TargetCurrency.id,
            TargetExchangeRate :this.state.TargetExchangeRate,
            Notes :this.state.Notes
        }
        await axios.post("https://localhost:5001/Accounting/ExchangeOPR/Add",exchangeopr)
        .then(res=>{
            this.props.fetchAccountInfo();
            this.props.fetchReport();
            $(div).css('background-color','green').text('ExchangeOPR Added').fadeIn(500)
            .delay(1500).fadeOut(500);
            this.setState({
                Id:undefined,
                OutValue :0,
                Notes :'',
            })
            }
        )
        .catch(err=>{$(div).css('background-color','red').text(ExtractErrorMessage(err)).fadeIn(500)
            .delay(2000).fadeOut(500)
        })
        document.getElementById('buttonAdd').disabled=false;


    }
    updateExchangeOPR=async()=>{
        document.getElementById('buttonAdd').disabled=true;
        var div=document.getElementById('ExchangeoprAdd_displaymessage');
        var exchangeopr={
            Id:this.state.Id,
            Date:this.state.Date,
            MoneyAccountId :this.state.MoneyAccountId,
            SourceCurrencyId :this.state.SourceCurrency.id,
            SourceExchangeRate :this.state.SourceExchangeRate,
            OutValue :this.state.OutValue,
            TargetCurrencyId :this.state.TargetCurrency.id,
            TargetExchangeRate :this.state.TargetExchangeRate,
            Notes :this.state.Notes
        }
        await axios.post("https://localhost:5001/Accounting/ExchangeOPR/Update",exchangeopr)
        .then(res=>{
            this.props.fetchAccountInfo();
            this.props.fetchReport();
            $(div).css('background-color','green').text('ExchangeOPR Added').fadeIn(500)
            .delay(1500).fadeOut(500,this.props.closePopUpComponent)
            }
        )
        .catch(err=>$(div).css('background-color','red').text(ExtractErrorMessage(err)).fadeIn(500)
            .delay(2000).fadeOut(500))

        document.getElementById('buttonAdd').disabled=false;

    }
    render() {
        if(this.props.currencyList.length<2){
            return (
                <div className='App error'>
                     Currency List must be at least 2<br/><br/>
                    <button className="btn btn-primary" onClick={this.props.closePopUpComponent}>Close</button>
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
            <div id="ExchangeoprAdd " style={{backgroundColor:"palegreen"}}  >
                <div id="ExchangeoprAdd_displaymessage" className="App error-div">
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
                            <div className="div-inlineblock">
                                <label>Source Currency:</label><br/>
                                <select className="color-yellow bordered" style={{padding:7}}
                                value={this.state.SourceCurrency.id}
                                name="SourceCurrency"
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
                            <div className="div-inlineblock" style={{maxWidth:225}}>
                                <label>Source ExchangeRate:</label>
                                <input type="text" id='SourceExchangeRate' name="SourceExchangeRate"
                                required className="form-control" readOnly
                                value={this.state.SourceExchangeRate}
                                onChange={this.onChangeInput}
                                />
                                                    
                            </div>
                        </div>
                        
                        <div  style={{maxWidth:175}}>
                                <label>OutValue:</label>
                                <input id="OutValue" type="text" name="OutValue"
                                required className="form-control" 
                                value={this.state.OutValue}
                                onChange={this.onChangeInput}
                                />
                        </div>
                        <div>    
                            <div className="div-inlineblock">
                                <label>Target Currency:</label><br/>
                                <select className="color-yellow bordered" style={{padding:7}}
                                value={this.state.TargetCurrency.id}
                                name="TargetCurrency"
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
                            <div className="div-inlineblock" style={{maxWidth:225}}>
                                <label>Target ExchangeRate:</label>
                                <input type="text" id='TargetExchangeRate' name="TargetExchangeRate"
                                required className="form-control" readOnly
                                value={this.state.TargetExchangeRate}
                                onChange={this.onChangeInput}
                                />
                                                   
                            </div>
                            
                        </div>
                        <div  style={{maxWidth:225}}>
                                <label>In Value:</label>
                                <input type="text" 
                                 className="form-control" readOnly
                                value={(
                                     this.state.OutValue*
                                     (this.state.TargetExchangeRate/this.state.SourceExchangeRate)).toFixed(2)}
                                />
                                                   
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
                        onClick={this.addExchangeOPR}>
                            Add </button>   :
                            
                        <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} 
                        onClick={this.updateExchangeOPR}>
                            Update </button>   
                        }
                    </div>
                </div> 
            </div>
        );
    }
}

export default ExchangeOPRAddEdit;