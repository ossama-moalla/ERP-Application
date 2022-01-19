import React, { Component } from 'react';

class MoneyAccountType extends Component {
    render() {
        return (
            <div >
                <label>Today Account:</label>
                <div className="div-inlineblock">
                    <button className="btn-flat color-button radius">&lt;</button>
                    <label className="color-yellow bordered">{new Date().toLocaleDateString()}</label>
                    <button className="btn-flat color-button radius">&gt;</button>

                </div>
                <button className="btn-flat color-button radius" style={{float:"right",marginTop:8}}>Month Account</button>

            </div>
        );
    }
}

export default MoneyAccountType;