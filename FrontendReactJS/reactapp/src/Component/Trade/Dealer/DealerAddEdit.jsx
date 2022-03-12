import React, { Component } from 'react';
import axios from 'axios';
import $ from 'jquery'
import { ExtractErrorMessage } from '../../../GeneralMethods.js';

class DealerAddEdit extends Component {
    constructor(props){
        super(props);
        if(props.Dealer){
            this.state={
                Id:props.Dealer.id,
                FullName :props.Dealer.fullName ,
                Phone:props.Dealer.phone,
                Mobile:props.Dealer.mobile,
                Address:props.Dealer.address,
                
            }
        }else{
            this.state={
                Id:undefined,
                FullName :'',
                Phone:'',
                Mobile:'',
                Address:'',
              
            }
        }        
    }
    onChangeInput=async(e)=>{
        this.setState({[e.target.name]:e.target.value});
    }
   
    addDealer=async ()=>{
        document.getElementById('buttonAdd').disabled=true;
        var dealer={ 
            FullName :this.state.FullName ,
            Phone:this.state.Phone,
            Mobile:this.state.Mobile,
            Address :this.state.Address
        }
        await axios.post("https://localhost:5001/Trade/Dealer/Add",dealer)
        .then(res=>{
            $('#AddDealer_displaymessage').css('background-color','green').text('Dealer Added').fadeIn(500)
            .delay(1500).fadeOut(500);
            this.props.fetchDealers();
            this.setState({
                Id:undefined,
                FullName :'',
                Phone:'',
                Mobile:'',
                Address:''
 
            })
        })
        .catch(err=>
            $('#AddDealer_displaymessage').css('background-color','red')
            .text(ExtractErrorMessage(err)).fadeIn(500)
            .delay(1500).fadeOut(500)
        )
        document.getElementById('buttonAdd').disabled=false;
    }
    updateDealer=async ()=>{
        document.getElementById('buttonAdd').disabled=true;
        var dealer={
            id:this.state.Id,
            FullName :this.state.FullName ,
            Phone:this.state.Phone,
            Mobile:this.state.Mobile,
            Address:this.state.Address
        }
        await axios.put("https://localhost:5001/Trade/Dealer/Update",dealer)
        .then(res=>{
            $('#AddDealer_displaymessage').css('background-color','green').text('Dealer Updated').fadeIn(500)
            .delay(1000).fadeOut(500,()=>{
                this.props.fetchDealers();
                this.props.closePopUpComponent();
            });
        })
        .catch(err=>{
            $('#AddDealer_displaymessage').css('background-color','red')
            .text(ExtractErrorMessage(err)).fadeIn(500)
            .delay(1500).fadeOut(500);
            document.getElementById('buttonAdd').disabled=false;

        }            
        )
    }
    render() {
        return (
            <div id='AddDealer' >
            <div id="AddDealer_displaymessage" className="App error-div">
            </div>                                        
                <div >
                    <div className="form-group" >
                        <div>
                            <label>FullName :</label>
                            <input id="FullName " type="text" name="FullName"
                            required className="form-control" 
                            value={this.state.FullName}
                            onChange={this.onChangeInput}
                            />
                            
                        </div>
                        
                        <div>
                            <div className='div-inlineblock'>
                                <label>Phone:</label>
                                <input id="Phone" type="text" name="Phone"
                                required className="form-control" 
                                value={this.state.Phone}
                                onChange={this.onChangeInput}
                                />
                                
                            </div>
                            <div className='div-inlineblock'>
                                <label>Mobile:</label>
                                <input type="text" name="Mobile"
                                required className="form-control" 
                                value={this.state.Mobile}
                                onChange={this.onChangeInput}
                                />
                            </div>
                            
                        </div>
                        <div >
                                <label>Address:</label>
                                <input type="text" name="Address"
                                required className="form-control" 
                                value={this.state.Address}
                                onChange={this.onChangeInput}
                                />
                            </div>
                    </div>  
                    <div className="form-group">
                        {
                            this.state.Id===undefined?
                            
                        <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} 
                        onClick={this.addDealer}>
                            Add </button>   :
                            
                        <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} 
                        onClick={this.updateDealer}>
                            Update </button>   
                        }
                    </div>
                </div> 
        </div>
        );
    }
}

export default DealerAddEdit;