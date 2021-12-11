import React, { Component, Fragment } from 'react';
import axios from 'axios';
import propTypes from 'prop-types'
import ItemCategorySpecs from './ItemCategorySpecs.jsx';
import $ from 'jquery'

class AddItemCategory extends Component {
    constructor(props){
        
        super(props);
        this.state={
            fetchDone:false,
            parentID:props.parentID,
            id:undefined,
            name:'',
            defaultConsumeUnit:'',
            ShowSpec:false,
        }
    }
 
    componentDidMount(){
        $('#additemcategory').fadeIn(700);
       /* var url=new URL( window.location);
        var pid = url.searchParams.get("parentid");
        if(pid=='null'||!isNaN(parseInt(pid)) )
        {
            if(pid=='null') {
                this.setState({fetchDone:true,parentCategory:{ id:null, name:'Root'}})
            }
            else{
                axios.get("https://localhost:5001/materials/ItemCategory/info?id="+pid)
                .then(res=>this.setState({fetchDone:true,parentCategory:res.data}))
                .catch(err=>this.setState({fetchDone:true,parentCategory:{ id:null, name:'Root'},Error:err.response.data}));
            }
        }
        else{
            this.setState({fetchDone:true,parentCategory:{ id:null, name:'Root'},Error:'Bad Params'})
        }*/
  
    }
    onChangeInput=async(e)=>{
        
        await this.setState({[e.target.name]:e.target.value});
    }
    addCategory=()=>{
        const Category={
            name:this.state.name,
            parentID: this.state.parentID,
            defaultConsumeUnit:this.state.defaultConsumeUnit
        }
        console.log(Category)
        axios.post("https://localhost:5001/materials/ItemCategory/add",Category)
        .then(res=>
            {
                var category_=res.data;
               this.setState({
                   name:category_.name,
                    id:category_.id,
                    defaultConsumeUnit:category_.defaultConsumeUnit,
                    ShowSpec:true
                    },this.props.refreshCategoryList());
        }
            )
        .catch(err=>{console.log(err.response.data);
            document.getElementById("addcategory_displayerror").innerHTML='Server Replay:'+err.response.data
            $('#addcategory_displayerror').slideDown(500).delay(5000).slideUp('slow');       
         }); 
      
    }
    render() { 
        if(this.state.ShowSpec){
            return (
                
                <ItemCategorySpecs Category={{
                    id:this.state.id,
                    name:this.state.name,
                    defaultConsumeUnit:this.state.defaultConsumeUnit}}
                    Return={()=>this.setState({
                        name:'',
                         id:undefined,
                         defaultConsumeUnit:'',
                         ShowSpec:false
                         },()=>$('#additemcategory').fadeIn(700))}
                    Close={this.props.Close}     
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