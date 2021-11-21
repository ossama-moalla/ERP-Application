import React, { Component } from 'react';
import axios from 'axios';
import propTypes from 'prop-types'
class AddItemCategory extends Component {
    constructor(props){
        super(props);
        this.state={
            parentID:null,
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
            pathname: '/ItemCategorys/',
            state: { parentID: this.state.parentID }

            
        })*/
    }
    onChangeInput=async(e)=>{
        await this.setState({[e.target.name]:e.target.value});


    }

    render() {
        return (
             <div>
                <form onSubmit={this.onsubmit}>
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
                    <input type="submit"  value="add ItemCategory" className="btn btn-primary" style={{margin:5}}/>
                    <button className="btn btn-primary" onClick={()=>{this.props.history.push({
            pathname: '/materials/',
            state: { parentID: this.state.parentID }
        })}}>Back</button>
                </div>
            </form>

             </div>           
            
        );
    }
}
AddItemCategory.defaultProps ={
    ID:'',
    Name:'',
    ParentID:''
}
AddItemCategory.propTypes   ={
    
    ParentID:propTypes.string.isRequired
}

export default AddItemCategory;