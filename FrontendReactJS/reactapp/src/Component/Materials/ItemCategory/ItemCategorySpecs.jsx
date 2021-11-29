import React, { Component, Fragment } from 'react';
import axios from 'axios';
import propTypes from 'prop-types'
import { Field } from 'formik';


class ItemCategorySpecs extends Component {
    constructor(props){
        
        super(props);
        this.state={
            name:'',
            defaultConsumeUnit:''
        }
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
       
        return (
            <Fragment>
            <div className="bordered"  style={{marginLeft:"auto",marginRight:"auto"}} >
            <h5>Category Shared Item Specefication:</h5>
                <div className="div-form " >
                    
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
                <div>
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Type</th>
                                <th>Index</th>
                            </tr>
                        </thead>
                    </table>
                </div>
            </div> 
            
            <div className="centered">
            <button className="btn btn-primary " onClick={()=>{          
                this.props.ViewsInteface.changeView(this.props.ViewsInteface.Views.Materials)
                }}>Close</button>
            </div>
        </Fragment>
                   
            
        );
    }
}

export default ItemCategorySpecs;