import React, { Component, Fragment } from 'react';
import axios from 'axios';
import propTypes from 'prop-types'
import { isString } from 'formik';


class AddItemCategory extends Component {
    constructor(props){
        
        super(props);
        this.state={
            fetchDone:false,
            parentCategory:null,
            id:undefined,
            name:'',
            defaultConsumeUnit:'',
            Error:null
        }
    }
 
    componentDidMount(){
        var url=new URL( window.location);
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
        }
  
    }
    onChangeInput=async(e)=>{
        
        await this.setState({[e.target.name]:e.target.value});
    }
    addCategory=()=>{
        const Category={
            name:this.state.name,
            parentID: this.state.parentCategory.id,
            defaultConsumeUnit:this.state.defaultConsumeUnit
        }
        axios.post("https://localhost:5001/materials/ItemCategory/add",Category)
        .then(res=>window.location.href="/materials/itemcategory/specs?categoryid="+res.data.id)
        .catch(err=>this.setState({Error:err.response.data})); 
      
    }
    render() { 
        if(this.state.fetchDone==false)
            return(<div className="App" >Loading......</div>)
        if(this.state.Error)
            return(
                <div className="App" >
                    <label style={{color:"red",margin:20}}>{JSON.stringify( this.state.Error)}</label>
                    <br/>
                    
                    <button className="btn btn-primary" 
                        onClick={()=>  window.location.href="/materials?parentid" +(this.state.parentCategory.id==null?"":this.state.parentCategory.id)}>
                            Materials
                    </button>
                </div>)

        return (
            <Fragment>
   
                <div className="bordered" style={{fontWeight:"bold",fontSize:17,textAlign:'center',backgroundColor:'lightblue'}}>
                    <h4>
                    Parent Category:
                    </h4>
                    <h5 style={{color:"red"}}>
                        <strong>
                            <span style={{padding:10}}>ID:{this.state.parentCategory.id==null?"  -   ":this.state.parentCategory.id}</span>
                            <span style={{padding:10}}>Name: {this.state.parentCategory==null?'Root':this.state.parentCategory.name}</span>
                        </strong>
                    </h5>
                </div>
                <div className=" bordered" style={{maxWidth:500,marginLeft:"auto",marginRight:"auto"}} >
                    <div className="form-group" >
                        <label>ItemCategory Name</label>
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
                        onClick={()=>{  window.location.href ="/materials?parentid="+this.state.parentCategory.id    }}>Materials</button>
                    </div>
                </div> 
            </Fragment>
           
            
                   
            
        );
    }
}
export default AddItemCategory;