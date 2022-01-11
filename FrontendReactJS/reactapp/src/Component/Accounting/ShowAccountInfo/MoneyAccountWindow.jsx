import React, { Component } from "react";
import MoneyAccountSelector from "./MoneyAccountSelector";
import AccountDateTypeSelector from "./AccountDateTypeSelector.jsx";
//import AccountDateTypeSelector from "./AccountDateTypeSelector.jsx";

import MoneyAccountRecordsByDateType from './MoneyAccountRecordsByDateType.jsx';
import MoneyAccountReportByDateType from "./MoneyAccountReportByDateType.jsx";


class MoneyAccountWindow extends Component {
  render() {
    return (
      <div className="main-component ">
          <div className="standalone-div borderbuttom">
              <MoneyAccountSelector />
          </div>
          <div className="standalone-div borderbuttom">
              <AccountDateTypeSelector />
          </div>
          <div className="standalone-div borderbuttom">
              <MoneyAccountRecordsByDateType/>
          </div>
          <div className="standalone-div borderbuttom">
              <MoneyAccountReportByDateType/>
          </div>
      </div>
    );
  }
}

export default MoneyAccountWindow;
