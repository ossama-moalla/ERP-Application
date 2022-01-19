import React, { Component } from 'react';
import axios from 'axios';
import $ from 'jquery'
import {ExtractErrorMessage} from '../../../GeneralMethods.js'
class ItemUpdate extends Component {
    constructor(props){
        
        super(props);
        this.state={
            name:props.item.name,
            company:props.item.company,
            marketCode:props.item.marketCode,
            consumeUnit :props.item.consumeUnit
        }
    }
 
    componentDidMount(){
        $('#ItemUpdate').fadeIn(500);
    }
    ValidateInput=async()=>{
        const div=document.getElementById("updateitem_displaymessage");
        if(this.state.name.toString().trim()===""){
            $(div).css( "background-color", "red" ).slideDown(500).text("name required and Must be not empty");
            return;
        }
        var item={
            id:this.props.item.id,
            name: this.state.name,
            company: this.state.company,
            marketCode: this.state.marketCode,
            consumeUnit: this.state.consumeUnit,
            itemCategoryId: this.props.item.itemCategoryId
        }

        await axios.post("https://localhost:5001/materials/Item/verifydata",item)
        .then(res=>{
            if(res.data.message)
                $(div).css( "background-color", "red" ).slideDown(500).text(res.data.message)   ;
            else
                 $(div).css( "background-color", "red" ).slideUp(500).text('')   ;
            }
         )
        .catch(err=>{});          
    }
    onChangeInput=(e)=>{
         this.setState({[e.target.name]:e.target.value},this.ValidateInput);
    }
    updateItem=()=>{
        document.getElementById("buttonUpdate").disabled =true;
        const div=document.getElementById("updateitem_displaymessage");
        $(div).css( "background-color", "coral" ).slideDown(500).text('Proccessing.....')
        const item={
            id:this.props.item.id,
            name: this.state.name,
            company: this.state.company,
            marketCode: this.state.marketCode,
            consumeUnit: this.state.consumeUnit,
            itemCategoryId: this.props.item.itemCategoryId
        }
        axios.put("https://localhost:5001/materials/Item/Update",item)
        .then(res=>
            {
                $(div).css( "background-color", "green" ).text('Item Updated').delay(1000)
                .slideUp(500,()=>{
                    this.props.openCategory();
                    this.props.closePopUpComponent() 
                });
               
            }
            )
        .catch(err=>{
            console.log(err.response)
            $(div).css( "background-color", "red" ).text(ExtractErrorMessage(err))
            document.getElementById("buttonUpdate").disabled =false
        }
        ); 

    }
    render() { 
        return (
            <div id='ItemUpdate' style={{display:"none"}}>
                <div id="updateitem_displaymessage" className="App error-div">
                </div>                                        
                    <div >
                        <div className="form-group" >
                            <label>Name:</label>
                            <input type="text" name="name"
                            required className="form-control" 
                            value={this.state.name}
                            onChange={this.onChangeInput}
                            />
                            <label>company:</label>
                            <input type="text" name="company"
                            required className="form-control" 
                            value={this.state.company}
                            onChange={this.onChangeInput}
                            />
                            <label>Market Code:</label>
                            <input type="text" name="marketCode"
                            required className="form-control" 
                            value={this.state.marketCode}
                            onChange={this.onChangeInput}
                            />
                            <label>Consume Unit</label>
                            <input type="text" name="consumeUnit"
                            required className="form-control" 
                            value={this.state.consumeUnit}
                            onChange={this.onChangeInput}
                            />
                        </div>  
                        <div className="form-group">
                            <button id='buttonUpdate'  className="btn btn-primary" style={{margin:5}} 
                            onClick={this.updateItem}>
                                Update </button>   
                        </div>
                    </div> 
            </div>           
            
        );
    }
}
export default ItemUpdate;