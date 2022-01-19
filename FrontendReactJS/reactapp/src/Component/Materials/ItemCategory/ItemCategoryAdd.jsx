import React, { Component } from 'react';
import axios from 'axios';
import ItemCategorySpecs from './ItemCategorySpecs.jsx';
import $ from 'jquery'
import {ExtractErrorMessage} from '../../../GeneralMethods.js'
class ItemCategoryAdd extends Component {
    constructor(props){
        
        super(props);
        this.state={
            AddDone:false,
            id:undefined,
            name:'',
            defaultConsumeUnit:'',
        }
    }
 
    componentDidMount(){
        $('#ItemCategoryAdd').fadeIn(500);
    }
    
    ValidateInput=async()=>{
        const div=document.getElementById("addcategory_displaymessage");
        if(this.state.name.trim()!=="") {
            var category={
                ParentID:this.props.parentID,
                Name:this.state.name,
                defaultConsumeUnit:''
            }
            await axios.post("https://localhost:5001/materials/ItemCategory/verifydata",category)
            .then(res=>{
                if(res.data.nameError)
                    $(div).css( "background-color", "red" ).slideDown(500).text(res.data.nameError)   ;
                else
                     $(div).css( "background-color", "red" ).slideUp(500).text('')   ;
                })
            .catch(err=>{});
        }
        else           
            $(div).css( "background-color", "red" ).slideDown(500).text('name required')   ;

        
    }
    onChangeInput=async(e)=>{
        await this.setState({[e.target.name]:e.target.value},this.ValidateInput);
    }
    addCategory=()=>{
        document.getElementById("buttonAdd").disabled =true;
        const div=document.getElementById("addcategory_displaymessage");
        $(div).css( "background-color", "coral" ).slideDown(500).text('Proccessing.....')
        const Category={
            name:this.state.name,
            parentID: this.props.parentID,
            defaultConsumeUnit:this.state.defaultConsumeUnit
        }
        axios.post("https://localhost:5001/materials/ItemCategory/add",Category)
        .then(res=>
            {
                
                $(div).css( "background-color", "green" ).text('Category Added').delay(1500)
                .slideUp(500,()=>
                {
                    document.getElementById("buttonAdd").disabled =false ;
                    var category_=res.data;
                    this.setState({
                        AddDone:true,
                        id:category_.id,
                        name:category_.name,
                        defaultConsumeUnit:category_.defaultConsumeUnit
                    },this.props.openCategory)
               
                });
                
            }
            )
        .catch(err=>{
            $(div).css( "background-color", "red" ).text(ExtractErrorMessage(err))
            document.getElementById("buttonAdd").disabled =false
        }); 
      
    }
    render() { 
        if(this.state.AddDone) return (
            <ItemCategorySpecs Category={{
                        id:this.state.id,
                        name:this.state.name,
                        defaultConsumeUnit:this.state.defaultConsumeUnit
                    }}
                    Return={()=>this.setState({
                            AddDone:false,
                            name:'',
                            id:undefined,
                            defaultConsumeUnit:''
                            },()=>{$('#ItemCategoryAdd').fadeIn(500);})}
                        />
        )
        return (
            <div id='ItemCategoryAdd' style={{display:"none"}}>
                <div id="addcategory_displaymessage" className="App error-div">
                </div>
                <div   >
                    <div className="form-group" >
                        <label>ItemCategory Name:</label>
                        <input type="text" name="name"
                        required className="form-control" 
                        value={this.state.name}
                        onChange={this.onChangeInput}
                        />
                        
                        <label>Default Consume Unit</label>
                        <input type="text" name="defaultConsumeUnit"
                        required className="form-control" 
                        value={this.state.defaultConsumeUnit}
                        onChange={this.onChangeInput}
                        />
                    </div>  
                    <div className="form-group">
                        <button id="buttonAdd" className="btn btn-primary" style={{margin:5}} onClick={this.addCategory}>
                            Add </button>   
                    </div>
                </div> 
            </div>           
            
        );
    }
}
export default ItemCategoryAdd;