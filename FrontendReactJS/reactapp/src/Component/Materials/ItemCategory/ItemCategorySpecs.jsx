import React, { Component, Fragment } from 'react';
import axios from 'axios';
import propTypes from 'prop-types'
import $ from 'jquery'

class ItemCategorySpecs extends Component {
    constructor(props){
        super(props);
        this.state={
            Category:props.Category,
            name:'',
            type:0,
            index:0
        }
    }
    componentDidMount(){
        $('#specscontainer').fadeIn(700);
    }
    
    addSpec=async(e)=>{
        e.preventDefault();
        const spec={
            
            name:this.state.name,
            type: this.state.type,
            index:this.state.index
        }
        await axios.post("https://localhost:5001/materials/"
                +(this.state.type==0?"ItemCategorySpec":"ItemCategorySpecRestricted")+"/add",spec)
        .then(res=>console.log('ItemCategory added'))
        .catch(err=>{
            document.getElementById("spec_displayerror").innerHTML='Server Replay:'+err.response.data
            $('#spec_displayerror').slideDown(500).delay(5000).slideUp('slow');        });       /* this.props.history.push({
            pathname: '/materials/',
            state: { parentID: this.state.parentID }

            
        })*/
    }
    onChangeInput=async(e)=>{
        await this.setState({[e.target.name]:e.target.value});
    }

    render() {
        return (
            <div id="specscontainer" className="bordered" style={{backgroundColor:"#e9ecef",display:"none"}}>
                <div id="spec_displayerror" className="App" 
                    style={{backgroundColor:"red",color:"white",display:"none"}}>
                </div>
                <div className="borderbuttom " style={{padding:5,backgroundColor:"#20505e" ,color:"#f8f9fa"}}>
                    <h5 >
                    Category Shared Item Specefication For Category:<strong>{this.state.Category.name}</strong>
                    </h5>
                </div>
                <div className="borderbuttom" >
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
                        <select name="type" value={this.state.type}
                                                 onChange={this.onChangeInput}>
                            <option value="0">Restricted</option>
                            <option value="1">NonRestricted</option>
                        </select>
                    </div>
                    <div className="div-inlineblock">
                        <label>Index</label>
                        <input type="text" name="index" style={{maxWidth:50}}
                        required 
                        value={this.state.index}
                        onChange={this.onChangeInput}
                        />
                    </div>
                    <div className="div-inlineblock">
                        <button className="btn btn-primary" onClick={this.addSpec} >Add Spec</button>
                    </div>
                </div>  
                <div style={{clear:"both"}}></div>
                <div className="borderbuttom" style={{minHeight:100}}>
                    <table className="table" >
                        <thead>
                            <tr>
                                <th >Name</th>
                                <th >Type</th>
                                <th >Index in List</th>
                            </tr>
                        </thead>
                    </table>
                </div>
                <div >
                    <button className="btn btn-primary " style={{marginLeft:20,marginRight:20}} 
                    onClick={()=>{
                        $('#specscontainer').fadeOut(500,this.props.Return)}}>
                        Finish
                    </button>
                    <button className="btn btn-primary" 
                        onClick={ this.props.Close}>Close
                    </button>
                </div>
            </div>                    
            
        );
    }
}

export default ItemCategorySpecs;