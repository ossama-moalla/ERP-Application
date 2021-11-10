import React, { Component } from 'react';
import { connect } from 'react-redux';
import './Styles.css'
function mapStateToProps(state) {
    return {

    };
}

class Account_DateType_Selector extends Component {
    render() {
        return (
            <div >
                <button>Upper</button>
                <label>Today Account:</label>
                <button>&lt;</button>
                <label>{new Date().toLocaleDateString()}</label>
                <button>&gt;</button>

            </div>
        );
    }
}

export default connect(
    mapStateToProps,
)(Account_DateType_Selector);