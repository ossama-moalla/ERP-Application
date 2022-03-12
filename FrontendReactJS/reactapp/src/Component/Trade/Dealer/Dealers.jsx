import React, { Component } from 'react';
import axios from 'axios';
import {ExtractErrorMessage} from '../../../GeneralMethods.js'
import DealerAddEdit from './DealerAddEdit.jsx'
import PopUPComponent from '../../PopUPComponent.jsx';
class Dealers extends Component {
    constructor(props){
        super(props);
        this.state={
            fetchDone:false,
            DealerList:[],
            Error:null,
            popUpComponent:{Show:false,component:null,title:''}

        }
    }
    componentDidMount(){
        this.fetchDealers();
    }
    fetchDealers=()=>{
        this.setState({fetchDone:false,DealerList:[],Error:null},()=>
        axios.get("https://localhost:5001/Trade/Dealer/List")
        .then(res=>this.setState({fetchDone:true,DealerList:res.data,Error:null}))
        .catch(err=>this.setState({fetchDone:true,DealerList:[],Error:ExtractErrorMessage(err)}))
        )
    }
    deleteDealer=(id,name)=>{
        var d=window.confirm('are u sure you want to delete category:'+name+'?');
        if(d===false) return;
        this.setState({fetchDone:false,DealerList:[],Error:null},()=>
            axios.delete("https://localhost:5001/Trade/Dealer/Delete?id="+id)
            .then(()=>this.fetchDealers())
            .catch(err=>this.setState({fetchDone:true,Error:ExtractErrorMessage(err)}))
        )
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
    showDealers=(DealerList)=>{
        return (
            <table className="table">
                <thead className="table-success">
                    <tr>
                        <th scope="col">Name</th>
                        <th>Phone</th>
                        <th>Mobile</th>
                        <th>Address</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    
                    {
                        DealerList.map((Dealer)=>
                            {
                                return(
                                    <tr key={Dealer.id}>
                                        <td>{Dealer.fullName}</td>
                                        <td>{Dealer.phone}</td>
                                        <td>{Dealer.mobile}</td>
                                        <td>{Dealer.address}</td>
                                        
                                        <td>
                                        <button className="btn-text" 
                                            onClick={()=>this.showPopUpComponent(
                                                <DealerAddEdit Dealer={Dealer}
                                                    closePopUpComponent={this.closePopUpComponent} 
                                                    fetchDealers={this.fetchDealers}/>
                                                ,'Edit Dealer'
                                            )}
                                            >
                                            <i  className=" bi-pencil" style={{backgroundColor:"blue",
                                            color:"white"}}></i>
                                            </button>
                                            <button className="btn-text" 
                                            onClick={()=>this.deleteDealer(Dealer.id,Dealer.name)}>
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

        )
    }
    render() {
        return (
            <div>
                {
                    this.state.popUpComponent.Show&&
                    <PopUPComponent popUpComponent={this.state.popUpComponent} />
                }
                <button className="btn btn-primary" style={{margin:10}}
                onClick={()=>this.showPopUpComponent(
                    <DealerAddEdit closePopUpComponent={this.closePopUpComponent}
                    fetchDealers={this.fetchDealers}
                    />
                    ,'Add Dealer'
                )}
                >Add Dealer</button>
                {
                    this.state.fetchDone===false?
                    (<div className="App">
                    Loading.......
                    </div>):this.state.error?
                        (
                        <div className="App btn-danger" >
                            {this.state.Error}<br/>
                            <button onClick={this.fetchDealers}>Retry</button>
                        </div>
                        ):this.showDealers(this.state.DealerList)
                }
            </div>
        );
    }
}

export default Dealers;