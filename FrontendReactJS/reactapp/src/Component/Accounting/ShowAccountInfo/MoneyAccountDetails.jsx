import React, { Component } from 'react';
import PayINAddEdit from '../PayIN/PayINAddEdit.jsx';
import PayOUTAdd from '../PayOUT/PayOUTAdd.jsx'
import ExchangeOPRAdd from '../ExchangeOPR/ExchangeOPRAdd.jsx'
import MoneyTransformOPRAdd from '../MoneyTransformOPR/MoneyTransformOPRAdd.jsx'

class MoneyAccountDetails extends Component {
    constructor(props){
        super(props);
        this.state={
            fetchDone:false,

        }
    }
    render() {
        
        return (
            <div>
                <div>
                <button className="btn-flat color-button radius"
                onClick={()=>
                    this.props.showPopUpComponent(
                    <PayINAddEdit
                    selectedMoneyAccountID={this.props.selectedMoneyAccountID}
                    currencyList={this.props.currencyList}
                    moneyAccountList={this.props.moneyAccountList}
                    closePopUpComponent={this.props.closePopUpComponent}
                    showPopUpComponent={this.props.showPopUpComponent}
                    />,'Add PayIN')} >Add PayIN</button>
                <button className="btn-flat color-button radius" 
                onClick={()=>
                    this.props.showPopUpComponent(
                    <PayOUTAdd    
                    closePopUpComponent={this.props.closePopUpComponent}
                    showPopUpComponent={this.props.showPopUpComponent}
                    />,'Add PayOUT')}>Add PayOUT</button>
                <button className="btn-flat color-button radius" 
                onClick={()=>
                    this.props.showPopUpComponent(
                    <ExchangeOPRAdd
                    closePopUpComponent={this.props.closePopUpComponent}
                    showPopUpComponent={this.props.showPopUpComponent}
                    />,'Add Exchange Operation')}>Add Exchange OPR</button>
                <button className="btn-flat color-button radius"
                onClick={()=>
                    this.props.showPopUpComponent(
                    <MoneyTransformOPRAdd
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