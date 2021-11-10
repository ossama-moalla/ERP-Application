import React, { Component } from "react";
import { connect } from "react-redux";
import MoneyAccountInfo from "./MoneyAccountInfo";
import Account_DataType_Selector from './Account_DateType_Selector.jsx';
import MoneyAccountRecordsByDateType from './MoneyAccountRecordsByDateType.jsx';
import MoneyAccountReportByDateType from "./MoneyAccountReportByDateType.jsx";
import './Styles.css'
function mapStateToProps(state) {
  return {};
}

class MoneyAccountWindow extends Component {
  render() {
    return (
      <div>
        <div className="div-container">
          <MoneyAccountInfo />
          <Account_DataType_Selector />
          <MoneyAccountRecordsByDateType/>
          <MoneyAccountReportByDateType/>
        </div>
 
      </div>
    );
  }
}

export default connect(mapStateToProps)(MoneyAccountWindow);
