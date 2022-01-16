import React, { Component } from 'react';
import Currencies from './Currency/Currencies';
import MoneyAccounts from './MoneyAccount/MoneyAccounts';

const  Configuration =()=> {
    function openTab(e,tabId){
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
    return (
        <div >
            <div className='tab'>
                <button className="tablinks active" onClick={(e)=>openTab(e,'Currencies')}>Currencies</button>
                <button className="tablinks" onClick={(e)=>openTab(e,'MoneyAccounts')}>MoneyAccounts</button>

            </div>
            <div id='Currencies' class="tabcontent"  style={{display:"block"}}>
                <Currencies/>
            </div>
            <div id='MoneyAccounts' class="tabcontent" style={{display:"none"}}>
                <MoneyAccounts/>
            </div>
        </div>
    );
     

}

export default Configuration;