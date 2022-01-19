import React, { Component } from 'react';
import axios from 'axios';
import {ExtractErrorMessage} from '../../../GeneralMethods.js'
import MoneyAccountAddEdit from './MoneyAccountAddEdit.jsx'
class MoneyAccounts extends Component {
    constructor(props){
        super(props);
        this.state={
            fetchDone:false,
            MoneyAccountList:[],
            Error:null
        }
    }
    componentDidMount(){
        this.fetchMoneyAccounts();
    }
    fetchMoneyAccounts=()=>{
        this.setState({fetchDone:false,MoneyAccountList:[],Error:null},()=>
        axios.get("https://localhost:5001/Accounting/MoneyAccount/List")
        .then(res=>this.setState({fetchDone:true,MoneyAccountList:res.data,Error:null}))
        .catch(err=>this.setState({fetchDone:true,MoneyAccountList:[],Error:ExtractErrorMessage(err)}))
        )
    }
    deleteMoneyAccount=(id,name)=>{
        var d=window.confirm('are u sure you want to delete category:'+name+'?');
        if(d===false) return;
        this.setState({fetchDone:false,MoneyAccountList:[],Error:null},()=>
            axios.delete("https://localhost:5001/Accounting/MoneyAccount/Delete?id="+id)
            .then(()=>this.fetchMoneyAccounts())
            .catch(err=>this.setState({fetchDone:true,Error:ExtractErrorMessage(err)}))
        )
    }
    render() {
        if(this.state.fetchDone===false)
            return(
                <div className="App">
                        Loading.......
                </div>
            )
        if(this.state.Error)
            return(
                <div className="App btn-danger" >
                        {this.state.Error}<br/>
                        <button onClick={this.fetchMoneyAccounts}>Retry</button>
                </div>
            )
        return (
            <div>
                <button className="btn btn-primary" style={{margin:10}}
                onClick={()=>this.props.showPopUpComponent(
                    <MoneyAccountAddEdit closePopUpComponent={this.props.closePopUpComponent}
                    fetchMoneyAccounts={this.fetchMoneyAccounts}
                    />
                    ,'Add MoneyAccount'
                )}
                >Add MoneyAccount</button>
                <table className="table">
                    <thead className="table-success">
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.MoneyAccountList.map((moneyaccount)=>
                                {
                                    return(
                                        <tr key={moneyaccount.id}>
                                            <td>{moneyaccount.id}</td>
                                            <td>{moneyaccount.name}</td>
                                            <td>
                                            <button className="btn-text" 
                                                onClick={()=>this.props.showPopUpComponent(
                                                    <MoneyAccountAddEdit MoneyAccount={moneyaccount}
                                                     closePopUpComponent={this.props.closePopUpComponent} 
                                                     fetchMoneyAccounts={this.fetchMoneyAccounts}/>
                                                    ,'Edit MoneyAccount'
                                                )}
                                                >
                                                <i  className=" bi-pencil" style={{backgroundColor:"blue",
                                                color:"white"}}></i>
                                               </button>
                                               <button className="btn-text" 
                                                onClick={()=>this.deleteMoneyAccount(moneyaccount.id,moneyaccount.name)}>
                                                <i  className=" bi bi-x-lg" style={{backgroundColor:"red",
                                                 color:"white"}}></i>
                                               </button>
                                            </td>  
                                        </tr>
                                    )
                                }
                                )
                        }
                    </tbody>
                </table>
            </div>
        );
    }
}

export default MoneyAccounts;