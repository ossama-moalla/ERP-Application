import React, { Component } from 'react';
import { connect } from 'react-redux';

function mapStateToProps(state) {
    return {

    };
}

class MoneyAccountReportByDateType extends Component {
    render() {
        return (
            <div >
                <label style={{border:'solid 1px rgba(61, 90, 94, 0.1)',width:'100%',marginTop:0}}>Report:</label>
                <div >
                        <label className="btn-success" >Money In Value:75$</label>
                        <label className="btn-danger" >Money Out Value:80$</label>
                </div>
                <div >
                    <label className="btn-success" >Money In Real Value:75$</label>
                     <label className="btn-danger" >Money Out Real Value:80$</label>
                     <label className="btn-warning" >Real Clear Valuee:80$</label>

                </div>
                <div style={{overflow:'auto'}}>
                <table className="table table-bordered" style={{marginTop:10}}>
                    <thead>
                        <tr>
                            
                        <th scope="col" className="table-warning">Currency</th>
                        <th scope="col" className="bg-success">IN-Sales</th>
                        <th scope="col" className="bg-success">IN-Maintenance</th>
                        <th scope="col" className="bg-success">In-Transforms</th>
                        <th scope="col" className="bg-success">In-Exchange</th>
                        <th scope="col" className="bg-success">In-Others</th>
                        <th scope="col" className="bg-success">In-All</th>
                        <th scope="col" className="bg-danger">OUT-Purchases</th>
                        <th scope="col" className="bg-danger">OUT-Employees</th>
                        <th scope="col" className="bg-danger">OUT-Transforms</th>
                        <th scope="col" className="bg-danger">OUT-Exchange</th>
                        <th scope="col" className="bg-danger">OUT-Others</th>
                        <th scope="col" className="bg-danger">OUT-All</th>
                        <th scope="col" className="table-warning">Clear Value</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                        <th scope="row">1</th>
                        <td>454</td>
                        <td>45</td>
                        <td>454</td>
                        </tr>
                        <tr>
                        <th scope="row">2</th>
                        <td>5</td>
                        <td>555</td>
                        <td>4</td>
                        </tr>
                        <tr>
                        <th scope="row">3</th>
                        <td >45 </td>
                        <td>546</td>
                        </tr>
                    </tbody>
                </table>
                </div>
                
            </div>
        );
    }
}

export default connect(
    mapStateToProps,
)(MoneyAccountReportByDateType);