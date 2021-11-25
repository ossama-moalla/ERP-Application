import React, { Component } from 'react';
import { connect } from 'react-redux';
import {Provider} from 'redux'
function mapStateToProps(state) {
    return {

    };
}

const ruducer=(state={},action)=>{

}
class MaterialsMainWindow extends Component {
    render() {
        return (
            <div>
                <Provider>
                    
                </Provider>
                
            </div>
        );
    }
}

export default connect(
    mapStateToProps,
)(MaterialsMainWindow);