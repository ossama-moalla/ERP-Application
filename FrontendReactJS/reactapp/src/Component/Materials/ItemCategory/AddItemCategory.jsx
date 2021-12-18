import React, { Component, Fragment } from 'react';
import axios from 'axios';
import propTypes from 'prop-types'
import ItemCategorySpecs from './ItemCategorySpecs.jsx';
import $ from 'jquery'
import {ExtractErrorMessage} from '../../../GeneralMethods.js'
class AddItemCategory extends Component {
    constructor(props){
        
        super(props);
        this.state={
            id:undefined,
            name:'',
            defaultConsumeUnit:'',
            VerifyError:{
                name:null
            },
            NextStage_ShowSpec:false
        }
    }
 
    componentDidMount(){
        $('#additemcategory').fadeIn(700);
    }
    ValidateInput=async()=>{
        var nameError='';
        if(this.state.name.trim()!="") {
            var category={
                ParentID:this.props.parentID,
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
    addCategory=()=>{
        const Category={
            name:this.state.name,
            parentID: this.props.parentID,
            defaultConsumeUnit:this.state.defaultConsumeUnit
        }
        axios.post("https://localhost:5001/materials/ItemCategory/add",Category)
        .then(res=>
            {
                var category_=res.data;
               this.setState({
                    name:category_.name,
                    id:category_.id,
                    defaultConsumeUnit:category_.defaultConsumeUnit,
                    NextStage_ShowSpec:true
                    },this.props.refreshCategoryList());
        }
            )
        .catch(err=>{
            document.getElementById("addcategory_displayerror").innerHTML='Server Replay:'
            +ExtractErrorMessage(err);
            $('#addcategory_displayerror').slideDown(500).delay(5000).slideUp('slow');       
         }); 
      
    }
    render() { 
          if(this.state.NextStage_ShowSpec){
            return (
                
                <ItemCategorySpecs Category={{
                    id:this.state.id,
                    name:this.state.name,
                    defaultConsumeUnit:this.state.defaultConsumeUnit}}
                    Return={()=>this.setState({
                        name:'',
                         id:undefined,
                         defaultConsumeUnit:'',
                         NextStage_ShowSpec:false
                         },()=>$('#additemcategory').fadeIn(700))}
                    Close={this.props.Close}     
                    ExtractErrorMessage={this.props.ExtractErrorMessage}
                    />
            )
        }
        return (
            <div id="additemcategory"  style={{borderRadius:15, backgroundColor:"#e9ecef",display:'none'}}>
                <div id="addcategory_displayerror" className="App" 
                    style={{backgroundColor:"red",color:"white",display:"none"}}>
                </div>
                <div className=" bordered" style={{maxWidth:500}} >
                    <div className="form-group" >
                        <label>ItemCategory Name:</label>
                        <input type="text" name="name"
                        required className="form-control" 
                        value={this.state.name}
                        onChange={this.onChangeInput}
                        />
                        <div className='form-input-err'>{this.state.VerifyError.name==null?"":this.state.VerifyError.name}</div>
                        
                        <label>Default Consume Unit</label>
                        <input type="text" name="defaultConsumeUnit"
                        required className="form-control" 
                        value={this.state.defaultConsumeUnit}
                        onChange={this.onChangeInput}
                        />
                    </div>  
                    <div className="form-group">
                        <button  className="btn btn-primary" style={{margin:5}} onClick={this.addCategory}>Add </button>
                        <button className="btn btn-primary" 
                        onClick={()=>{$('#additemcategory').fadeOut(700,this.props.Close);
                          } }>Close</button>
                    </div>
                </div> 
            </div>           
            
        );
    }
}
export default AddItemCategory;