import React from 'react';

const MoneyAccountInfo = (props) => {
    if(props.fetchAccountInfoDone===false){
        return (
            <div className="standalone-div borderbuttom App">
                Loading Account Info....
            </div>
        )
    }
    if(props.fetchAccountInfoError){
        return(
            <div  className="standalone-div borderbuttom App error" >
                Loading Account Info Error:{props.fetchAccountInfoError}<br/>
                <button className="btn btn-primary" onClick={props.fetchAccountInfo}>Retry</button>
            </div>
        )
    }
    return (
        <div className="standalone-div borderbuttom"> 
            <div className="App">
                <label className="color-yellow radius" style={{marginBottom:5}}>
                    Money Account Value:{props.moneyAccountValue?
                    props.moneyAccountValue:
                    'Account is empty '}
                </label>
            </div>                   
            <div className="App">                
                <label className="btn-success radius"  style={{marginRight:20}}>Incomming Money Transform Operation:0</label>
                <label className="btn-danger radius">OutGoing Money Transform Operation:0</label>
            </div>
        </div>
    );
};

export default MoneyAccountInfo;