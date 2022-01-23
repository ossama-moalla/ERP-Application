import React, { Component } from "react";
import MoneyAccountSelector from "./MoneyAccountSelector";
import MoneyAccountType from "./MoneyAccountType.jsx";
import MoneyAccountDetails from './MoneyAccountDetails.jsx';
import MoneyAccountReport from "./MoneyAccountReport.jsx";
import PopUPComponent from '../../PopUPComponent.jsx';
import axios from 'axios'
import { ExtractErrorMessage } from "../../../GeneralMethods.js";


class MoneyAccountWindow extends Component {
  constructor(){
    super();
    this.state={
      fetchDone:false,
      selectedMoneyAccountID:null,
      moneyAccountList:[],
      currencyList:[],
      Error:null,
      popUpComponent:{Show:false,component:null,title:''}
    }
  }
  componentDidMount(){
    this.fetchData()
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
  fetchData=()=>{
    this.setState({fetchDone:false,Error:null})
    axios.get("https://localhost:5001/Accounting/MoneyAccount/List")
    .then(res=>{
        var moneyAccountList=res.data;
        if(moneyAccountList.Length===0)
            this.setState({
                fetchDone:true,
                Error:"No Money Account Exists"
              })
        else{
            this.setState({moneyAccountList:moneyAccountList,selectedMoneyAccountID:moneyAccountList[0].id},
                ()=>{
                    axios.get("https://localhost:5001/Accounting/Currency/List")
                    .then(res2=>{
                        var currencyList=res2.data;
                        if(currencyList.length===0)
                            this.setState({
                                fetchDone:true,
                                Error:"No Currencies Exists"
                              })
                        else
                            this.setState({
                                currencyList:currencyList,
                                fetchDone:true
                            }) 
                    })
                });
        }
    })
    .catch(err=>{
        this.setState({
            fetchDone:true,
            Error:ExtractErrorMessage(err)
          })
    })
  }
  render() {
    if(this.state.fetchDone===false){
        return(
            <div  className="App">
                Loading.......
            </div>
        )
    }
    if(this.state.Error){
        return(
            <div  className="App error" >
                {this.state.Error}<br/>
                <button className="btn btn-primary" onClick={this.fetchData}>Retry</button>
            </div>
        )
    }
    return (
      <div className="main-component " style={{backgroundColor:"khaki"}}>
          {
              this.state.popUpComponent.Show&&
              <PopUPComponent popUpComponent={this.state.popUpComponent} />
          }
          <div className="standalone-div borderbuttom">
              <MoneyAccountSelector  selectedMoneyAccountID={this.state.selectedMoneyAccountID}  moneyAccountList={this.state.moneyAccountList} />
          </div>
          <div className="standalone-div borderbuttom">
              <MoneyAccountType />
          </div>
          <div className="standalone-div borderbuttom">
              <MoneyAccountDetails
                selectedMoneyAccountID={this.state.selectedMoneyAccountID}
                moneyAccountList={this.state.moneyAccountList}
                currencyList={this.state.currencyList}
                showPopUpComponent={this.showPopUpComponent}
                closePopUpComponent={this.closePopUpComponent}
               />
          </div>
          <div className="standalone-div borderbuttom">
              <MoneyAccountReport
              selectedMoneyAccountID={this.state.selectedMoneyAccountID}
              />
          </div>
      </div>
    );
  }
}

export default MoneyAccountWindow;
