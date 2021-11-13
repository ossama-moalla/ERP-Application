import React, { Component, Fragment } from 'react';

class DisplayMaterials extends Component {
    
    render() {
        console.log('fffff')
        return (
            <Fragment>
               
                    <div >
                        <label>Allowed Access Item Category:</label>
                        <select >
                            <option value="">All</option>
                        </select>
                    </div>
                    <div >
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
                    <div >
                        <label>Search:</label>
                        <input type="text" placeholder="search....."></input>
                        <div className="div-inlineblock">
                        <input id = "itemcategory-search" type="checkbox" value="value"   name = "itemcategory-search" />
                        <span>Only in this Item Category</span>
                        </div>

                        
                    </div>
                    <div id="main-window">
                        <button id="btn-270">Show Item Category Tree</button>
                        <button id="btn-90">Filter By ItemCategory Spec's</button>
                        <div  style={{padding:"0px",margin:'0px 8px 0px 6px'}}>  
                            <span >Path:</span>
                            <a href="#" style={{float:"right"}}>Create Item Category</a>
                        </div>
                        
                        <div id="main-header">
                           
                            Root\<a href="#">Computer </a>\<a href="#">Printer </a>
                        </div>
                        <div className="main-data" style={{border:'solid 1px',height:'100%'}}>

                        </div>
                        
                         
                    </div>

  
  
  

            </Fragment>
        );
    }
}

export default DisplayMaterials;