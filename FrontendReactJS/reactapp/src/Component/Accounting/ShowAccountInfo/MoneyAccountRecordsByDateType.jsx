import React, { Component } from 'react';

class MoneyAccountRecordsByDateType extends Component {
    
    render() {
        
        return (
            <div>
                <div>
                <button className="btn-flat color-wheat radius" >Add PayIN</button>
                <button className="btn-flat color-wheat radius" >Add PayOUT</button>
                <button className="btn-flat color-wheat radius" >Add Exchange OPR</button>
                <button className="btn-flat color-wheat radius" >Add Transform OPR</button>

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

export default MoneyAccountRecordsByDateType;