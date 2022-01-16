import React, { Component } from 'react';
import axios from 'axios'
import $ from 'jquery'

class PayIN_Add extends Component {
    constructor(props){
        console.log(props)
        super(props);
        this.state={
            moneyAccountList:[],
            currencyList:[],
            fetchDone:false,
            Error:null
        }
    }
    componentDidMount(){
        $('#PayinAdd').fadeIn(500);
        this.fetchData();
    }
    fetchData=()=>{
        this.setState({fetchDone:false})
        axios.get("https://localhost:5001/Accounting/MoneyAccount/List")
        .then(res=>{
            var moneyAccountList=res.date;
            console.log(res.data)
            if(moneyAccountList.length==0)
                this.setState({
                    fetchDone:true,
                    Error:{
                        fatal:true,
                        message:"No Money Account Exists"
                    }})
            else{
                this.setState({moneyAccountList:res.date},
                    ()=>{
                        axios.get("https://localhost:5001/Accounting/Currency/List")
                        .then(res=>{
                            var currencyList=res.date;
                            if(currencyList.length==0)
                                this.setState({
                                    fetchDone:true,
                                    Error:{
                                        fatal:true,
                                        message:"No Currencies Exists"
                                    }})
                            else
                                this.setState({
                                    currencyList:res.date,
                                    fetchDone:true
                                }) 
                        })
                    });
            }
        })
        .catch(err=>{
            this.setState({
                fetchDone:true,
                Error:{
                    fatal:true,
                    message:"No Currency Exists"
                }})
        })
    }
    render() {
        if(this.state.fetchDone==false){
            return(
                <div id="PayinAdd" className="App">
                    Loading.......
                </div>
            )
        }
        if(this.state.Error){
            return(
                <div id="PayinAdd" className="App" >
                    {this.state.Error.message}<br/>
                    {
                        this.state.Error.fatal?
                        <button onClick={this.props.closePopUpComponent}>Close</button>:
                        <button onClick={this.fetchData}>Retry</button>
                    }
                </div>
            )
        }
        return (
            <div id="PayinAdd" >
                
            </div>
        );
    }
}

export default PayIN_Add;