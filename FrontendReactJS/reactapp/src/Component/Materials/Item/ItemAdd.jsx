import React, { Component, Fragment } from 'react';
import axios from 'axios';
import $ from 'jquery'
import {ExtractErrorMessage,makeDragable} from '../../../GeneralMethods.js'
class ItemAdd extends Component {
    constructor(props){
        
        super(props);
        this.state={
            id:undefined,
            name:'',
            company:'',
            marketCode:'',
            consumeUnit :'',
            fetchCategoryDone:false,
            Category:null
        }
    }
 
    componentDidMount(){
        $('#ItemAdd').fadeIn(500);
        this.fetchCategoryInfo();
    }
    fetchCategoryInfo=()=>{
        if(this.state.fetchCategoryDone){
            this.setState(
                {
                    fetchCategoryDone:false
                })
        }
        const div=document.getElementById("additem_displaymessage");
        $(div).css( "background-color", "coral" ).slideDown(500).text("Fetching Category Info ....");
        axios.get("https://localhost:5001/materials/ItemCategory/info?id="
        +this.props.currentCategoryID) 
        .then(res=>
            {
                $(div).slideUp(500).text("");
                const category=res.data;
                this.setState(
                    {
                        fetchCategoryDone:true,
                        Category:category,
                        consumeUnit:category.defaultConsumeUnit
                    })
            }
        ) 
        .catch(err=>
            {
                $(div).css( "background-color", "red" ).slideDown(500).text("Failed to get Category Info");
                this.setState(
                    {
                        fetchCategoryDone:true,
                        Category:null
                    }
                )
            }
            )
    }
    ValidateInput=async()=>{
        const div=document.getElementById("additem_displaymessage");
        if(this.state.name.toString().trim()==""){
            $(div).css( "background-color", "red" ).slideDown(500).text("name required and Must be not empty");
            return;
        }
        var item={
            name: this.state.name,
            company: this.state.company,
            marketCode: this.state.marketCode,
            consumeUnit: this.state.consumeUnit,
            itemCategoryId: this.props.currentCategoryID
        }

        await axios.post("https://localhost:5001/materials/Item/verifydata",item)
        .then(res=>{
            if(res.data.message)
                $(div).css( "background-color", "red" ).slideDown(500).text(res.data.message)   ;
            else
                 $(div).css( "background-color", "red" ).slideUp(500).text('')   ;
            }
         )
        .catch(err=>{});          
    }
    onChangeInput=(e)=>{
         this.setState({[e.target.name]:e.target.value},this.ValidateInput);
    }
    addItem=()=>{
        document.getElementById("buttonAdd").disabled =true;
        const div=document.getElementById("additem_displaymessage");
        $(div).css( "background-color", "coral" ).slideDown(500).text('Proccessing.....')
        const item={
            name: this.state.name,
            company: this.state.company,
            marketCode: this.state.marketCode,
            consumeUnit: this.state.consumeUnit,
            itemCategoryId: this.props.currentCategoryID
        }
        axios.post("https://localhost:5001/materials/Item/add",item)
        .then(res=>
            {
                $(div).css( "background-color", "green" ).text('Item Added').delay(1500)
                .slideUp(500,()=>{document.getElementById("buttonAdd").disabled =false });
                var item_=res.data;
                this.setState({
                    Id:undefined,
                    name:'',
                    company:'',
                    marketCode:'',
                    consumeUnit :'',
                },this.props.refreshCategoryList())
               
            }
            )
        .catch(err=>{
            $(div).css( "background-color", "red" ).text(ExtractErrorMessage(err))
            document.getElementById("buttonAdd").disabled =false
        }
        ); 

    }
    render() { 
        return (
            <div id='ItemAdd' style={{display:"none"}}>
                <div id="additem_displaymessage" className="App error-div">
                </div>
                {
                    (this.state.fetchCategoryDone==false)?'':
                    (this.state.Category==null)?
                    <div className="App" style={{backgroundColor:"#0dcaf0",padding:20}}>
                        <button className="btn btn-danger" onClick={this.fetchCategoryInfo}>Retry</button>
                    </div>:                                         
                    <div >
                        <div className="form-group" >
                            <label>Name:</label>
                            <input type="text" name="name"
                            required className="form-control" 
                            value={this.state.name}
                            onChange={this.onChangeInput}
                            />
                            <label>company:</label>
                            <input type="text" name="company"
                            required className="form-control" 
                            value={this.state.company}
                            onChange={this.onChangeInput}
                            />
                            <label>Market Code:</label>
                            <input type="text" name="marketCode"
                            required className="form-control" 
                            value={this.state.marketCode}
                            onChange={this.onChangeInput}
                            />
                            <label>Consume Unit</label>
                            <input type="text" name="consumeUnit"
                            required className="form-control" 
                            value={this.state.consumeUnit}
                            onChange={this.onChangeInput}
                            />
                        </div>  
                        <div className="form-group">
                            <button id='buttonAdd'  className="btn btn-primary" style={{margin:5}} onClick={this.addItem}>
                                Add </button>   
                        </div>
                    </div> 
                }
                
            </div>           
            
        );
    }
}
export default ItemAdd;