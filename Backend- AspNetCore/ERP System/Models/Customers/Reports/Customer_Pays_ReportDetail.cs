using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Customers.Reports
{
    public class Customer_Pays_ReportDetail
    {
        public const bool DIRECTION_IN = false;
        public const bool DIRECTION_OUT = true;

        public int PayOPR_ID;
        public bool PayDirection;
        public DateTime PayDate;
        public double Value;
        public int CurrencyID;
        public string CurrencyName;
        public string CurrencySymbol;
        public double ExchangeRate;
        public double RealValue;
        public int OperationID;
        public int OperationType;
        public Customer_Pays_ReportDetail(int PayOPR_ID_, bool PayDirection_, DateTime PayDate_, double Value_,
         int CurrencyID_, string CurrencyName_, string CurrencySymbol_, double ExchangeRate_, double RealValue_,
         int OperationID_, int OperationType_
         )
        {
            PayOPR_ID = PayOPR_ID_;
            PayDirection = PayDirection_; ;
            PayDate = PayDate_; ;
            Value = Value_; ;
            CurrencyID = CurrencyID_; ;
            CurrencyName = CurrencyName_;
            CurrencySymbol = CurrencySymbol_;
            ExchangeRate = ExchangeRate_;
            RealValue = RealValue_;
            OperationID = OperationID_;
            OperationType = OperationType_;
        }
        internal static List<Customer_Pays_ReportDetail> Get_Customer_Customer_Pays_ReportDetail_List_From_DataTable(System.Data.DataTable table)
        {
            try
            {

                List<Customer_Pays_ReportDetail> list = new List<Customer_Pays_ReportDetail>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int PayOPR_ID = Convert.ToInt32(table.Rows[i]["PayOPR_ID"]);
                    bool PayDirection = Convert.ToBoolean(table.Rows[i]["PayDirection"]); ;
                    DateTime PayDate = Convert.ToDateTime(table.Rows[i]["PayDate"]);
                    double Value = Convert.ToDouble(table.Rows[i]["Value"]);
                    int CurrencyID = Convert.ToInt32(table.Rows[i]["CurrencyID"]);
                    string CurrencyName = table.Rows[i]["CurrencyName"].ToString();
                    string CurrencySymbol = table.Rows[i]["CurrencySymbol"].ToString();
                    double ExchangeRate = Convert.ToDouble(table.Rows[i]["ExchangeRate"]);
                    double RealValue = Convert.ToDouble(table.Rows[i]["RealValue"]);
                    int OperationID = Convert.ToInt32(table.Rows[i]["OperationID"]);
                    int OperationType = Convert.ToInt32(table.Rows[i]["OperationType"]);
                    list.Add(new Customer_Pays_ReportDetail(PayOPR_ID,
                         PayDirection, PayDate, Value, CurrencyID, CurrencyName, CurrencySymbol, ExchangeRate,
                        RealValue, OperationID, OperationType));

                }
                return list;

            }
            catch (Exception ee)
            {
                throw new Exception("Get_Customer_Customer_Pays_ReportDetail_List_From_DataTable:" + ee.Message);
            }
        }


    }
}
