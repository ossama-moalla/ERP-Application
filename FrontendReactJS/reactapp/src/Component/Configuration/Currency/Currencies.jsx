import React, { Component } from 'react';
import axios from 'axios';
import {ExtractErrorMessage} from '../../../GeneralMethods.js'
import CurrencyAddEdit from './CurrencyAddEdit.jsx'
class Currencies extends Component {
    constructor(props){
        super(props);
        this.state={
            fetchDone:false,
            CurrencyList:[],
            Error:null
        }
    }
    componentDidMount(){
        this.fetchCurrencies();
    }
    fetchCurrencies=()=>{
        this.setState({fetchDone:false,CurrencyList:[],Error:null},()=>
        axios.get("https://localhost:5001/Accounting/Currency/List")
        .then(res=>this.setState({fetchDone:true,CurrencyList:res.data,Error:null}))
        .catch(err=>this.setState({fetchDone:true,CurrencyList:[],Error:ExtractErrorMessage(err)}))
        )
    }
    deleteCurrency=(id,name)=>{
        var d=window.confirm('are u sure you want to delete category:'+name+'?');
        if(d===false) return;
        this.setState({fetchDone:false,CurrencyList:[],Error:null},()=>
            axios.delete("https://localhost:5001/Accounting/Currency/Delete?id="+id)
            .then(()=>this.fetchCurrencies())
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
                        <button onClick={this.fetchCurrencies}>Retry</button>
                </div>
            )
        return (
            <div>
                <button className="btn btn-primary" style={{margin:10}}
                onClick={()=>this.props.showPopUpComponent(
                    <CurrencyAddEdit closePopUpComponent={this.props.closePopUpComponent}
                    fetchCurrencies={this.fetchCurrencies}
                    />
                    ,'Add Currency'
                )}
                >Add Currency</button>
                <table className="table">
                    <thead className="table-success">
                        <tr>
                            <th scope="col">Name</th>
                            <th>Symbol</th>
                            <th>Exchange Rate</th>
                            <th>Disabled</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.CurrencyList.map((currency)=>
                                {
                                    return(
                                        <tr key={currency.id}>
                                            <td>{currency.name}</td>
                                            <td>{currency.symbol}</td>
                                            <td>{currency.exchangeRate}</td>
                                            <td>{currency.disabled?'Yes':'No'}</td>
                                            {currency.id!==-1&&
                                            <td>
                                            <button className="btn-text" 
                                                onClick={()=>this.props.showPopUpComponent(
                                                    <CurrencyAddEdit Currency={currency}
                                                     closePopUpComponent={this.props.closePopUpComponent} 
                                                     fetchCurrencies={this.fetchCurrencies}/>
                                                    ,'Edit Currency'
                                                )}
                                                >
                                                <i  className=" bi-pencil" style={{backgroundColor:"blue",
                                                color:"white"}}></i>
                                               </button>
                                               <button className="btn-text" 
                                                onClick={()=>this.deleteCurrency(currency.id,currency.name)}>
                                                <i  className=" bi bi-x-lg" style={{backgroundColor:"red",
                                                 color:"white"}}></i>
                                               </button>
                                            </td>
                                            }   
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

export default Currencies;