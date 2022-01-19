import React, { Component } from 'react';
import  axios from 'axios'
import { Fragment } from 'react';
class SpecFilter extends Component {
    constructor(props){
        super(props)
        this.state={
            fetchdone:false,
            SpecList:[],
        }
    }
    getSpecs=async ()=>{
        if(this.props.currentCategoryID==null) {
            this.setState({SpecList:[],fetchdone:true});
            return;
        }
        this.setState({SpecList:[],fetchdone:false});
        await axios.get("https://localhost:5001/materials/ItemCategorySpec/list?categoryID="+this.props.currentCategoryID)
        .then(res=>this.setState({SpecList:res.data,fetchdone:true}))
        .catch(err=>console.log(err));
    
    }
    shouldComponentUpdate(nextProps, nextState){
        if(this.props.currentCategoryID===nextProps.currentCategoryID
            &&this.state.fetchdone===nextState.fetchdone) {
                return false;}
        else {
            return true;
        }
    }
    componentDidMount(){
        this.getSpecs();
    }
    componentDidUpdate=async(prevProps)=>{
        if(this.props.currentCategoryID!==prevProps.currentCategoryID){
            this.getSpecs();
        }
    }
    render(){
        if(this.props.currentCategoryID===null){
            return (
                <Fragment>
                    <label>Root Category not have Spec</label>
                </Fragment>                  
            )
        }   
        if(this.state.fetchdone===false) return(<div>Loading...</div>);
        return(
            <Fragment>
            {
                    (this.state.SpecList.length===0)?"No Spec's Entered":
                    (<Fragment>
                        {this.state.SpecList.map((spec)=>{
                        return(
                        <Fragment  key={spec.id}>
                            <label >{spec.name}</label><br/>
                            {
                                 spec.isRestricted?<select style={{width:"100%"}}></select>:
                                 <input  type="text"/>
                            }
                            <br/>
                        </Fragment>
                            )
                    })}
                    </Fragment> 
                    )
                }
            </Fragment>
        )
    }
    
    
}

export default SpecFilter;
