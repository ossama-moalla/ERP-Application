import React from 'react';

const AccountSelector = (props) => {
    return (
        <div className="standalone-div borderbuttom ">
            <label>{props.accountType}:</label>
            <div className="div-inlineblock">
                <button className="btn-flat color-button radius"
                    onClick={()=>props.acountDateShift(-1)}>&lt;</button>
                <label className="color-yellow bordered">
                {props.accountDate}</label>
                <button className="btn-flat color-button radius"
                onClick={()=>props.acountDateShift(1)}>&gt;</button>

            </div>
            <button className="btn-flat color-button radius" 
            style={{float:"right",marginTop:8}} onClick={props.accountDateUP}>
                    Account UP
            </button>
        </div>
    );
};

export default AccountSelector;