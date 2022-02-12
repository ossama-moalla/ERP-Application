import axios from 'axios'
import { ExtractErrorMessage } from '../../../GeneralMethods.js';
import React, { Component } from 'react';

class PayINInfo extends Component {
    constructor(props){
        super(props);
        this.state={
            fetchDone:false,
            PayIN:null,
            Error:null
        }
    }
    componentDidMount(){
        this.fetchdata()
    }
   fetchdata=()=>{
       this.setState({
        fetchDone:false,
        PayIN:null,
        Error:null},()=>{
            axios.get("https://localhost:5001/Accounting/PayIN/Info?id="+this.props.Id)
            .then(res=> this.setState({fetchDone:true,Error:null,PayIN:res.data})  )
            .catch(err=>this.setState({fetchDone:true,Error:ExtractErrorMessage(err)}))    
        })
    }
    render() {
        if(this.state.fetchDone===false){
            return(
                <div  className="App" style={{padding:50}}>
                    Loading.......
                </div>
            )
        }
        if(this.state.Error){
            return(
                <div  className="App error" >
                {this.state.Error}<br/>
                <button className="btn btn-primary" onClick={this.fetchdata}>Retry</button>
                </div>
                )
        }
        const date=new Date(this.state.PayIN.date)
        const style={color:"gold"}
        return (
            <div className="bordered color-green font-white" >
                <div className="App borderbuttom">
                    <label >ID: <span style={style}>{this.state.PayIN?.id}</span></label>
                    <label >Date: <span style={style}>{date.toDateString()}</span></label>
                </div>
                <div className="borderbuttom">
                    <label >Money Account:</label>
                    <label style={style}>{this.state.PayIN?.moneyAccount?.name}</label>
                </div>
                <div className="borderbuttom">
                    <label>Description:</label>
                    <label style={style}>{this.state.PayIN.description}</label>
                </div>
                
                <div className="borderbuttom">
                        <label>Value:</label>
                        <label style={style}>{this.state.PayIN.value}</label>
                        <label>Currency:</label>
                        <label style={style}>{this.state.PayIN.currency.name}</label>
                        <label>ExchangeRate:</label>
                        <label style={style}>{this.state.PayIN.exchangeRate}</label>
                </div>
                
                <div className="borderbuttom">
                    <label>Notes:</label>
                    <label style={style}>{this.state.PayIN.notes}</label>
                </div>
                <div className="App">
                    <button className="btn btn-primary" onClick={this.props.closePopUpComponent}>Close</button>
                </div>
            </div>
        
        );
    }
}

export default PayINInfo;
