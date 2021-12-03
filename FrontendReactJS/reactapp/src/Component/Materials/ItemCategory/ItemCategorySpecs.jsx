import React, { Component, Fragment } from 'react';
import axios from 'axios';
import propTypes from 'prop-types'
import { Field } from 'formik';


class ItemCategorySpecs extends Component {
    constructor(props){
        
        super(props);
        this.state={
            Category:null,
            name:'',
            type:0,
            index:0
        }
    }
    componentDidMount(){
        var url=new URL( window.location);
        var categoryid = url.searchParams.get("categoryid");
        axios.get("https://localhost:5001/materials/ItemCategory/info?id="+categoryid)
        .then(res=>this.setState({Category:res.data}))
        .catch(err=>console.log('Client:ItemCategory add error:'+err.response.data)); 
    
    }
    onsubmit=async(e)=>{

        e.preventDefault();
        const ItemCategory={
            name:this.state.name,
            parentID: this.state.parentID,
            defaultConsumeUnit:this.state.defaultConsumeUnit
        }
        console.log(ItemCategory);
        await axios.post("https://localhost:5001/materials/ItemCategory/add",ItemCategory)
        .then(res=>console.log('ItemCategory added'))
        .catch(err=>console.log('Client:ItemCategory add error:'+err.response.data)); 
      /* this.props.history.push({
            pathname: '/materials/',
            state: { parentID: this.state.parentID }

            
        })*/
    }
    onChangeInput=async(e)=>{
        await this.setState({[e.target.name]:e.target.value});
    }

    render() {
        if(this.state.Category==null)
        return(<div className="App" >Loading......</div>)

        if(this.state.Error)
        return(<div className="App" style={{color:"red"}}>{this.state.Error}</div>)

        return (
            <div   style={{maxwidth:500, marginLeft:"auto",marginRight:"auto"}} >
                
                <div className="bordered" style={{fontWeight:"bold",fontSize:17,textAlign:'center',backgroundColor:'lightblue'}}>
                    <h4>
                    Category Shared Item Specefication For Category:
                    </h4>
                    <h5 style={{color:"red"}}><strong><span style={{padding:10}}>ID:{this.state.Category.id}</span><span style={{padding:10}}>Name: {this.state.Category.name}</span></strong></h5>
                </div>
                <div className="bordered" >
                    
                    <div className="div-inlineblock">
                        <label>Spec Name</label>
                        <input type="text" name="name"
                        required 
                        value={this.state.name}
                        onChange={this.onChangeInput}
                        />
                    </div>
                    <div className="div-inlineblock">
                        <label>Type</label>
                        <select>
                            <option>Restricted</option>
                            <option>NonRestricted</option>
                        </select>
                    </div>
                    <div className="div-inlineblock">
                        <label>Index</label>
                        <input type="text" name="Index" style={{maxWidth:50}}
                        required 
                        value={this.state.defaultConsumeUnit}
                        onChange={this.onChangeInput}
                        />
                    </div>
                    <div className="div-inlineblock">
                        <button className="btn btn-primary" >Add Spec</button>
                    </div>
                </div>  
                <div style={{clear:"both"}}></div>
                <div className="bordered" style={{minHeight:150}}>
                    <table className="table" >
                        <thead>
                            <tr>
                                <th >Name</th>
                                <th >Type</th>
                                <th >Index in List</th>
                            </tr>
                        </thead>
                    </table>
                </div>
                <div className="centered">
                    <button className="btn btn-primary " onClick={()=>{          
                        window.location.href="/materials"
                    }}>Materials</button>
                </div>
            </div>                    
            
        );
    }
}

export default ItemCategorySpecs;