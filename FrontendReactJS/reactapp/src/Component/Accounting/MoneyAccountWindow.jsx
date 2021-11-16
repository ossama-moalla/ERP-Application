import React, { Component } from "react";
import { connect } from "react-redux";
import MoneyAccountInfo from "./MoneyAccountInfo";
import AccountDataTypeSelector from './Account_DateType_Selector.jsx';
import MoneyAccountRecordsByDateType from './MoneyAccountRecordsByDateType.jsx';
import MoneyAccountReportByDateType from "./MoneyAccountReportByDateType.jsx";

function mapStateToProps(state) {
  return {};
}

class MoneyAccountWindow extends Component {
  render() {
    return (
      <div>
        <div className="div-container">
          <MoneyAccountInfo />
          <AccountDataTypeSelector />
          <MoneyAccountRecordsByDateType/>
          <MoneyAccountReportByDateType/>
        </div>
 
      </div>
    );
  }
}

export default connect(mapStateToProps)(MoneyAccountWindow);
