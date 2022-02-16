import axios from 'axios'
import { ExtractErrorMessage } from '../../../GeneralMethods.js';
import React, { Component } from 'react';

class ExchangeOPRInfo extends Component {
    constructor(props){
        super(props);
        this.state={
            fetchDone:false,
            ExchangeOPR:null,
            Error:null
        }
    }
    componentDidMount(){
        this.fetchdata()
    }
   fetchdata=()=>{
       this.setState({
        fetchDone:false,
        ExchangeOPR:null,
        Error:null},()=>{
            axios.get("https://localhost:5001/Accounting/ExchangeOPR/Info?id="+this.props.Id)
            .then(res=> this.setState({fetchDone:true,Error:null,ExchangeOPR:res.data})  )
            .catch(err=>this.setState({fetchDone:true,Error:ExtractErrorMessage(err)}))    
        })
    }
    deleteOperation=async()=>{
        this.setState({fetchDone:false});
        await axios.delete("https://localhost:5001/Accounting/ExchangeOPR/Delete?id="+this.props.Id)
            .then(res=>{
                this.props.fetchAccountInfo();
                this.props.fetchReport();
                this.props.closePopUpComponent();

            })
            .catch(err=>{
                alert('Delete Error:'+ExtractErrorMessage(err));
            })    
            this.setState({fetchDone:true});
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
        const date=new Date(this.state.ExchangeOPR.date)
        const style={color:"gold",marginRight:5}
        return (
            <div>
                <div className="bordered" style={{color:"white",backgroundColor:"darkgoldenrod"}}>
                    <div className="App borderbuttom">
                        <label >ID: <span style={style}>{this.state.ExchangeOPR?.id}</span></label>
                        <label >Date: <span style={style}>{date.toDateString()}</span></label>
                    </div>
                    <div className="borderbuttom">
                        <label >Money Account:</label>
                        <label style={style}>{this.state.ExchangeOPR?.moneyAccount?.name}</label>
                    </div>                
                    <div className="borderbuttom">
                            <label> Out Value:</label>
                            <label style={style}>{this.state.ExchangeOPR.outMoneyValue}</label>
                            <label>Currency:</label>
                            <label style={style}>{this.state.ExchangeOPR.sourceCurrency.name}</label>
                            <label>ExchangeRate:</label>
                            <label style={style}>{this.state.ExchangeOPR.sourceExchangeRate}</label>
                    </div>
                    <div className="borderbuttom">  
                            <label> IN Value:</label>
                            <label style={style}>{(this.state.ExchangeOPR.outMoneyValue*
                            (this.state.ExchangeOPR.targetExchangeRate/
                                this.state.ExchangeOPR.sourceExchangeRate)).toFixed(2)}</label>
                            <label>Currency:</label>
                            <label style={style}>{this.state.ExchangeOPR.targetCurrency.name}</label>
                            <label>ExchangeRate:</label>
                            <label style={style}>{this.state.ExchangeOPR.targetExchangeRate}</label>
                    </div>
                    
                    <div className="borderbuttom">
                        <label>Notes:</label>
                        <label style={style}>{this.state.ExchangeOPR.notes}</label>
                    </div>
                </div>
                
                <div className="App" >
                    <button className="btn btn-warning" style={{margin:5}} onClick={()=>this.props.editMoneyAccountOperation(this.state.ExchangeOPR,2)}>Edit</button>
                    <button className="btn btn-danger" style={{margin:5}} onClick={this.deleteOperation}>Delete</button>
                    <button className="btn btn-primary" style={{margin:5}} onClick={this.props.closePopUpComponent}>Close</button>                
                </div>
            </div>
        
        );
    }
}

export default ExchangeOPRInfo;
