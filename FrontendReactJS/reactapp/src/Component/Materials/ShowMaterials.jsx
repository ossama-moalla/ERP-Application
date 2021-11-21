import React, { Component, Fragment } from 'react';
import {mainRoutes,materialsRoutes} from '../../AppRoutes.js';
import AddItemCategoryFormik from './ItemCategory/AddItemCategoryFormik.jsx';

class ShowMaterials extends Component {
    constructor(){
        super();
        this.state={
            ParentItemCategoryID:null,
            ItemCategorysList:[],
            ItemsList:[],  
            PathItemCategorys:[]
        }
    }
    render() {
                console.log('show materials')

        return (
            <Fragment>
               
                    <div className="standalone-div" >
                        <label>Allowed Access Item Category:</label>
                        <select >
                            <option value="">All</option>
                        </select>
                    </div>
                    <div className="standalone-div">
                        <div className="div-inlineblock">
                            <label>Filter By Type:</label>
                            <select >
                                <option value="">All</option>
                                <option value="">ItemCategories only</option>
                                <option value="">Items only</option>
                            </select>
                        </div>
                        <div  className="div-inlineblock" >
                            <label>Filter By Item Company:</label>
                            <select >
                                <option value="">All</option>
                                <option value="">ItemCategories only</option>
                                <option value="">Items only</option>
                            </select>
                        </div>
                       
                        
                    </div>
                    <div className="standalone-div">
                        <label>Search:</label>
                        <input type="text" placeholder="search....."></input>
                        <div className="div-inlineblock">
                            <input id = "itemcategory-search" type="checkbox" value="value"   name = "itemcategory-search" />
                            <span>Only in this Item Category</span>
                        
                        </div>
                        
                        
                    </div>
                    <div className="standalone-div" >  
                           
                            <button id="btn-addcategory" className="btn btn-primary"  onClick={()=>{
                                var d=document.getElementById("addcategory");
                                var b=document.getElementById("btn-addcategory");
                                if(d.style.display=="none")
                                {
                                  
                                    b.innerHTML=<div>'dd'+ <i className="bi bi-caret-up-fill"/></div>;
                                    d.style.display="block";
                                } 
                                else d.style.display="none";
                            }}>Create Item Category <i class="bi bi-caret-down-fill"/></button>
                             <div id="addcategory" style={{display:"none"}}>
                            <AddItemCategoryFormik/>
                        </div>
                    </div>
                       
                    <div className="standalone-div main-window ">
                        <button id="btn-270">Show Item Category Tree</button>
                        <button id="btn-90">Filter By ItemCategory Spec's</button>
                       
                        <span >Path:</span>
                        <div id="main-header">
                        
                            Root\<a href="/">Computer </a>\<a href="/">Printer </a>
                        </div>
                       
                        <div className="main-data" style={{border:'solid 1px',height:'100%'}}>

                        </div>
                        
                         
                    </div>

  
  
  

            </Fragment>
        );
    }
}
ShowMaterials.defaultProps={
    
    ParentItemCategoryID:null,
    ItemCategorysList:[],
    ItemsList:[],  
    PathItemCategorys:[]
}
export default ShowMaterials;