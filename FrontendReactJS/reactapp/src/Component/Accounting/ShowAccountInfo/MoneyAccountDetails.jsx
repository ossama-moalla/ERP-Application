import React, { Component } from 'react';
import PayIN_Add from '../PayIN/PayIN_Add.jsx';
import PayOUT_Add from '../PayOUT/PayOUT_Add.jsx'
import ExchangeOPR_Add from '../ExchangeOPR/ExchangeOPR_Add.jsx'
import MoneyTransformOPR_Add from '../MoneyTransformOPR/MoneyTransformOPR_Add.jsx'

class MoneyAccountDetails extends Component {
    constructor(props){
        console.log(props)
        super(props);
    }
    render() {
        
        return (
            <div>
                <div>
                <button className="btn-flat color-button radius"
                onClick={()=>
                    this.props.showPopUpComponent(
                    <PayIN_Add
                    closePopUpComponent={this.props.closePopUpComponent}
                    showPopUpComponent={this.props.showPopUpComponent}
                    />,'Add PayIN')} >Add PayIN</button>
                <button className="btn-flat color-button radius" 
                onClick={()=>
                    this.props.showPopUpComponent(
                    <PayOUT_Add    
                    closePopUpComponent={this.props.closePopUpComponent}
                    showPopUpComponent={this.props.showPopUpComponent}
                    />,'Add PayOUT')}>Add PayOUT</button>
                <button className="btn-flat color-button radius" 
                onClick={()=>
                    this.props.showPopUpComponent(
                    <ExchangeOPR_Add
                    closePopUpComponent={this.props.closePopUpComponent}
                    showPopUpComponent={this.props.showPopUpComponent}
                    />,'Add Exchange Operation')}>Add Exchange OPR</button>
                <button className="btn-flat color-button radius"
                onClick={()=>
                    this.props.showPopUpComponent(
                    <MoneyTransformOPR_Add
                    closePopUpComponent={this.props.closePopUpComponent}
                    showPopUpComponent={this.props.showPopUpComponent}
                    />,'Add MoneyTransform Operation')} >Add Transform OPR</button>

                </div>
                <div>
                    <label style={{width:'100%',marginTop:0}}>Details:</label>
                        <table className="table  table-bordered " style={{tableLayout:"fixed"}} >
                            <thead >
                            <tr className="color-cyan">
                                    <th  style={{width:40}}>Time </th>

                                    <th style={{width:65}}>Type</th>
                                    <th style={{width:65}}> Direction</th>
                                    <th style={{width:60}}> ID</th>
                                    <th style={{width:60}}> Value</th>
                                    <th style={{width:60}}>ExchangeRate</th>
                                    <th style={{width:60}}>Real Value</th>

                                    <th style={{width:125,whiteSpace:"unset",overflowWrap:"break-word"}}>Belong to</th>
                                    
                                </tr>
                            </thead>
                            <tbody>   
                                <tr>
                                    <th scope="row">1</th>
                                    <td>Mark</td>
                                    <td>Otto</td>
                                    <td>@mdo</td>
                                    <td>Mark</td>
                                    <td>Otto</td>
                                    <td>@mdo</td>
                                    <td>@mdo</td>
                                </tr>
                            </tbody>
                        </table>
                </div>
            </div>

        );
    }
}

export default MoneyAccountDetails;