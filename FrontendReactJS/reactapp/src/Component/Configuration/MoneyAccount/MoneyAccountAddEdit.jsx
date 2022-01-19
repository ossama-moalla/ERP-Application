import React, { Component } from 'react';
import axios from 'axios';
import $ from 'jquery'
import { ExtractErrorMessage } from '../../../GeneralMethods';

class MoneyAccountAddEdit extends Component {
    constructor(props){
        super(props);
        if(props.MoneyAccount){
            this.state={
                Id:props.MoneyAccount.id,
                Name:props.MoneyAccount.name,
                verifyError:null
            }
        }else{
            this.state={
                Id:undefined,
                Name:'',
                verifyError:null
            }
        }        
    }
    onChangeInput=async(e)=>{
        this.setState({[e.target.name]:e.target.value},this.ValidateInput);
    }
    ValidateInput=()=>{
        if(this.state.Name.toString().trim()===""){
            return;
        }
        var moneyaccount={
            Name:this.state.Name
        }
        console.log(moneyaccount)
        axios.post("https://localhost:5001/Accounting/MoneyAccount/verifydata",moneyaccount)
        .then(res=>{
            this.setState({
                verifyError:res.data.Message
            })
        })
        .catch(err=>{console.log(err)})
    }
    addMoneyAccount=async ()=>{
        document.getElementById('buttonAdd').disabled=true;
        var moneyaccount={
            name:this.state.Name,
            }
            console.log(moneyaccount)
        await axios.post("https://localhost:5001/Accounting/MoneyAccount/Add",moneyaccount)
        .then(res=>{
            $('#AddMoneyAccount_displaymessage').css('background-color','green').text('MoneyAccount Added').fadeIn(500)
            .delay(1500).fadeOut(500);
            this.props.fetchMoneyAccounts();
            this.setState({
                 Id:undefined,
                Name:''
            })
        })
        .catch(err=>
            $('#AddMoneyAccount_displaymessage').css('background-color','red')
            .text(ExtractErrorMessage(err)).fadeIn(500)
            .delay(1500).fadeOut(500)
        )
        document.getElementById('buttonAdd').disabled=false;
    }
    updateMoneyAccount=async ()=>{
        document.getElementById('buttonAdd').disabled=true;
        var moneyaccount={
            id:this.state.Id,
            name:this.state.Name
        }
        await axios.put("https://localhost:5001/Accounting/MoneyAccount/Update",moneyaccount)
        .then(res=>{
            $('#AddMoneyAccount_displaymessage').css('background-color','green').text('MoneyAccount Updated').fadeIn(500)
            .delay(1500).fadeOut(500,()=>{
                this.props.fetchMoneyAccounts();
                this.props.closePopUpComponent();
            });
        })
        .catch(err=>
            $('#AddMoneyAccount_displaymessage').css('background-color','red')
            .text(ExtractErrorMessage(err)).fadeIn(500)
            .delay(1500).fadeOut(500)
        )
        document.getElementById('buttonAdd').disabled=false;
    }
    render() {
        return (
            <div id='AddMoneyAccount' >
                <div id="AddMoneyAccount_displaymessage" className="App error-div">
                </div>                                        
                <div className="form-group" >
                    <div>
                        <label>Name:</label>
                        <input id="Name" type="text" name="Name"
                        required className="form-control" 
                        value={this.state.Name}
                        onChange={this.onChangeInput}
                        />
                        {this.state.verifyError&&          
                        <label className='form-input-err' >{this.state.verifyError}</label>
                        }
                    </div>
                    <div className="form-group">
                    {
                        this.state.Id===undefined?
                        
                    <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} 
                    onClick={this.addMoneyAccount}>
                        Add </button>   :
                        
                    <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} 
                    onClick={this.updateMoneyAccount}>
                        Update </button>   
                    }
                    </div>
                </div> 
        </div>
        );
    }
}

export default MoneyAccountAddEdit;