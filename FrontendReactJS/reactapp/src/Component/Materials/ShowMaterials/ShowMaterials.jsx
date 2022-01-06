import React, { Component } from 'react';
import $ from 'jquery';
import {toggleDivByCheckbox} from '../../../GeneralMethods.js'

import axios from 'axios'
import SearchBar from './SearchBar.jsx';
import FilterBar from './FilterBar.jsx';
import ItemCategoryDiv from './ItemCategoryDiv.jsx';
import CategoryPath from './CategoryPath.jsx';
import SpecFilter from './SpecFilter.jsx';
import PopUPComponent from '../../PopUPComponent.jsx';
import ItemCategoryAdd from '../ItemCategory/ItemCategoryAdd.jsx';
import ItemAdd from '../Item/ItemAdd.jsx';

class ShowMaterials  extends Component {
    constructor(){
        super();
        this.state={
            currentCategoryID:null,
            CategorysList:null,
            PathList:null,
            Error:null,
            ShowSpecFilter:false,
            popUpComponent:{Show:false,component:null,title:''}
        }
    }
    componentDidMount(){
        this.refreshCategoryList()
    }
    refreshCategoryList=()=>{
        axios.get("https://localhost:5001/materials/ItemCategory/GetCategories?parentid="
        +(this.state.currentCategoryID==null?"":this.state.currentCategoryID))
        .then(res=>{ this.setState({ CategorysList:res.data})})
        .catch(err=>this.setState({Error:err.message}));
    }
    openCategory= (ID)=>{
        if(ID==this.state.currentCategoryID) return;
         this.setState({currentCategoryID:ID,CategorysList:null,Error:null},()=>this.refreshCategoryList());
    }
    deleteCategory=(ID,name)=>{
        if(ID==null) return ;
        var d=window.confirm('are u sure you want to delete category:'+name+'?');
        if(d===false) return;
        axios.delete("https://localhost:5001/materials/ItemCategory/delete?id="+ID)
        .then(res=>this.refreshCategoryList())
        .catch(err=>{
            document.getElementById("displayerror").innerHTML='Server Replay:'+err.response.data
            $('#displayerror').slideDown(500).delay(5000).slideUp('slow');
        });
    }
    closePopUpComponent=()=>  this.setState(prevstat=>({
        ...prevstat,
        popUpComponent:{Show:false,component:null,title:''}
        
    }));
    showPopUpComponent=(component,title)=> {
        this.setState(prevstat=>({
            ...prevstat,
            popUpComponent:{Show:false,component:null,title:''}
            
        }),()=>this.setState(prevstat=>({
            ...prevstat,
            popUpComponent:{Show:true,component:component,title:title}
            
        })));
    }
    render(){

        if(this.state.Error)
        return(<div className="App" style={{color:"red"}}>{this.state.Error}</div>)
        return (
            <div >
                {
                    this.state.popUpComponent.Show&&
                    <PopUPComponent popUpComponent={this.state.popUpComponent} />
                }
                <div className="standalone-div borderbuttom" style={{overflow:"auto"}} >
                    <div style={{float:"left"}}>
                        <label>Allowed Access Item Category:</label>
                        <select >
                            <option value="">All</option>
                        </select>
                    </div>
                    
                    <div style={{float:"right"}}>
                        <div  className="div-inlineblock">
                            <input id="filterBySpec_checkbox"  type="checkbox" checked={this.state.ShowSpecFilter}
                             onChange={(e)=>this.setState({ShowSpecFilter:e.target.checked})} /> Filter By Spec</div>
                        <div className="div-inlineblock"> <input  type="checkbox" style={{marginLeft:12}} onChange={(e)=>toggleDivByCheckbox(e,"search")}/> Search</div>
                        <div className="div-inlineblock"><input type="checkbox" style={{marginLeft:12}} onChange={(e)=>toggleDivByCheckbox(e,"filter")}/> Filter</div>
                    </div>
                </div>
                
                <div id="search" className="standalone-div borderbuttom" style={{display:"none"}}>
                    <SearchBar/>
                </div>
                <div id="filter" className="standalone-div borderbuttom" style={{display:"none"}}>
                    <FilterBar/>
                </div>
                    
                <div className="standalone-div  main-window " >
                    <div style={{margin:0}}>
                        <label >Path:</label>
                        <div className="div-inlineblock" style={{float:"right"}} >
                            {
                            this.state.currentCategoryID&&
                                <button className="btn btn-primary btn-sm" style={{marginRight:10}}
                                onClick={()=>
                                this.showPopUpComponent(
                                <ItemAdd
                                currentCategoryID={this.state.currentCategoryID}
                                refreshCategoryList={this.refreshCategoryList}
                                />,'New Item')}>
                                    Add Item
                            </button>
                            }
                            <button className="btn btn-primary btn-sm"
                             onClick={()=>
                             this.showPopUpComponent(
                             <ItemCategoryAdd
                             refreshCategoryList={this.refreshCategoryList}
                             />,'New Category')}>
                                 Add Category
                            </button>
                        </div>
                    </div>   
                    
                    <div className="bordered color-wheat" style={{marginTop:0}}>
                        <CategoryPath currentCategoryID={this.state.currentCategoryID} 
                        onClick={this.openCategory}/>   
                    </div>   
                    <div id="displayerror" className="App" 
                        style={{backgroundColor:"red",color:"white",display:"none"}}>
                    </div>
                    <div id="main-data" className="new-window-parent" style={{display:"flex"}}>
                        <div className="bordered color-wheat "  
                        style={{display:(this.state.ShowSpecFilter?"block":"none")
                        , marginRight:"2px",float:"left", height:"100%",minWidth:200,padding:"15px"}}>
                            <SpecFilter   currentCategoryID={this.state.currentCategoryID}/>  
                        </div>
                        
                        <div  style={{float:"none",height:"100%",width:"100%"}}>
                            {
                                this.state.CategorysList==null?
                                <div className="App" >Loading......</div>:                        
                                this.state.CategorysList.length===0?
                                <div className="App" style={{color:"red"}}>No Data Entered !</div>:
                                this.state.CategorysList.map((category,i)=>{
                                   return  <ItemCategoryDiv 
                                        category={category}
                                        refreshCategoryList={this.refreshCategoryList}
                                        onDelete={this.deleteCategory}   
                                        closePopUpComponent={this.closePopUpComponent}
                                        showPopUpComponent={this.showPopUpComponent}
                                        openCategory={this.openCategory } key={i}/>}
                                        
                                )
                            }
                        </div>
                    </div>                
                                       
                </div>
            </div>
        );     
    }
   

}
export default ShowMaterials;