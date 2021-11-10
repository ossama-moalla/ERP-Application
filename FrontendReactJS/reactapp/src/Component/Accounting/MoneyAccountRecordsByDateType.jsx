import React, { Component } from 'react';
import { connect } from 'react-redux';
function mapStateToProps(state) {
    return {

    };
}

class MoneyAccountRecordsByDateType extends Component {
    
    render() {
        
        return (
            <div>
                <label style={{border:'solid 1px rgba(61, 90, 94, 0.1)',width:'100%',marginTop:0}}>Details:</label>
                    <table className="table table-success table-bordered " style={{tableLayout:"fixed"}} >
                        <thead >
                            <tr  >
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
        );
    }
}

export default connect(
    mapStateToProps,
)(MoneyAccountRecordsByDateType);