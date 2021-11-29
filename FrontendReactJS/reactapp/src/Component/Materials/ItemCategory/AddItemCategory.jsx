import React, { Component, Fragment } from 'react';
import axios from 'axios';
import propTypes from 'prop-types'
import ItemCategorySpecs from './ItemCategorySpecs';


class AddItemCategory extends Component {
    constructor(props){
        
        super(props);
        this.state={
            parentCategory:null,
            id:undefined,
            name:'',
            defaultConsumeUnit:''
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
            .catch(err=>console.log('error:'+err.response.data)); 
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
         axios.post("https://localhost:5001/materials/ItemCategory/add",Category)
        .then(res=>console.log('ItemCategory added'))
        .catch(err=>console.log('Client:ItemCategory add error:'+err.response.data)); 
      
    }
    render() {
       
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
                        
                            {
                                this.state.id==undefined?
                                <AddCategoryForm state={this.state}  onChangeInput={this.onChangeInput} addCategory={this.addCategory}/>
                                :<ItemCategorySpecs ViewsInteface={this.props.ViewsInteface}/>
                            }
                            </Fragment>
                        )
                    )
                }

            </Fragment>
           
            
                   
            
        );
    }
}
const AddCategoryForm=(props)=>{
    return(
        <div className=" bordered" style={{maxWidth:500,marginLeft:"auto",marginRight:"auto"}} >
            <div className="form-group" >
                <label>ItemCategory Name</label>
                <input type="text" name="name"
                required className="form-control" 
                value={props.state.name}
                onChange={(e)=>props.onChangeInput(e)}
                />
                <label>Default Consume Unit</label>
                <input type="text" name="defaultConsumeUnit"
                required className="form-control" 
                value={props.state.defaultConsumeUnit}
                onChange={props.onChangeInput}
                />
            </div>  
            <div className="form-group">
                <button  className="btn btn-primary" style={{margin:5}} onClick={props.addCategory}>Add </button>
                <button className="btn btn-primary" onClick={()=>{          
                props.ViewsInteface.changeView(props.ViewsInteface.Views.Materials)
                }}>Back</button>
            </div>
        </div> 
    )
}
export default AddItemCategory;