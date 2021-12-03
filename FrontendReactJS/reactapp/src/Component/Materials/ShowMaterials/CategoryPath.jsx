import React, {Fragment, Component } from 'react';
import axios  from 'axios';
import { Link } from 'react-router-dom';
class CategoryPath extends Component {
    constructor(props){
        super(props);
        this.state={
            currentCategoryID:props.currentCategoryID,
            PathList:null,
            Error:null
        }
    }
    componentDidMount(){
        if(this.state.currentCategoryID==null)
             this.setState({PathList:[]})
        else{
            axios.get("https://localhost:5001/materials/ItemCategory/path?id="+this.state.currentCategoryID)
            .then(res=> { this.setState({ PathList:res.data})})
            .catch(err=>this.setState({Error:err.message}));
        }
    }
    render() {
        if(this.state.Error)
        return(<div className="App" style={{color:"red"}}>{this.state.Error}</div>)
        if(this.state.PathList==null)
             return(<div className="App" >Loading......</div>);
        return (
            <React.Fragment>
                <img src={process.env.PUBLIC_URL + '/home.png'} style={{width:20,height:20,marginTop:-8}}></img>
                <Link to='#' style={{textDecoration:"none"}} onClick={()=>{this.props.onClick(null)}}>ROOT</Link>/
                {
                    this.state.PathList.reverse().map(category=>
                        <React.Fragment key={category.id}>
                            <Link to='' style={{textDecoration:"none"}} 
                            onClick={()=>{this.props.onClick(category.id)}}>{category.name}</Link>/
                        </React.Fragment>
                    )
                }

              </React.Fragment>

        );
    }
}

export default CategoryPath;