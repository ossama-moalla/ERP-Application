import React, { Component, Fragment } from 'react';
import $ from 'jquery';
import axios from 'axios'
import AddItemCategoryFormik from '../ItemCategory/AddItemCategoryFormik.jsx';
import SearchBar from './SearchBar.jsx';
import FilterBar from './FilterBar.jsx';
import ItemCategoryDiv from './ItemCategoryDiv.jsx';
import {Link} from 'react-router-dom'
import CategoryPath from './CategoryPath.jsx';
class ShowMaterials  extends Component {
    constructor(){
        super();
        this.state={
            currentCategoryID:null,
            CategorysList:null,
            PathList:null,
            Error:null
        }
    }
    componentDidMount(){
        this.refreshCategoryList()
       /* var url=new URL(window.location);
        var parentID = url.searchParams.get("parentid");
        if(parentID=='null') parentID=null;
        this.setState({currentCategoryID:parentID,CategorysList:null,Error:null},()=>this.refreshCategoryList());
         
        if(parentID=='null'||!isNaN(parseInt(parentID)) )
        {
            if(pid=='null') {
                parentID=null;
            }
            else{
                axios.get("https://localhost:5001/materials/ItemCategory/info?id="+pid)
                .then(res=>this.setState({fetchDone:true,parentCategory:res.data}))
                .catch(err=>this.setState({fetchDone:true,parentCategory:{ id:null, name:'Root'},Error:err.response.data}));
            }
        }
        else{
            console.log('B')

            this.setState({fetchDone:true,parentCategory:{ id:null, name:'Root'},Error:'Bad Params'})
        }*/

    }
    refreshCategoryList=()=>{
        axios.get("https://localhost:5001/materials/ItemCategory/GetCategories?parentid="
        +(this.state.currentCategoryID==null?"":this.state.currentCategoryID))
        .then(res=>this.setState({ CategorysList:res.data}))
        .catch(err=>this.setState({Error:err.message}));
    }
    openCategory= (ID)=>{
        console.log(ID)
         this.setState({currentCategoryID:ID,CategorysList:null,Error:null},()=>this.refreshCategoryList());
        
    };
    deleteCategory=(ID)=>{
        if(ID==null) return ;
        var d=confirm('are u sure you want to delete this category with ID:'+ID+'?');
        if(d==false) return;
        axios.delete("https://localhost:5001/materials/ItemCategory/delete?id="+ID)
        .then(res=>this.refreshCategoryList())
        .catch(err=>{
            document.getElementById("displayerror").innerHTML='Server Replay:'+err.response.data
            $('#displayerror').slideDown(500).delay(5000).slideUp('slow');
        

        });
    }
    toggleDiv=(e,divId)=>{
        var s=document.getElementById(divId);
        if(e.target.checked) s.style.display="block";
        else s.style.display="none"
    }
    render(){
        
        if(this.state.Error)
        return(<div className="App" style={{color:"red"}}>{this.state.Error}</div>)
        if(this.state.CategorysList==null)
        return(<div className="App" >Loading......</div>);

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
                    
                <div className="standalone-div main-window " >
                    <div style={{margin:0}}>
                        <label >Path:</label>
                        <div className="div-inlineblock" style={{float:"right"}} >
                        <a href={"materials/itemcategory/add?parentid="+this.state.currentCategoryID}>Add Category</a>
                            {this.state.currentCategoryID&&<a >Add Item</a>}
                        </div>
                    </div>   
                    
                    <div id="main-header" style={{marginTop:0}}>
                        <CategoryPath currentCategoryID={this.state.currentCategoryID} onClick={this.openCategory}/>   
                    </div>   
                    <div id="displayerror" className="App" style={{backgroundColor:"red",color:"white",display:"none"}}></div>
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
                                this.state.CategorysList.length===0?
                                <div className="App">No Data</div>:
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