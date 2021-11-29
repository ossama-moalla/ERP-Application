import React, { Component, Fragment } from 'react';
import axios from 'axios'
import AddItemCategoryFormik from '../ItemCategory/AddItemCategoryFormik.jsx';
import SearchBar from './SearchBar.jsx';
import FilterBar from './FilterBar.jsx';
import ItemCategoryDiv from './ItemCategoryDiv.jsx';
import * as Routes from '../../../AppRoutes';
import {Link} from 'react-router-dom'
class ShowMaterials  extends Component {
    constructor(){
        super();
        this.state={
            currentCategory:null,
            CategorysList:[]
        }
    }
     toggleDiv=(e,divId)=>{
        var s=document.getElementById(divId);
        if(e.target.checked) s.style.display="block";
        else s.style.display="none"
    }
    componentDidMount(){
        var url=new URL(window.location);
        var pid = url.searchParams.get("pid");
        axios.get("https://localhost:5001/materials/ItemCategory/GetCategories?parentid:"+pid)
        .then(res=>this.setState({CategorysList:res.data}))
        .catch(err=>console.log('error:'+err.response.data)); 
    }
    openCategory=(ID)=>{
        alert(ID);
    };
    deleteCategory=(ID)=>{
        alert("delete:"+ID)
    }
    render(){
        return (
            <Fragment>
                <div className="standalone-div" style={{overflow:"auto"}} >
                        <a>Add Category</a>
                        <a >Add Item</a>
                    </div>
                <div className="standalone-div" style={{overflow:"auto"}} >
                    <label>Allowed Access Item Category:</label>
                    <select >
                        <option value="">All</option>
                    </select>
                    
                    <div style={{float:"right"}}>
                        <div className="div-inlineblock"><input  type="checkbox" onChange={(e)=>this.toggleDiv(e,"filterBySpec")} /> Filter By Spec</div>
                        <div className="div-inlineblock"> <input  type="checkbox" style={{marginLeft:12}} onChange={(e)=>this.toggleDiv(e,"search")}/> Search</div>
                        <div className="div-inlineblock"><input type="checkbox" style={{marginLeft:12}} onChange={(e)=>this.toggleDiv(e,"filter")}/> Filter</div>
                    </div>
                </div>
                
                <div id="search" className="standalone-div" style={{display:"none"}}>
                    <SearchBar/>
                </div>
                <div id="filter" className="standalone-div" style={{display:"none"}}>
                    <FilterBar/>
                </div>
                    
                <div className="standalone-div main-window ">   
                    <label >Path:</label>
                    <div id="main-header">
                        Root\<a href="/">Computer </a>\<a href="/">Printer </a>
                    </div>   
                    <div id="main-data">    
                        <div  id="filterBySpec" style={{display:"none",marginRight:"2px",border:"solid 1px",float:"left",height:"100%",padding:"5px"}}>
                            <label>inser value</label><br/><input type="text"/><br/>
                            <label>inser value</label><br/><input type="text"/><br/>
                            <label>inser value</label><br/><input type="text"/><br/>
                            <label>inser value</label><br/><input type="text"/><br/>
                            <button className="btn btn-primary">Filter</button>
                        </div>
                        <div  style={{float:"none",height:"100%",width:"100%"}}>
                            {
                                this.state.CategorysList.map((category,i)=>{
                                   return <ItemCategoryDiv category={category} onDelete={this.deleteCategory} 
                                onClick={this.openCategory } key={i}/>}
                                )
                            }
                        </div>
                    </div>                
                                       
                </div>
            </Fragment>
        );     
    }
   

}
       


export default ShowMaterials;