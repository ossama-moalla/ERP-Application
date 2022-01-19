import React, { Component } from 'react';
import axios from 'axios';
import ItemCategorySpecs from './ItemCategorySpecs.jsx';
import $ from 'jquery'
import {ExtractErrorMessage} from '../../../GeneralMethods.js'
class ItemCategoryUpdate extends Component {
    constructor(props){
        
        super(props);
        this.state={
            UpdateDone:false,
            name:props.Category.name,
            defaultConsumeUnit:props.Category.defaultConsumeUnit,
            VerifyError:{
                name:null
            }
        }
    }
 
    componentDidMount(){
        $('#ItemCategoryUpdate').fadeIn(500);
     
    }
    
    ValidateInput=async()=>{
        var nameError='';
        if(this.state.name.trim()!=="") {
            var category={
                id:this.props.Category.id,
                ParentID:this.props.Category.parentID,
                Name:this.state.name,
                defaultConsumeUnit:''
            }
            await axios.post("https://localhost:5001/materials/ItemCategory/verifydata",category)
            .then(res=> nameError=res.data.nameError)
            .catch(err=>{});
        }
        this.setState(prevstat=>({
            ...prevstat,
            VerifyError:{
               name: nameError
            }}))
        
    }
    onChangeInput=async(e)=>{
        await this.setState({[e.target.name]:e.target.value},this.ValidateInput);
    }
    updateCategory=()=>{
        const Category={
            id:this.props.Category.id,
            parentID:this.props.Category.parentID,
            name:this.state.name,
            defaultConsumeUnit:this.state.defaultConsumeUnit
        }
        axios.put("https://localhost:5001/materials/ItemCategory/update",Category)
        .then(res=>
            {

               this.setState({
                    UpdateDone:true
                    },this.props.openCategory);
            }
            )
        .catch(err=>{
            document.getElementById("updatecategory_displayerror").innerHTML='Server Replay:'
            +ExtractErrorMessage(err);
            $('#updatecategory_displayerror').slideDown(500).delay(5000).slideUp('slow');       
         }); 
      
    }
    render() { 
        if(this.state.UpdateDone) return (
            <ItemCategorySpecs 
                        Category={{
                            id:this.props.Category.id,
                            parentID:this.props.Category.parentID,
                            name:this.state.name,
                            defaultConsumeUnit:this.state.defaultConsumeUnit
                        }}
                        Return={this.props.closePopUpComponent}     
                        />
        )
        return (
            <div id='ItemCategoryUpdate' style={{display:"none"}}>
                <div id="updatecategory_displayerror" className="App error-div">
                </div>
                <div   >
                    <div className="form-group" >
                        <label>ItemCategory Name:</label>
                        <input type="text" name="name"
                        required className="form-control" 
                        value={this.state.name}
                        onChange={this.onChangeInput}
                        />
                        <div className='form-input-err'>{this.state.VerifyError.name===null?"":this.state.VerifyError.name}</div>
                        
                        <label>Default Consume Unit</label>
                        <input type="text" name="defaultConsumeUnit"
                        required className="form-control" 
                        value={this.state.defaultConsumeUnit}
                        onChange={this.onChangeInput}
                        />
                    </div>  
                    <div className="form-group">
                        <button  className="btn btn-primary" style={{margin:5}} onClick={this.updateCategory}>
                            Update </button>
                    </div>
                </div> 
            </div>           
            
        );
    }
}
export default ItemCategoryUpdate;