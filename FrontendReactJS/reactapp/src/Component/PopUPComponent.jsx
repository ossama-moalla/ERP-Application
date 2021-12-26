import $ from 'jquery';
import {useEffect} from 'react';
import {makeDragable} from '../GeneralMethods.js'

import React, { Component } from 'react';

class PopUPComponent extends Component {
    componentDidMount(){
        makeDragable('#movehandle','#popup-component')
    }
    render() {
        return (
        <div id="popup-component"  className="new-window bordered"
            style={{left:"calc((100% - 550px)/2)",minWidth:600,maxWidth:600, backgroundColor:"#e9ecef"}}>
            <div className="title-bar ">
                <div id='movehandle'   className='move-handler' style={{padding:5}}>{this.props.popUpComponent.title}</div>
            <button className="btn btn-sm btn-primary"  style={{top:2,right:5}}
                onClick={()=>{$('#popup-component').fadeOut(500,this.props.closePopUpComponent);}}>x
            </button>
            </div>
            {this. props.popUpComponent.component}
        </div>
        );
    }
}
export default PopUPComponent;