import axios from 'axios'
import { ExtractErrorMessage } from '../../../GeneralMethods.js';
import React, { Component } from 'react';

class MoneyTransformOPRInfo extends Component {
    constructor(props){
        super(props);
        this.state={
            fetchDone:false,
            MoneyTransformOPR:null,
            Error:null
        }
    }
    componentDidMount(){
        this.fetchdata()
    }
   fetchdata=()=>{
       this.setState({
        fetchDone:false,
        MoneyTransformOPR:null,
        Error:null},()=>{
            axios.get("https://localhost:5001/Accounting/MoneyTransformOPR/Info?id="+this.props.Id)
            .then(res=> this.setState({fetchDone:true,Error:null,MoneyTransformOPR:res.data})  )
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
        const date=new Date(this.state.MoneyTransformOPR.date)
        const style={color:"gold",marginRight:5}
        return (
            <div className="bordered color-cadetblue" style={{color:"white"}}>
                <div className="App borderbuttom">
                    <label >ID: <span style={style}>{this.state.MoneyTransformOPR?.id}</span></label>
                    <label >Date: <span style={style}>{date.toDateString()}</span></label>
                </div>
                <div className="borderbuttom">
                    <label >Source Money Account:</label>
                    <label style={style}>{this.state.MoneyTransformOPR?.sourceMoneyAccount?.name}</label>
                </div>
                <div className="borderbuttom">
                    <label >Target Money Account:</label>
                    <label style={style}>{this.state.MoneyTransformOPR?.targetMoneyAccount?.name}</label>
                </div>
                <div className="borderbuttom">
                        <label>Value:</label>
                        <label style={style}>{this.state.MoneyTransformOPR.value}</label>
                        <label>Currency:</label>
                        <label style={style}>{this.state.MoneyTransformOPR.currency.name}</label>
                        <label>ExchangeRate:</label>
                        <label style={style}>{this.state.MoneyTransformOPR.exchangeRate}</label>
                </div>
                <div>
                    <label>Notes:</label>
                    <label style={style}>{this.state.MoneyTransformOPR.notes}</label>
                </div>
                <div className="App">
                    <button className="btn btn-primary" onClick={this.props.closePopUpComponent}>Close</button>
                </div>
            </div>
        
        );
    }
}

export default MoneyTransformOPRInfo;
