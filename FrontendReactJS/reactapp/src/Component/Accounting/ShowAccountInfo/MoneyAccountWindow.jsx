import React, { Component } from "react";
import MoneyAccountSelector from "./MoneyAccountSelector";
import MoneyAccount_Type from "./MoneyAccount_Type.jsx";
import MoneyAccountDetails from './MoneyAccountDetails.jsx';
import MoneyAccountReport from "./MoneyAccountReport.jsx";
import PopUPComponent from '../../PopUPComponent.jsx';


class MoneyAccountWindow extends Component {
  constructor(){
    super();
    this.state={
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
  render() {
    return (
      <div className="main-component " style={{backgroundColor:"khaki"}}>
          {
              this.state.popUpComponent.Show&&
              <PopUPComponent popUpComponent={this.state.popUpComponent} />
          }
          <div className="standalone-div borderbuttom">
              <MoneyAccountSelector />
          </div>
          <div className="standalone-div borderbuttom">
              <MoneyAccount_Type />
          </div>
          <div className="standalone-div borderbuttom">
              <MoneyAccountDetails
               showPopUpComponent={this.showPopUpComponent}
               closePopUpComponent={this.closePopUpComponent}
               />
          </div>
          <div className="standalone-div borderbuttom">
              <MoneyAccountReport/>
          </div>
      </div>
    );
  }
}

export default MoneyAccountWindow;
