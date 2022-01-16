import React, { Component } from 'react';
import axios from 'axios';
import $ from 'jquery'
import { ExtractErrorMessage } from '../../../GeneralMethods';

class MoneyAccountAddEdit extends Component {
    constructor(props){
        super(props);
        this.state={
            Name:props.MoneyAccount?Name:''
        }
    }
    updateMoneyAccount=()=>{
        document.getElementById('buttonAdd').disabled=true;
        var moneyaccount={
            Id:this.props.MoneyAccount.Id,
            Name:this.state.Name
        }
        await axios.put("https://localhost:5001/Accounting/MoneyAccount/Update",moneyaccount)
        .then(res=>
            $('moneyaccount_displaymessage').css("background-color","green").text('Money Account Updated').fadeIn(500).delay(1500).fadeOut(500,this.props.closePopUpComponent)
            )
        .catch(err=>
            $('moneyaccount_displaymessage').css("background-color","red").text(ExtractErrorMessage(err)).fadeIn(500).delay(1500).fadeOut(500,this.props.closePopUpComponent)
            )
        document.getElementById('buttonAdd').disabled=false;
    }
    addMoneyAccount=async()=>{
        document.getElementById('buttonAdd').disabled=true;
        var moneyaccount={
            Name:this.state.Name
        }
        await axios.post("https://localhost:5001/Accounting/MoneyAccount/Add",moneyaccount)
        .then(res=>
            $('moneyaccount_displaymessage').css("background-color","green").text('Money Account Added').fadeIn(500).delay(1500).fadeOut(500,this.props.closePopUpComponent)
            )
        .catch(err=>
            $('moneyaccount_displaymessage').css("background-color","red").text(ExtractErrorMessage(err)).fadeIn(500).delay(1500).fadeOut(500,this.props.closePopUpComponent)
            )
        document.getElementById('buttonAdd').disabled=false;
    }
    render() {
        return (
            <div>
                <div id="moneyaccount_displaymessage" style={{display:"none"}}>

                </div>
                 <div id="moneyaccountAdd" className="form-group" >
                    <label>Name:</label>
                    <input type="text" name="name"
                    required className="form-control" 
                    value={this.state.name}
                    onChange={(e)=>this.setState({Name:e.target.value})}
                    />
                </div>  
                <div className="form-group">
                    {
                        this.this.props.Id?
                        <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} onClick={this.updateMoneyAccount}>
                            Update </button>   :
                        <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} onClick={this.addMoneyAccount}>
                            Add </button>   
                    }
                 
                </div>
            </div>
        );
    }
}

export default MoneyAccountAddEdit;