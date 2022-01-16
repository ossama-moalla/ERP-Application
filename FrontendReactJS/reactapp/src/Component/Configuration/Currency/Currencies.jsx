import React, { Component } from 'react';
import axios from 'axios'
class Currencies extends Component {
    constructor(){
        super();
        this.state={
            fetchDone:false,
            CurrecnyList:[]
        }
    }
    componentDidMount(){
        this.fetchCurrencies();
    }
    fetchCurrencies=()=>{

    }
    render() {
        return (
            <div>
                Currencies
            </div>
        );
    }
}

export default Currencies;