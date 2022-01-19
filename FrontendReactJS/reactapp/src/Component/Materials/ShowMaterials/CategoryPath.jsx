import React, { Component } from 'react';
import axios  from 'axios';
import {ExtractErrorMessage} from '../../../GeneralMethods.js'
import { Link } from 'react-router-dom';
class CategoryPath extends Component {
    constructor(props){
        super(props);
        this.state={
            PathList:null,
            Error:null
        }
    }
    updatePath=()=>{
        if(this.props.currentCategoryID===null)
        this.setState({PathList:[]});
        else{
            axios.get("https://localhost:5001/materials/ItemCategory/path?id="+this.props.currentCategoryID)
            .then(res=> { this.setState({ PathList:res.data.reverse()})})
            .catch(err=>this.setState({Error:ExtractErrorMessage(err)}));
        }   
    }
    componentDidMount(){
        this.updatePath();
    }
    componentDidUpdate(prevProps){
        if(this.props.currentCategoryID !==prevProps.currentCategoryID)
        {
            this.updatePath();
        }
        
    }
    render() {

        if(this.state.Error)
        return(<div className="App" style={{color:"red"}}>{this.state.Error}</div>)
        if(this.state.PathList===null)
             return(<div className="App" >Loading......</div>);
        return (
            <React.Fragment>
                <img src={process.env.PUBLIC_URL + '/home.png'} alt="" style={{width:20,height:20,marginTop:-8}}></img>
                <Link to='#' style={{textDecoration:"none"}} 
                onClick={()=>{this.props.openCategory(null,true,true)}}>ROOT</Link>/
                {
                    this.state.PathList.map(category=>
                        <React.Fragment key={category.id}>
                            <Link to='' style={{textDecoration:"none"}} 
                            onClick={()=>{this.props.openCategory(category.id,true,true)}}>{category.name}</Link>/
                        </React.Fragment>
                    )
                }

              </React.Fragment>

        );
    }
}

export default CategoryPath;