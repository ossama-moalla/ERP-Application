import React, { Component } from 'react';

class MoneyAccountReportByDateType extends Component {
    render() {
        return (
            <div >
                <label style={{border:'solid 1px rgba(61, 90, 94, 0.1)',width:'100%',marginTop:0}}>Report:</label>
                <div >
                        <label className="btn-success radius" >Money In Value:75$</label>
                        <label className="btn-danger radius" >Money Out Value:80$</label>
                </div>
                <div >
                    <label className="btn-success radius" >Money In Real Value:75$</label>
                     <label className="btn-danger radius" >Money Out Real Value:80$</label>
                     <label className="btn-warning radius" >Real Clear Valuee:80$</label>

                </div>
                <div style={{overflow:'auto',marginTop:10}}>
                    <table className="table table-bordered">
                        <thead>
                        <tr className="color-cyan">
                            <th colspan="2" >currency</th>
                            <th >Syrian bound</th>
                            <th >Dollar</th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr className="bg-success">
                            <td  rowSpan="6">IN</td>
                            <td >Sales</td>
                            <td>5</td>
                            <td>10</td>
                        </tr>
                        <tr className="bg-success">
                            <td >Maintenance</td>
                            <td>5</td>
                            <td>10</td>
                        </tr>
                        <tr className="bg-success">
                            <td  >Transforms</td>
                            <td>5</td>
                            <td>10</td>
                        </tr>
                        <tr className="bg-success">
                            <td >Exchange</td>
                            <td>5</td>
                            <td>10</td>
                        </tr>
                        <tr className="bg-success">
                            <td >Otders</td>
                            <td>5</td>
                            <td>10</td>
                        </tr>
                        <tr className="bg-success">
                            <td >All</td>
                            <td>5</td>
                            <td>10</td>
                        </tr>
                        <tr className="bg-danger">
                        <td  rowSpan="6">OUT</td>
                            <td >Purchases</td>
                            <td>5</td>
                            <td>10</td>
                        </tr>
                        <tr className="bg-danger">
                            <td >Employees</td>
                            <td>5</td>
                            <td>10</td>
                        </tr>
                        <tr className="bg-danger">
                            <td scope="row" >Transforms</td>
                            <td>5</td>
                            <td>10</td>
                        </tr>
                        <tr className="bg-danger">
                            <td >Exchange</td>
                            <td>5</td>
                            <td>10</td>
                        </tr>
                        <tr className="bg-danger">
                            <td >Otders</td>
                            <td>5</td>
                            <td>10</td>
                        </tr>
                        <tr className="bg-danger">
                            <td >All</td>
                            <td>5</td>
                            <td>10</td>
                        </tr>
                        <tr className="color-yellow">
                            <td colspan="2">Clear Value</td>
                            <td>5</td>
                            <td>10</td>
                        </tr>
                        </tbody>
                        
                    </table>
                </div>
                
            </div>
        );
    }
}

export default MoneyAccountReportByDateType;