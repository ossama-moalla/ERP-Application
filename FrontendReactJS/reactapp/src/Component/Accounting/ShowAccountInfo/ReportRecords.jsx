import React from 'react';
const ReportRecords = (props) => {
    if(props.moneyAccount_Report_Records.length===0){
        return (
            <div>
                <label className="color-blue" style={{outline:'solid 1px rgba(61, 90, 94, 0.1)'
                        ,fontWeight:"bold",width:'100%',marginTop:0,marginLeft:2}}>Details:</label>
                        
                    <div className="App color-yellow">
                        
                        No Data Found!
                    </div>
            </div>
        )
    }
    let tableHeader,tableRecords;
    if(props.dateAccount.day!=null){
        tableHeader=
            <thead className="color-blue" style={{textAlign:"center"}}>
                 <tr >
                    <th  style={{width:50}}>Time </th>
                    <th style={{width:65}}>Type</th>
                    <th style={{width:65}}> Direction</th>
                    <th style={{width:40}}> ID</th>
                    <th style={{width:60}}> Currency</th>
                    <th style={{width:60}}> Value</th>
                    <th style={{width:60}}>ExchangeRate</th>
                    <th style={{width:60}}>Real Value($)</th>
                    <th style={{width:100,whiteSpace:"unset",overflowWrap:"break-word"}}>Details</th> 
                </tr>
            </thead>;
           
            tableRecords=props.moneyAccount_Report_Records.map((operation,index)=>{
                const date=new Date(operation.date);
                let type;
                let classname=" tablerow-button font-white ";
                switch(operation.oprType){
                    case 0:
                        type="Pay OPR";
                        if(operation.oprDirection===0)    
                            classname="color-green"+classname;
                        else
                            classname="color-red"+classname;
                        break;
                    case 1:type="Exchange OPR";classname="color-goldenrod"+classname;break;
                    case 2:type="Money Transform OPR";classname="color-cadetblue"+classname;break;
                    default:type="unknown"
                }
                return(
                    <tr   className={classname} key={index}
                     onClick={()=>props.accountDateDown(operation.id,operation)}>
                        <td>{date.getHours()+":"+date.getMinutes()}</td>
                        <td>{type}</td>
                        <td>{operation.oprDirection===0?"IN":"OUT"}</td>
                        <td>{operation.id}</td>
                        <td>{operation.currencyName}</td>
                        <td>{operation.value+" "+operation.currencySymbol}</td>     
                        <td>{operation.exchangeRate}</td>
                        <td>{operation.realValue}</td>
                        <td>{operation.details}</td>
                    </tr>
                )
            }
            )

    }
    else {
        let firstColumnName;
        if(props.dateAccount.month!=null){
            firstColumnName='Day';
        }
        else if(props.dateAccount.year!=null){
            firstColumnName='Month';
        }
        else {
            firstColumnName='Year';
        }
        tableHeader=
            <thead className="color-blue" style={{textAlign:"center"}}>
                <tr >
                    <th  rowSpan="2">{firstColumnName} </th>
                    <th style={{width:500}} colSpan="5">Operations Count</th>
                    <th  colSpan="2">Money IN </th>
                    <th  colSpan="2">Money OUT </th>
                </tr>
                <tr >
                    <th style={{width:50}}>PayIN</th>
                    <th style={{width:55}}>PayOUT</th>
                    <th style={{width:70}}>Exchange</th>
                    <th style={{width:80}}>Transform IN</th>
                    <th style={{width:80}}>Transform OUT</th>
                    <th style={{width:80}}>Value</th>
                    <th style={{width:90}}>Real Value</th>
                    <th style={{width:80}}>Value</th>
                    <th style={{width:90}}>Real Value</th>
                </tr>
            </thead>
            ;
            let firstCellName,firstCellValue;
            if(props.dateAccount.month!=null){
                firstCellName='dateDayNo';
                firstCellValue='dateDayNo';
            }
            else if(props.dateAccount.year!=null){
                firstCellName='year_Month_Name';
                firstCellValue='year_Month';
            }
            else {
                firstCellName='year';
                firstCellValue='year';
            }
            tableRecords=props.moneyAccount_Report_Records.map((report,index)=>{
                
                let classname="tablerow-button  font-white ";
                if(report.moneyIN_Real_Value>0||report.moneyOUT_Real_Value>0){
                    if(report.moneyIN_Real_Value>report.moneyOUT_Real_Value){
                        classname+="color-green"
                    }
                    else{
                        classname+="color-red"
                    }
                }
                else{
                    classname+="color-gray-dark";
                }
                return(
                    <tr   className={classname} key={index}
                     onClick={()=>props.accountDateDown(report[firstCellValue])}>
                        <td>{report[firstCellName]}</td>
                        <td>{report.paysIN_Count}</td>
                        <td>{report.paysOUT_Count}</td>
                        <td>{report.exchangeOPR_Count}</td>
                        <td>{report.moneyTransform_IN_Count}</td>
                        <td>{report.moneyTransform_OUT_Count}</td>     
                        <td>{report.moneyIN_Value}</td>
                        <td>{report.moneyIN_Real_Value}</td>
                        <td>{report.moneyOUT_Value}</td>
                        <td>{report.moneyOUT_Real_Value}</td>
                    </tr>
                )
            }
            )

    }
    
    return (
        <div>
            <label className="color-blue" style={{outline:'solid 1px rgba(61, 90, 94, 0.1)'
            ,fontWeight:"bold",width:'100%',marginTop:0,marginLeft:2}}>Details:</label>
                <table className="table  table-bordered " style={{tableLayout:"fixed"}} >
                    {tableHeader}
                    <tbody>   
                        {tableRecords}
                    </tbody>
                </table>
        </div>
    );
};

export default ReportRecords;