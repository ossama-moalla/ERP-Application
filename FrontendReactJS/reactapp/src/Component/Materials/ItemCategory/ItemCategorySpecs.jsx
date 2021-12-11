import React, { Component, Fragment } from 'react';
import axios from 'axios';
import propTypes from 'prop-types'
import $ from 'jquery'

class ItemCategorySpecs extends Component {
    constructor(props){
        super(props);
        this.state={
            Category:props.Category,
            Addspec:{
                name:'',
                type:1,
                index:0    
            },
            speclist:[]
            
        }
    }
    componentDidMount(){
        $('#specscontainer').fadeIn(700,this.refreshSpec);

    }
    refreshSpec=()=>{
        console.log("https://localhost:5001/materials/ItemCategorySpec/list?categoryID="+this.state.Category.id)
        axios.get("https://localhost:5001/materials/ItemCategorySpec/list?categoryID="+this.state.Category.id)
        .then(res=>{console.log(res); this.setState({ speclist:res.data})})
        .catch(err=>this.setState({Error:err.message}));
    }
    addSpec=async(e)=>{
        e.preventDefault();
        const spec={
            categoryID:this.state.Category.id,
            name:this.state.Addspec.name,
            index:this.state.Addspec.index
        }
        console.log(spec)
        console.log("https://localhost:5001/materials/"
        +(this.state.Addspec.type==1?"ItemCategorySpec":"ItemCategorySpecRestricted")+"/add")
        await axios.post("https://localhost:5001/materials/"
                +(this.state.Addspec.type==1?"ItemCategorySpec":"ItemCategorySpecRestricted")+"/add",spec)
        .then(res=>{console.log(res); this.setState(prevState => ({
            ...prevState,
            Addspec: {
                     name:'',
                     index:'',
                     type:1
                 }
         }),this.refreshSpec)})
        .catch(err=>{
            document.getElementById("spec_displayerror").innerHTML='Server Replay:'+err.response.data
            $('#spec_displayerror').slideDown(500).delay(5000).slideUp('slow');        });     
    }
    onChangeInput=async(e)=>{
        this.setState(prevState => ({
            ...prevState,
            Addspec: {
                     ...prevState.Addspec,
                     [e.target.name]:e.target.value
                 }
         }));
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
                        value={this.state.Addspec.name}
                        onChange={this.onChangeInput}
                        />
                    </div>
                    <div className="div-inlineblock">
                        <label>Type</label>
                        <select name="type" value={this.state.Addspec.type}
                                                 onChange={this.onChangeInput}>
                            
                            <option value="1">NonRestricted</option>
                            <option value="0">Restricted</option>
                        </select>
                    </div>
                    <div className="div-inlineblock">
                        <label>Index</label>
                        <input type="text" name="index" style={{maxWidth:50}}
                        required 
                        value={this.state.Addspec.index}
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
                        <tbody>
                            {this.state.speclist.map((spec)=>{
                                  return(
                                      <tr key={spec.id}>           
                                          <td>{spec.name}</td>
                                          <td>Non Restricted</td>
                                          <td>{spec.index}</td>
                                      </tr>
                                  )      
                            })}
                        </tbody>
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