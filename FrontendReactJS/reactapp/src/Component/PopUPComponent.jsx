import $ from 'jquery';
import {makeDragable} from '../GeneralMethods.js'

import React, { Component } from 'react';

class PopUPComponent extends Component {
    componentDidMount(){
        $('#popupcomponent').fadeIn(500)
        makeDragable('#movehandle','#popupcomponent');
    }
    render() {
        return (
        <div id="popupcomponent"  className="new-window bordered"
            style={{display:'none', left:"calc((100% - 550px)/2)",
            minWidth:600,maxWidth:600, backgroundColor:"#e9ecef"}}>
            <div className="title-bar ">
                <div id='movehandle'   className='move-handler' style={{padding:5}}>{this.props.popUpComponent.title}</div>
            <button className="btn btn-sm btn-primary"  style={{top:2,right:5}}
                onClick={()=>{$('#popupcomponent').fadeOut(500,this.props.closePopUpComponent);}}>x
            </button>
            </div>
            {this.props.popUpComponent.component}
        </div>
        );
    }
}
export default PopUPComponent;