import React,{ Component } from 'react';
import CurrencyReport from './CurrencyReport.jsx';
import ReportRecords from './ReportRecords.jsx'
import PayINAddEdit from '../PayIN/PayINAddEdit.jsx';
import PayOUTAdd from '../PayOUT/PayOUTAdd.jsx'
import ExchangeOPRAdd from '../ExchangeOPR/ExchangeOPRAdd.jsx'
import MoneyTransformOPRAdd from '../MoneyTransformOPR/MoneyTransformOPRAdd.jsx'
import axios from 'axios';
import { ExtractErrorMessage } from '../../../GeneralMethods.js';
import AccountSelector from './AccountSelector.jsx';

class MoneyAccountReport extends Component {
    constructor(props){
        super(props);
        const date=new Date();
        this.state={
            minYear:date.getFullYear()-2,
            maxYear:date.getFullYear()+2,
            year:date.getFullYear(),
            month:date.getMonth()+1,
            day:date.getDate(),

            fetchAccount_ReportDone:false,
            fetchAccount_ReportError:null,
            moneyAccount_Report_Records:[],
            moneyAccount_Report_Currency:[]            
        }
    }
    componentDidMount(){
        this.fetchReport();
    }
    accountDateUP=()=>{
        if(this.state.day!=null){
            this.setState({day:null},this.fetchReport)
        }
        else if(this.state.month!=null){
            this.setState({month:null},this.fetchReport)
        }
        else if(this.state.year!=null){
            this.setState({year:null},this.fetchReport)
        }
        else return;
    }
     accountDateDown=(value,type)=>{
        if(this.state.year==null){
            this.setState({year:value},this.fetchReport)
        }
        else if(this.state.month==null){
            this.setState({month:value},this.fetchReport)
        }
        else if(this.state.day==null){
            this.setState({day:value},this.fetchReport)
        }
        else {
            //open operation by value=id and getoperationtype from type
            return};
    }
    acountDateShift=(value)=>{
        if(this.state.day!=null){
                const newdate=new Date(
                    new Date(this.state.year,this.state.month-1,this.state.day).getTime()
                    +value* 60 * 60 * 24 * 1000);
                this.setState({
                    day:newdate.getDate(),
                    month:newdate.getMonth()+1,
                    year:newdate.getFullYear(),
                    minYear:newdate.getFullYear()-2,
                    maxYear:newdate.getFullYear()+2
                },this.fetchReport)
            }
            else if(this.state.month!=null){
                const newdate=new Date(this.state.year,this.state.month-1,1);
                newdate.setMonth(newdate.getMonth()+value);
                this.setState({
                    month:newdate.getMonth()+1,
                    year:newdate.getFullYear(),
                    minYear:newdate.getFullYear()-2,
                    maxYear:newdate.getFullYear()+2
                },this.fetchReport)
            }
            else if(this.state.year!=null){
                this.setState({
                    year:this.state.year+value,
                    minYear:this.state.year+value-2,
                    maxYear:this.state.year+value+2
                },this.fetchReport)
            }
            else {
                this.setState({
                    minYear:(value>0?this.state.minYear+4:this.state.minYear-4),
                    maxYear:(value>0?this.state.maxYear+4:this.state.maxYear-4)
                },this.fetchReport)

            }
    }
    fetchReport=async()=>{
        this.setState({
            fetchAccount_ReportDone:false,
            fetchAccount_ReportError:null,
            moneyAccount_Report:null
        });
        if(this.state.day!=null){
           await  axios.get("https://localhost:5001/Accounting/MoneyAccountReport/day_report?MoneyAccountId="
                +this.props.selectedMoneyAccountID+"&&day="+this.state.day+"&&month="+this.state.month
                +"&&year="+this.state.year)
            .then(res=>{ this.setState({
                fetchAccount_ReportDone:true,
                fetchAccount_ReportError:null,
                moneyAccount_Report_Records:res.data.operationsList,
                moneyAccount_Report_Currency:res.data.currencyReportList
                })}
            )
            .catch(err=>
                this.setState({
                    fetchAccount_ReportDone:true,
                    fetchAccount_ReportError:ExtractErrorMessage(err)
                })
            )
        }
        else if(this.state.month!=null){
            await  axios.get("https://localhost:5001/Accounting/MoneyAccountReport/month_report?MoneyAccountId="
                +this.props.selectedMoneyAccountID+"&&month="+this.state.month
                +"&&year="+this.state.year)
            .then(res=>this.setState({
                fetchAccount_ReportDone:true,
                fetchAccount_ReportError:null,
                moneyAccount_Report_Records:res.data.moneyAccountReport_InDay_List,
                moneyAccount_Report_Currency:res.data.currencyReportList
                })
            )
            .catch(err=>this.setState({
                fetchAccount_ReportDone:true,
                fetchAccount_ReportError:ExtractErrorMessage(err)
                })
            )           
        }
        else if(this.state.year!=null){
            await  axios.get("https://localhost:5001/Accounting/MoneyAccountReport/year_report?MoneyAccountId="
                +this.props.selectedMoneyAccountID +"&&year="+this.state.year)
            .then(res=>this.setState({
                fetchAccount_ReportDone:true,
                fetchAccount_ReportError:null,
                moneyAccount_Report_Records:res.data.moneyAccountReport_InMonth_List,
                moneyAccount_Report_Currency:res.data.currencyReportList
                })
            )
            .catch(err=>this.setState({
                fetchAccount_ReportDone:true,
                fetchAccount_ReportError:ExtractErrorMessage(err)
                })
            )              
         }
         else {
            await  axios.get("https://localhost:5001/Accounting/MoneyAccountReport/year_range_report?MoneyAccountId="
                +this.props.selectedMoneyAccountID
                +"&&year1="+this.state.minYear+"&&year2="+this.state.maxYear)
            .then(res=>this.setState({
                fetchAccount_ReportDone:true,
                fetchAccount_ReportError:null,
                moneyAccount_Report_Records:res.data.moneyAccountReport_InYear_List,
                moneyAccount_Report_Currency:res.data.currencyReportList
                })
            )
            .catch(err=>this.setState({
                fetchAccount_ReportDone:true,
                fetchAccount_ReportError:ExtractErrorMessage(err)
                })
            )              
         }
    }
    render(){
        const dateAccount={day:this.state.day,month:this.state.month,year:this.state.year}
        let accountType,accountDate;
        if(this.state.day!=null){
            accountDate=this.state.day+" - "+this.state.month+" - "+this.state.year
            accountType="Today Account";
        }
        else if(this.state.month!=null){ 
            accountDate=this.state.month+" - "+this.state.year
            accountType="Month Account";
        }
        else if(this.state.year!=null){
            accountDate=this.state.year
            accountType="Year Account";
        }
        else{
            accountDate=this.state.minYear+" - "+this.state.maxYear
            accountType="Year Range Account";
        }
        if(this.state.fetchAccount_ReportDone===false){
            return(
                <React.Fragment>
                    <AccountSelector accountDate={accountDate} accountType={accountType}
                                acountDateShift={this.acountDateShift} accountDateUP={this.accountDateUP}/>
                    <div  className="App" style={{padding:50}}>
                        Loading.......
                    </div>
                </React.Fragment>
            )
        }
        if(this.state.fetchAccount_ReportError){
            return(
                <React.Fragment>
                    <AccountSelector accountDate={accountDate} accountType={accountType}
                                acountDateShift={this.acountDateShift} accountDateUP={this.accountDateUP}/>       
                    <div  className="App error" >
                    {this.state.fetchAccount_ReportError}<br/>
                    <button className="btn btn-primary" onClick={this.fetchReport}>Retry</button>
                    </div>
                </React.Fragment>
            )
        }
        return (
            <React.Fragment>
                <AccountSelector accountDate={accountDate} accountType={accountType}
                                acountDateShift={this.acountDateShift} accountDateUP={this.accountDateUP}/>
                <div className="standalone-div borderbuttom">
                    {this.state.day&&(<div>
                    <button className="btn-flat color-button radius"
                    onClick={()=>
                        this.props.showPopUpComponent(
                        <PayINAddEdit
                        selectedMoneyAccountID={this.props.selectedMoneyAccountID}
                        fetchAccountInfo={this.props.fetchAccountInfo}
                        fetchReport={this.fetchReport}
                        currencyList={this.props.currencyList}
                        moneyAccountList={this.props.moneyAccountList}
                        closePopUpComponent={this.props.closePopUpComponent}
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

                    </div>)}
                    <ReportRecords dateAccount={dateAccount} accountDateDown={this.accountDateDown}
                    moneyAccount_Report_Records={this.state.moneyAccount_Report_Records}/>
                </div>
                <CurrencyReport moneyAccount_Report_Currency={this.state.moneyAccount_Report_Currency}/>
            </React.Fragment>
        );
    }
}

export default MoneyAccountReport;