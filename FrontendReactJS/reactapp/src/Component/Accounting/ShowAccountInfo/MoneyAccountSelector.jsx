import React, { Component, Fragment } from 'react';

class MoneyAccountSelector extends Component {
    
    render() {
        
        return (
                <Fragment>
                    <div >
                        <div className="div-inlineblock" style={{marginRight:20}}>
                            <label >MoneyAccounts:</label><br/>
                            <select className="bordered color-yellow" style={{fontWeight:"bold"}}>
                                <option>No Money Account Configured</option>
                            </select  >
                        </div>
                        <label className="color-yellow radius" style={{marginBottom:5}}>
                            {this.props.moneyAccountValue?
                            this.props.moneyAccountValue:
                            'Account is empty Account is emptyAccount is empty'}
                        </label>
                       
                     
                    </div>
                    <div >
                      <label className="btn-success radius"  style={{marginRight:20}}>Incomming Money Transform Operation:0</label>
                      <label className="btn-danger radius">OutGoing Money Transform Operation:0</label>
                    </div>
    
                </Fragment>
        );
    }
}

export default MoneyAccountSelector;