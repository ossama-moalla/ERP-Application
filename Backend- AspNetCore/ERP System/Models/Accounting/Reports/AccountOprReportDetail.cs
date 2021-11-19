using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting.Reports
{
    public class AccountOprReportDetail
    {
        public const bool DIRECTION_IN = false;
        public const bool DIRECTION_OUT = true;

        public const int TYPE_PAY_OPR = 0;
        public const int TYPE_EXCHANGE_OPR = 1;
        public const int TYPE_MoneyTransform_OPR = 2;

        public DateTime OprTime;
        public int OprType;
        public bool OprDirection;
        public int OprID;
        public string OprOwner;

        public double Value;
        public int CurrencyID;
        public string CurrencyName;
        public string CurrencySymbol;
        public double ExchangeRate;
        public double RealValue;
        public AccountOprReportDetail(
         DateTime OprTime_,
         int OprType_,
         bool OprDirection_,
         int OprID_,
         string OprOwner_,
         double Value_,
          int CurrencyID_,
         string CurrencyName_,
         string CurrencySymbol_,
        double ExchangeRate_,
         double RealValue_
         )
        {

            OprTime = OprTime_;
            OprType = OprType_;
            OprID = OprID_;
            OprOwner = OprOwner_;
            OprDirection = OprDirection_;
            Value = Value_;
            CurrencyID = CurrencyID_;
            CurrencyName = CurrencyName_;
            CurrencySymbol = CurrencySymbol_;
            ExchangeRate = ExchangeRate_;
            RealValue = RealValue_;
        }
        internal static List<AccountOprReportDetail> Get_AccountOprReportDetail_List_From_DataTable(DataTable table)
        {
            try
            {

                List<AccountOprReportDetail> list = new List<AccountOprReportDetail>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DateTime OprTime = Convert.ToDateTime(table.Rows[i]["OprTime"]);
                    int OprType = Convert.ToInt32(table.Rows[i]["OprType"]);
                    bool OprDirection = Convert.ToBoolean(table.Rows[i]["OprDirection"]); ;

                    int OprID = Convert.ToInt32(table.Rows[i]["OprID"]);
                    string OprOwner = table.Rows[i]["OprOwner"].ToString();
                    double Value = Convert.ToDouble(table.Rows[i]["Value"]);
                    int CurrencyID = Convert.ToInt32(table.Rows[i]["CurrencyID"]);
                    string CurrencyName = table.Rows[i]["CurrencyName"].ToString();
                    string CurrencySymbol = table.Rows[i]["CurrencySymbol"].ToString();
                    double ExchangeRate = Convert.ToDouble(table.Rows[i]["ExchangeRate"]);
                    double RealValue = Convert.ToDouble(table.Rows[i]["RealValue"]);
                    list.Add(new AccountOprReportDetail(OprTime, OprType, OprDirection, OprID, OprOwner, Value,
                        CurrencyID, CurrencyName, CurrencySymbol, ExchangeRate,
                        RealValue));

                }
                return list;

            }
            catch (Exception ee)
            {
                throw new Exception("Get_AccountOprReportDetail_List_From_DataTable:" + ee.Message);
            }
        }

    }
}
