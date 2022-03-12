import React, { Component } from "react";
import MoneyAccountReport from './MoneyAccountReport.jsx';
import MoneyAccountInfo from "./MoneyAccountInfo.jsx";

import PopUPComponent from '../../PopUPComponent.jsx';
import axios from 'axios'
import { ExtractErrorMessage } from "../../../GeneralMethods.js";


class MoneyAccountWindow extends Component {
    constructor(){
        super();
        this.state={
            selectedMoneyAccountID:null,
            moneyAccountList:[],
            currencyList:[],
            fetchInitialDataDone:false,
            fetchInitialDataError:null,

            fetchAccountInfoDone:false,
            fetchAccountInfoError:null,
            moneyAccountValue:null,

            popUpComponent:{Show:false,component:null,title:''}
        }
    }
    closePopUpComponent=()=>  this.setState(prevstat=>({
        ...prevstat,
        popUpComponent:{Show:false,component:null,title:''}    
    }));
    showPopUpComponent=(component,title)=> {
        this.setState(prevstat=>({
          ...prevstat,
          popUpComponent:{Show:false,component:null,title:''}
          
        }),()=>this.setState(prevstat=>({
          ...prevstat,
          popUpComponent:{Show:true,component:component,title:title}
          
        })));
    }
    componentDidMount(){
        this.fetchInitialData();
    }
    fetchInitialData=()=>{
        this.setState({fetchInitialDataDone:false,fetchInitialDataError:null})
        axios.get("https://localhost:5001/Accounting/MoneyAccount/List")
        .then(res=>{
            var moneyAccountList=res.data;
            if(moneyAccountList.length===0)
                this.setState({
                    fetchInitialDataDone:true,
                    fetchInitialDataError:"No Money Account Exists"
                })
            else{
                this.setState({moneyAccountList:moneyAccountList,selectedMoneyAccountID:moneyAccountList[0].id},
                    ()=>{
                        axios.get("https://localhost:5001/Accounting/Currency/List")
                        .then(res2=>{
                            var currencyList=res2.data;
                            if(currencyList.length===0)
                                this.setState({
                                    fetchInitialDataDone:true,
                                    fetchInitialDataError:"No Currencies Exists"
                                })
                            else
                                this.setState({
                                    fetchInitialDataDone:true,
                                    currencyList:currencyList
                                },()=>{
                                    //this.fetchMoneyAccountReport();  
                                    this.fetchAccountInfo();
                                }) 
                        })
                    });
            }
        })
        .catch(err=>{
            this.setState({
                fetchInitialDataDone:true,
                fetchInitialDataError:ExtractErrorMessage(err)
            })
        })
    }
    fetchAccountInfo=()=>{
        this.setState({fetchAccountInfoDone:false,fetchAccountInfoError:null,moneyAccountValue:null})
        axios.get("https://localhost:5001/Accounting/MoneyAccount/moneyaccount_value?MoneyAccountId="
        +this.state.selectedMoneyAccountID)
        .then(res=>this.setState({
            fetchAccountInfoDone:true,
            moneyAccountValue:res.data
        }))
        .catch(err=>this.setState({fetchAccountInfoDone:true,fetchAccountInfoError:ExtractErrorMessage(err),moneyAccountValue:null}))
    }
    moneyAccountChanged=(moneyAccountId)=>{
        this.setState({
            selectedMoneyAccountID:moneyAccountId,
            fetchAccountInfoDone:false,
            fetchAccountInfoError:null,
            moneyAccountValue:null,
        },()=>{this.fetchAccountInfo();})
    }
    render() {
        if(this.state.fetchInitialDataDone===false){
            return(
                <div  className="App">
                    Loading.......
                </div>
            )
        }
        if(this.state.fetchInitialDataError){
            return(
                <div  className="App error" >
                    {this.state.fetchInitialDataError}<br/>
                    {(this.state.moneyAccountList.length===0||this.state.currencyList.length===0)?
                    (<div> go to <a href="/configuration">configuration</a></div>):null}
                    Or <button className="btn btn-primary" onClick={this.fetchInitialData}>Retry</button>
                </div>
            )
        }
        return (
            <div className="main-component " style={{backgroundColor:"khaki",marginTop:2,padding:5}}>
                {
                    this.state.popUpComponent.Show&&
                    <PopUPComponent popUpComponent={this.state.popUpComponent} />
                }
                <div className="App standalone-div borderbuttom ">
                    <label >MoneyAccounts:</label>
                    <select className="bordered color-yellow"  
                    onChange={(e)=>this.moneyAccountChanged(e.target.value)}
                    defaultValue={this.state.selectedMoneyAccountID}>
                        {
                            this.state.moneyAccountList.map((account,index)=>{
                                return (
                                    <option key={index} value={account.id}>{account.name}</option>
                                )
                            })
                        }
                    </select  >
                </div>    
                <MoneyAccountInfo 
                    moneyAccountValue={this.state.moneyAccountValue}
                    fetchAccountInfoDone={this.state.fetchAccountInfoDone}
                    fetchAccountInfoError={this.state.fetchAccountInfoError}
                />      
                <MoneyAccountReport
                    selectedMoneyAccountID={this.state.selectedMoneyAccountID}
                    fetchAccountInfo={this.fetchAccountInfo}
                    moneyAccountList={this.state.moneyAccountList}
                    currencyList={this.state.currencyList}
                    showPopUpComponent={this.showPopUpComponent}
                    closePopUpComponent={this.closePopUpComponent}
                />
        </div>
        );
    }
}

export default MoneyAccountWindow;
