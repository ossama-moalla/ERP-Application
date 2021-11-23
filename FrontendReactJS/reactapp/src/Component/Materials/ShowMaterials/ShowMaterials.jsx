import React, { Component, Fragment } from 'react';
import AddItemCategoryFormik from '../ItemCategory/AddItemCategoryFormik.jsx';
import SearchBar from './SearchBar.jsx';
import FilterBar from './FilterBar.jsx';
import ItemCategoryDiv from './ItemCategoryDiv.jsx';

class ShowMaterials extends Component {
    constructor(){
        super();
        this.state={
            ID:null,
            ParentID:null,
            ItemCategorysList:[
                {
                    ID:0,
                    ParentID:null,
                    name:'Computer',
                    defaultConsumeUnit:'piece'
                },
                {
                    ID:1,
                    ParentID:null,
                    name:'Printer',
                    defaultConsumeUnit:'piece'
                },
                {
                    ID:2,
                    ParentID:null,
                    name:'Lcd',
                    defaultConsumeUnit:'piece'
                }
            ],
            ItemsList:[],  
            PathItemCategorys:[]
        }
    }
   
    openCategory=(ID)=>{
        alert(ID);
    };
    deleteCategory=(ID)=>{
        alert("delete:"+ID)
    }
    toggleDiv=(e,divId)=>{
        var s=document.getElementById(divId);
        if(e.target.checked) s.style.display="block";
        else s.style.display="none"
    }
    render() {
                console.log('show materials')

        return (
            <Fragment>
               
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
                    <span >Path:</span>
                    <div id="main-header">
                        Root\<a href="/">Computer </a>\<a href="/">Printer </a>
                    </div>   
                    <div id="main-data">    
                        <div  id="filterBySpec" style={{display:"none",marginRight:"2px",border:"solid 1px",float:"left",height:"100%",padding:"5px"}}>
                            <label>inser value</label><br/><input type="text"/>
                        </div>
                        <div  style={{float:"none",height:"100%",width:"100%"}}>
                            {
                                this.state.ItemCategorysList.map(category=>
                                    <ItemCategoryDiv category={category} onDelete={this.deleteCategory} 
                                onClick={this.openCategory } key={category.ID}/>
                                )
                            }
                        </div>
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