import React, { Component } from 'react';

class AccountDateTypeSelector extends Component {
    render() {
        return (
            <div >
                <label>Today Account:</label>
                <div className="div-inlineblock">
                    <button className="btn-flat color-cyan radius">&lt;</button>
                    <label className="color-yellow bordered">{new Date().toLocaleDateString()}</label>
                    <button className="btn-flat color-cyan radius">&gt;</button>

                </div>
                <button className="btn-flat color-cyan radius" style={{float:"right",marginTop:8}}>Month Account</button>

            </div>
        );
    }
}

export default AccountDateTypeSelector;