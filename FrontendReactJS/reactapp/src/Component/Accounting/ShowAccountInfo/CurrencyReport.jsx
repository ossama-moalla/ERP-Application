import React from 'react';

const CurrencyReport =(props)=> {
    if(props.moneyAccount_Report_Currency.length===0){
        return (
            <div className="standalone-div borderbuttom">
                <label className="color-blue" style={{outline:'solid 1px rgba(61, 90, 94, 0.1)'
                        ,fontWeight:"bold",width:'100%',marginTop:0,marginLeft:2}}>Details:</label>
                        
                    <div className="App color-yellow">
                        
                        No Data Found!
                    </div>
            </div>
        )
    }
    const css_moneyin_class="color-green font-white";
    const css_moneyout_class="color-red font-white";
    return (
        <div className="standalone-div borderbuttom">
            <label className="color-blue" style={{border:'solid 1px rgba(61, 90, 94, 0.1)'
            ,fontWeight:"bold",width:'100%',marginTop:0}}>Currency Report:</label>
            
            <div style={{overflow:'auto',marginTop:10}}>
                <table className="table table-bordered" style={{textAlign:"center"}}>
                <thead>
                        <tr className="color-blue">
                            <th  style={{width:50}}></th>
                            <th  style={{width:150}}></th>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               { return(<th key={index}>{report.currencyName}</th>)})}   
                        </tr>
                        </thead>
                        <tbody>
                        <tr style={{height:7}}></tr>
                        <tr className={css_moneyin_class}>
                            <td  rowSpan="6">IN</td>
                            <td >Sales</td>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               { return(<td key={index}>{report.moneyIN_FromSells+" "+report.currencySymbol}</td>)})}
                        </tr>
                        <tr className={css_moneyin_class}>
                            <td >Maintenance</td>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               { return(<td key={index}>{report.moneyIN_FromMaintenance+" "+report.currencySymbol}</td>)})}
                        </tr>
                        <tr className={css_moneyin_class}>
                            <td  >Transforms</td>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               { return(<td key={index}>{report.moneyIN_FromMoneyTransform+" "+report.currencySymbol}</td>)})}
                        </tr>
                        <tr className={css_moneyin_class}>
                            <td >Exchange</td>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               { return(<td key={index}>{report.moneyIN_FromExchangeOPR+" "+report.currencySymbol}</td>)})}
                        </tr>
                        <tr className={css_moneyin_class}>
                            <td >Others</td>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               { return(<td key={index}>{report.moneyIN_FromOther+" "+report.currencySymbol}</td>)})}
                        </tr>
                        <tr className={css_moneyin_class}>
                            <td >All</td>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               { return(<td key={index}>{(report.moneyIN_FromSells+report.moneyIN_FromMaintenance
                               +report.moneyIN_FromMoneyTransform+report.moneyIN_FromExchangeOPR
                               +report.moneyIN_FromOther)+" "+report.currencySymbol}</td>)})}
                        </tr>
                        <tr style={{height:7}}></tr>
                        <tr className={css_moneyout_class}>
                        <td  rowSpan="6">OUT</td>
                            <td >Purchases</td>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               { return(<td key={index}>{report.moneyOUT_ByBuy+" "+report.currencySymbol}</td>)})}
                        </tr>
                        <tr className={css_moneyout_class}>
                            <td >Employees</td>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               { return(<td key={index}>{report.moneyOUT_ByEmpPayOrders+" "+report.currencySymbol}</td>)})}
                        </tr>
                        <tr className={css_moneyout_class}>
                            <td>Transforms</td>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               { return(<td key={index}>{report.moneyOUT_ByMoneyTransform+" "+report.currencySymbol}</td>)})}
                        </tr>
                        <tr className={css_moneyout_class}>
                            <td >Exchange</td>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               { return(<td key={index}>{report.moneyOUT_ByExchangeOPR+" "+report.currencySymbol}</td>)})}
                        </tr>
                        <tr className={css_moneyout_class}>
                            <td >Others</td>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               { return(<td key={index}>{report.moneyOUT_ByOther+" "+report.currencySymbol}</td>)})}
                        </tr>
                        <tr className={css_moneyout_class}>
                            <td >All</td>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               { return(<td key={index}>{(report.moneyOUT_ByBuy+report.moneyOUT_ByEmpPayOrders
                               +report.moneyOUT_ByMoneyTransform +report.moneyOUT_ByExchangeOPR
                                +report.moneyOUT_ByOther)+" "+report.currencySymbol}</td>)})}
                        </tr>
                        <tr style={{height:7}}></tr>
                        <tr className="color-yellow">
                            <td colSpan="2">Clear Value</td>
                            {props.moneyAccount_Report_Currency.map((report,index)=>
                               {
                                   const value=((report.moneyIN_FromSells+report.moneyIN_FromMaintenance
                                    +report.moneyIN_FromMoneyTransform+report.moneyIN_FromExchangeOPR
                                    +report.moneyIN_FromOther)-(report.moneyOUT_ByBuy+report.moneyOUT_ByEmpPayOrders
                                    +report.moneyOUT_ByMoneyTransform +report.moneyOUT_ByExchangeOPR
                                     +report.moneyOUT_ByOther));
                                     let colorstyle;
                                     if(value>0) colorstyle="td-moneyin";
                                     else if(value<0) colorstyle="td-moneyout";
                                     else colorstyle="color-yellow";
                                      return(<td className={colorstyle} key={index}>{value+" "+report.currencySymbol}</td>)})}
                        </tr>
                        </tbody>
                        
                </table>
                
            </div>
            
        </div>
    );
}

export default CurrencyReport;