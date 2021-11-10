import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';

function mapStateToProps(state) {
    return {

    };
}

class MoneyAccountInfo extends Component {
    
    render() {
        
        return (
                <Fragment>
                    <div className="div-child-style">
                        <label >MoneyAccounts:</label>
                        <select >
                            <option>No Money Account Configured</option>
                        </select  >
                        <label className="btn-success">{this.props.moneyAccountValue?this.props.moneyAccountValue:'Account is empty Account is emptyAccount is empty'}</label>
                       
                     
                    </div>
                    <div >
                      <label className="btn-success">Incomming Money Transform Operation:0</label>
                      <label className="btn-danger">Incomming Money Transform Operation:0</label>
                    </div>
    
                </Fragment>
        );
    }
}

export default connect(
    mapStateToProps,
)(MoneyAccountInfo);