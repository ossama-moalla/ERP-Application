import React, { Component, Fragment } from 'react';
import axios from 'axios';
import propTypes from 'prop-types'


class AddItemCategory extends Component {
    constructor(props){
        
        super(props);
        this.state={
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
        
        if(pid==null){
            this.setState({parentCategory:{
                id:null,
                name:'Root'
            }})
        }
        else{
             axios.get("https://localhost:5001/materials/ItemCategory/info?id="+pid)
            .then(res=>this.setState({parentCategory:res.data}))
            .catch(err=>this.setState({Error:'Couldint retrive data'}));
        }
    }
    onChangeInput=async(e)=>{
        
        await this.setState({[e.target.name]:e.target.value});
    }
    addCategory=()=>{
        const Category={
            name:this.state.name,
            parentID: this.state.parentCategory==null?null:this.state.parentCategory.id,
            defaultConsumeUnit:this.state.defaultConsumeUnit
        }
        console.log(Category)
         axios.post("https://localhost:5001/materials/ItemCategory/add?parentid="+
          +(this.state.parentCategory.id==null?"":this.state.parentCategory.id),Category)
        .then(res=>console.log('ItemCategory added'))
        .catch(err=>console.log('Client:ItemCategory add error:'+err.response.data)); 
      
    }
    render() {
       
        if(this.state.parentCategory==null)
        return(<div className="App" >Loading......</div>)

        if(this.state.Error)
        return(<div className="App" style={{color:"red"}}>{this.state.Error}</div>)
        return (
            <Fragment>
                {
                    (this.state.parentCategory== null?<Fragment>pad params</Fragment>:
                        (<Fragment>
                            <div className="bordered" style={{textAlign:'center',backgroundColor:'lightblue'}}>
                                <label>Parent Category </label><br/>
                                <label  className="btn-success" style={{paddingLeft:20,paddingRight:20}}>ID:{this.state.parentCategory==null?"  -   ":this.state.parentCategory.id}</label>
                                <label className="btn-success" style={{paddingLeft:20,paddingRight:20}}>Name: {this.state.parentCategory==null?'Root':this.state.parentCategory.name}</label>
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
                                onClick={()=>{  window.location.href ="/materials?parentid:"+this.state.parentCategory.id    }}>Back</button>
                            </div>
                        </div> 
                            </Fragment>
                        )
                    )
                }

            </Fragment>
           
            
                   
            
        );
    }
}
export default AddItemCategory;