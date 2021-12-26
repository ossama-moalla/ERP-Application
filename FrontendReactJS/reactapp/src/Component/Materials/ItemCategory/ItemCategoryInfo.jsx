import axios from 'axios'
import {ExtractErrorMessage} from '../../../GeneralMethods.js'
import { Fragment } from 'react';
import $ from 'jquery'
import React, { Component } from 'react';

class ItemCategoryInfo extends Component {
    constructor(props){
        super(props);
        this.state={
            specList:null,
            fetchDone:false,
            errorMessage:null
        }
    }
    componentDidMount=()=>{
        $('#itemcategoryinfo').fadeIn(700,()=>this.fetchdata());
        
    }
    fetchdata=()=>{
        axios.get("https://localhost:5001/materials/ItemCategorySpec/list?categoryID="
        +this.props.Category.id)
         .then(res=>this.setState({fetchDone:true,specList:res.data}))
         .catch(err=>this.setState({fetchDone:true,errorMessage:ExtractErrorMessage(err)}) )
    }
   
    render() {
        return (
            <div id="itemcategoryinfo"  
            style={{display:'none'}}>
                
                <div className="standalone-div borderbuttom">
                        <label >Category Name:</label>
                        <label>{this.props.Category.name}</label>
                    </div>
                    <div className="standalone-div borderbuttom">
                        <label >Default ConsumeUnit:</label>
                        <label>{this.props.Category.defaultConsumeUnit.length==0?
                        "-":this.props.Category.defaultConsumeUnit}</label>
                    </div>
                    <div className="standalone-div borderbuttom">
                        <label >Shared Item Specification:</label><br/>
                        {this.state.errorMessage!=null?
                            <Fragment>
                            errorMessage<br/>
                            <button>Retry</button>
                            </Fragment>
                            :(
                                this.state.fetchDone==false?"Loading....":
                                (   <div>
                                        {
                                            this.state.specList.length==0?
                                            <label style={{backgroundColor:"yellow"}}>"No Spec's Entered For This Category"</label>:
                                            <table className="table" >
                                                <thead>
                                                    <tr>
                                                        <th >Name</th>
                                                        <th >IS Restricted</th>
                                                        <th >Index in List</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    {this.state.specList.map((spec)=>{
                                                        return(
                                                            <tr key={spec.id}
                                                            style={{backgroundColor:spec.isRestricted?"coral":"bisque"}}>           
                                                                <td>{spec.name}</td>
                                                                <td>{spec.isRestricted?"True":"False"}</td>
                                                                <td>{spec.index}</td>
                                                            </tr>
                                                        )      
                                                    })}
                                                </tbody>
                                            </table>
                                        }
                                    </div>
                                
                                )
                            )
                        }
                    </div>                
            </div>
        );
    }
}

export default ItemCategoryInfo;

