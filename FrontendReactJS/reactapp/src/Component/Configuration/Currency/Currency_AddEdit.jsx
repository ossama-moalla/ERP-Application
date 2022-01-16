import React, { Component } from 'react';

class Currency_AddEdit extends Component {
    constructor(props){
        super(props);
        if(props.Currency){
            this.state={...props.Currency}
        }else{
            this.state={
                Id:undefined,
                Name:'',
                Symbol:'',
                ExchangeRate:1,
                Disabled:false
            }
        }
        
    }
    render() {
        return (
            <div>
                
            </div>
        );
    }
}

export default Currency_AddEdit;