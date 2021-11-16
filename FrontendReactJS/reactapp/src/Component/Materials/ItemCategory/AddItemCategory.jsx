import React, { Component } from 'react';
import axios from 'axios';
import propTypes from 'prop-types'
class AddItemCategory extends Component {
    constructor(props){
        super(props);
        this.state={
            ParentItemCategoryID:1,
            ItemCategoryName:''
        }
    }
    
    onsubmit=async(e)=>{

        e.preventDefault();
       /* const ItemCategory={
            ItemCategoryName:this.state.ItemCategoryName,
            ParentItemCategoryID: this.state.ParentItemCategoryID
        }
        await axios.post("http://localhost:5000/ItemCategorys/additemcategory/",ItemCategory)
        .then(res=>console.log('ItemCategory added'))
        .catch(err=>console.log('Client:ItemCategory add error:'+err.response.data)); 
       this.props.history.push({
            pathname: '/ItemCategorys/',
            state: { ParentItemCategoryID: this.state.ParentItemCategoryID }

            
        })*/
    }
    onChangeInput=async(e)=>{
        await this.setState({[e.target.name]:e.target.value});
        console.log(this.state)

    }
    render() {
        return (
             <div>
                <form onSubmit={this.onsubmit}>
                <div className="form-group" >
                    <label>ItemCategory Name</label>
                    <input type="text" name="ItemCategoryName"
                     required className="form-control" 
                     value={this.state.ItemCategoryName}
                     onChange={this.onChangeInput}
                     />
                </div>  
                <div className="form-group">
                    <input type="submit"  value="add ItemCategory" className="btn btn-primary" style={{margin:5}}/>
                    <button className="btn btn-primary" onClick={()=>{this.props.history.push({
            pathname: '/materials/',
            state: { ParentItemCategoryID: this.state.ParentItemCategoryID }
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