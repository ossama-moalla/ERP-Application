import React, { Component, Fragment } from 'react';
import axios from 'axios';
import $ from 'jquery'
import { ExtractErrorMessage,makeDragable } from '../../../GeneralMethods.js';

class ItemCategorySpecs extends Component {
    constructor(props){
        super(props);
        this.state={
            spec:{
                id:null,
                name:'',
                isRestricted:false,
                index:0    
            },
            speclist:[],
            VerifyError:{
                nameError:null,
                indexError:null
            }
            
        }
    }
    componentDidMount(){
        $('#specscontainer').fadeIn(500,this.refreshSpec);
    }
    refreshSpec=async()=>{
        let speclist=[],errorMessage='';
       await axios.get("https://localhost:5001/materials/ItemCategorySpec/list?categoryID="+this.props.Category.id)
        .then(res=> {speclist=res.data})
        .catch(err=>errorMessage+='Get Spec List Error:'+ExtractErrorMessage(err));
        
        if(errorMessage.length>0){
            document.getElementById("spec_displayerror").innerHTML=errorMessage
            $('#spec_displayerror').slideDown(500).delay(5000).slideUp('slow');

        }
        else{
            var index;
            if(speclist.length>0)
            index= speclist.reduce((p, c) => p.index > c.index ? p  : c ).index;
            else index=0;
    
            this.setState(prevstat=>({
                ...prevstat,
                spec:{
                    ...prevstat.spec,
                    index:index +1     
                },
                speclist:speclist
            }))
        }
        
    }
    
    ValidateInput=async()=>{
        
        const index=this.state.spec.index,name=this.state.spec.name;
        let nameError=null,indexError=null;
        if(isNaN(index)||index.toString().trim()==""){
                indexError="Index required and Must be Number";
        }
        if(name.trim()==""){
            nameError="name required and Must be not empty";
        }
        if(nameError!=null||indexError!=null){
            this.setState(prevstat=>({
                ...prevstat,
                VerifyError:{
                   nameError: nameError,
                   indexError:indexError
                }
                }));
                return;
        }
        const spec={
            id:this.state.spec.id,
            categoryID:this.props.Category.id,
            name:this.state.spec.name,
            isRestricted:this.state.spec.isRestricted,
            index:this.state.spec.index
        }

        axios.post("https://localhost:5001/materials/ItemCategorySpec/verifydata",spec)
        .then(res=>{
            this.setState(prevstat=>({
                ...prevstat,
                VerifyError:{
                   nameError: res.data.nameError,
                   indexError:res.data.indexError
                }
            }))
            })
        .catch(err=>{});
    }
    onChangeInput=async(e)=>{
        if(e.target.name=="isRestricted"){
            this.setState(prevState => ({
                ...prevState,
                spec: {
                         ...prevState.spec,
                         isRestricted:e.target.checked
                     }
             }));
        }
        else{   
            this.setState(prevState => ({
                ...prevState,
                spec: {
                        ...prevState.spec,
                        [e.target.name]:e.target.value
                    }
            }),this.ValidateInput);
        }
    }
    addSpec=async(e)=>{
        e.preventDefault();
        const spec={
            categoryID:this.props.Category.id,
            name:this.state.spec.name,
            isRestricted:this.state.spec.isRestricted,
            index:this.state.spec.index
        }
        console.log(spec)
        if(this.state.spec.name.trim()==""){
            document.getElementById("spec_displayerror").innerHTML='Spec Name Required'
            $('#spec_displayerror').slideDown(500).delay(5000).slideUp('slow');  
            return; 
        }
        await axios.post("https://localhost:5001/materials/ItemCategorySpec/add",spec)
        .then(res=>{
             this.setState(prevState => ({
            ...prevState,
            VerifyError:{
                nameError:null,
                indexError:null
            },
            spec: {
                     name:'',
                     index:'',
                     isRestricted:this.state.spec.isRestricted
                 }
         }),this.refreshSpec)})
        .catch(err=>{
            document.getElementById("spec_displayerror").innerHTML='Server Replay:'
            +ExtractErrorMessage(err)
            $('#spec_displayerror').slideDown(500).delay(5000).slideUp('slow'); });     
    }
    updateSpec=async()=>{
        {
            const spec={
                categoryID:this.props.Category.id,
                id:this.state.spec.id,
                name:this.state.spec.name,
                isRestricted:this.state.spec.isRestricted,
                index:this.state.spec.index
            }
            if(this.state.spec.name.trim()==""){
                document.getElementById("spec_displayerror").innerHTML='Spec Name Required'
                $('#spec_displayerror').slideDown(500).delay(5000).slideUp('slow');  
                return; 
            }
            await axios.put("https://localhost:5001/materials/ItemCategorySpec/update",spec)
            .then(res=>{
                 this.setState(prevState => ({
                ...prevState,
                VerifyError:{
                    nameError:null,
                    indexError:null
                },
                spec: {
                        id:null,
                         name:'',
                         index:'',
                         isRestricted:this.state.spec.isRestricted
                     }
             }),this.refreshSpec)})
            .catch(err=>{
                document.getElementById("spec_displayerror").innerHTML='Server Replay:'
                +ExtractErrorMessage(err)
                $('#spec_displayerror').slideDown(500).delay(5000).slideUp('slow'); });     
        } 
    }
    deleteSpec=(id,name)=>{
        if(id==null) return ;
        var d=window.confirm('are u sure you want to delete Spec:'+name+'?');
        if(d===false) return;
        axios.delete("https://localhost:5001/materials/ItemCategorySpec/delete?id="+id)
        .then(res=>this.setState(prevState=>({
            ...prevState,
            spec:{
                id:null,
                name:'',
                isRestricted:false,
            }
        }),()=>this.refreshSpec()) )
        .catch(err=>{
            document.getElementById("spec_displayerror").innerHTML='Server Replay:'+err.response.data
            $('#spec_displayerror').slideDown(500).delay(5000).slideUp('slow');
        });
    }
    render() {
        var displayErrorDivStyle={display:"none"};
        if(this.state.VerifyError.nameError!=null||this.state.VerifyError.indexError!=null) 
             displayErrorDivStyle={display:"block"};
        return (
            <div id='specscontainer' style={{display:"none"}}>
                <div id="spec_displayerror" className="App" 
                    style={{backgroundColor:"red",color:"white",display:"none"}}>
                </div>
                <div className="borderbuttom " style={{padding:5,backgroundColor:"#20505e" ,color:"#f8f9fa"}}>
                    <h5 >
                     Shared Item Specefication For Category : <strong>{this.props.Category.name}</strong>
                    </h5>
                </div>
                <div className="borderbuttom" >
                    <div className="div-inlineblock">
                        <label>Spec Name</label><br/>
                        <input type="text" name="name"
                        required 
                        value={this.state.spec.name}
                        onChange={this.onChangeInput} />
                        <div className='form-input-err' style={displayErrorDivStyle}>
                            <label>{this.state.VerifyError.nameError}</label></div>
                    </div>
                    
                    <div className="div-inlineblock">
                        <label>Index</label><br/>
                        <input type="text" name="index" style={{maxWidth:50}}
                        required 
                        value={this.state.spec.index}
                        onChange={this.onChangeInput}/>
                        <div className='form-input-err' style={displayErrorDivStyle}>
                            <label>{this.state.VerifyError.indexError}</label></div>
                    </div>
                    <div className="div-inlineblock">
                        <input type="checkbox" name="isRestricted"
                        required 
                        checked={this.state.spec.isRestricted}
                        onChange={this.onChangeInput} />
                        <label>IsRestricted</label>
                        <div className='form-input-err' style={displayErrorDivStyle}><label></label></div>

                    </div>
                    <div className="div-inlineblock">
                        {this.state.spec.id?
                            <Fragment>
                            <button className="btn btn-sm btn-primary" style={{marginRight:10}}
                             onClick={this.updateSpec} >Update </button>
                            <button className="btn btn-sm btn-primary" onClick={()=>{
                                this.setState(prevState=>({
                                    ...prevState,
                                    spec:{
                                        id:null,
                                        name:'',
                                        isRestricted:false,
                                        index:0    
                                    },
                                    VerifyError:{
                                        nameError:null,
                                        indexError:null
                                    }
                                }))
                            }} >Cancel </button>
                            </Fragment>:
                            <button className="btn btn-sm btn-primary" onClick={this.addSpec} >Add </button>
                        }
                        <div className='form-input-err' style={displayErrorDivStyle}><label></label></div>
                    </div>
                </div>  
                <div style={{clear:"both"}}></div>
                <div className="borderbuttom" style={{minHeight:100}}>
                    <table className="table" >
                        <thead>
                            <tr>
                                <th >Name</th>
                                <th >IS Restricted</th>
                                <th >Index in List</th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.speclist.map((spec)=>{
                                  return(
                                      <tr key={spec.id}
                                       style={{backgroundColor:spec.isRestricted?"coral":"bisque"}}>           
                                          <td>{spec.name}</td>
                                          <td>{spec.isRestricted?"True":"False"}</td>
                                          <td>{spec.index}</td>
                                          <td>
                                              <button className="btn-text" 
                                                onClick={()=>this.setState(prevState=>({
                                                    ...prevState,
                                                    spec:{
                                                    id:spec.id,
                                                    name:spec.name,
                                                    isRestricted:spec.isRestricted,
                                                    index:spec.index
                                                    }
                                                }))}>
                                                <i  className=" bi-pencil" style={{backgroundColor:"blue",
                                                color:"white"}}></i>
                                               </button>
                                               <button className="btn-text" 
                                                onClick={()=>this.deleteSpec(spec.id,spec.name)}>
                                                <i  className=" bi bi-x-lg" style={{backgroundColor:"red",
                                                 color:"white"}}></i>
                                               </button>
                                          </td>
                                      </tr>
                                  )      
                            })}
                        </tbody>
                    </table>
                </div>
                <button className="btn  btn-primary " 
                    style={{top:2,left:5}} 
                    onClick={()=>{
                        $('#specscontainer').fadeOut(400,this.props.Return)}}>
                        Finish
                    </button>
            </div>                    
            
        );
    }
}

export default ItemCategorySpecs;