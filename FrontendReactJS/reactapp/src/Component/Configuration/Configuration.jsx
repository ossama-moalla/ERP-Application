import React,{Component} from 'react';
import Currencies from './Currency/Currencies';
import MoneyAccounts from './MoneyAccount/MoneyAccounts';
import PopUPComponent from '../PopUPComponent.jsx';

class  Configuration extends Component {
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
    openTab=(e,tabId)=>{
        var i, tabcontent, tablinks;
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
          tabcontent[i].style.display = "none";
        }
        tablinks = document.getElementsByClassName("tablinks");
        for (i = 0; i < tablinks.length; i++) {
          tablinks[i].className = tablinks[i].className.replace(" active", "");
        }
        document.getElementById(tabId).style.display = "block";
        e.currentTarget.className += " active";
    }
    render(){
        return (
            <div >
                {
                    this.state.popUpComponent.Show&&
                    <PopUPComponent popUpComponent={this.state.popUpComponent} />
                }
                <div className='tab'>
                    <button className="tablinks active" onClick={(e)=>this.openTab(e,'Currencies')}>Currencies</button>
                    <button className="tablinks" onClick={(e)=>this.openTab(e,'MoneyAccounts')}>MoneyAccounts</button>
    
                </div>
                <div id='Currencies' className="tabcontent"  style={{display:"block"}}>
                    <Currencies 
                    closePopUpComponent={this.closePopUpComponent}
                    showPopUpComponent={this.showPopUpComponent}            
                    />
                </div>
                <div id='MoneyAccounts' className="tabcontent" style={{display:"none"}}>
                    <MoneyAccounts
                    closePopUpComponent={this.closePopUpComponent}
                    showPopUpComponent={this.showPopUpComponent}            
                    />
                </div>
            </div>
        )
    }
}

export default Configuration;