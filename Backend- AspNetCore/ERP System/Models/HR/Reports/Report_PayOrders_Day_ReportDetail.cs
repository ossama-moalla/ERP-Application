using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.Reports
{
    public class Report_PayOrders_Day_ReportDetail
    {
        public const bool TYPE_SALARY_PAY_ODER = false;
        public const bool TYPE_PAY_ODER = true;

        public DateTime PayOrder_Time;
        public bool PayOrderType;
        public uint PayOrderID;

        public string PayOrderDesc;
        public uint EmployeeID;
        public string EmployeeName;
        public uint CurrencyID;
        public string CurrencyName;
        public string CurrencySymbol;

        public double ExchangeRate;
        public double Value;
        public string PaysAmount;
        public double PaysRemain;
        public double RealValue;
        public double RealPays;
        public Report_PayOrders_Day_ReportDetail(
             DateTime PayOrder_Time_,
            bool PayOrderType_,
            uint PayOrderID_,

         string PayOrderDesc_,
         uint EmployeeID_,
         string EmployeeName_,
         double Value_,
         uint CurrencyID_,
         string CurrencyName_,
         string CurrencySymbol_,
        double ExchangeRate_,

         string PaysAmount_,
         double PaysRemain_,
         double RealValue_,
         double RealPays_)
        {
            PayOrder_Time = PayOrder_Time_;
            PayOrderType = PayOrderType_;
            PayOrderID = PayOrderID_;
            PayOrderDesc = PayOrderDesc_;
            EmployeeID = EmployeeID_;
            EmployeeName = EmployeeName_;
            CurrencyID = CurrencyID_;
            CurrencyName = CurrencyName_;
            CurrencySymbol = CurrencySymbol_;
            ExchangeRate = ExchangeRate_;
            Value = Value_;
            PaysAmount = PaysAmount_;
            PaysRemain = PaysRemain_;
            RealValue = RealValue_;
            RealPays = RealPays_;
        }
        internal static List<Report_PayOrders_Day_ReportDetail> Get_Report_PayOrders_Day_ReportDetail_List_From_DataTable(System.Data.DataTable table)
        {

            try
            {

                List<Report_PayOrders_Day_ReportDetail> list = new List<Report_PayOrders_Day_ReportDetail>();

                for (int i = 0; i < table.Rows.Count; i++)
                {

                    DateTime PayOrder_Time = Convert.ToDateTime(table.Rows[i]["PayOrder_Time"]);
                    bool PayOrderType = Convert.ToBoolean(table.Rows[i]["PayOrderType"]);
                    uint PayOrderID = Convert.ToUInt32(table.Rows[i]["PayOrderID"]);
                    string PayOrderDesc = table.Rows[i]["PayOrderDesc"].ToString();
                    uint EmployeeID = Convert.ToUInt32(table.Rows[i]["EmployeeID"]);
                    string EmployeeName = table.Rows[i]["EmployeeName"].ToString();
                    uint CurrencyID = Convert.ToUInt32(table.Rows[i]["CurrencyID"]);
                    string CurrencyName = table.Rows[i]["CurrencyName"].ToString();
                    string CurrencySymbol = table.Rows[i]["CurrencySymbol"].ToString();
                    double ExchangeRate = Convert.ToDouble(table.Rows[i]["ExchangeRate"]);
                    double Value = Convert.ToDouble(table.Rows[i]["Value"]);
                    string PaysAmount = table.Rows[i]["PaysAmount"].ToString();
                    double PaysRemain = Convert.ToDouble(table.Rows[i]["PaysRemain"]);
                    double RealValue = Convert.ToDouble(table.Rows[i]["RealValue"]);
                    double RealPays = Convert.ToDouble(table.Rows[i]["RealPays"]);

                    list.Add(new Report_PayOrders_Day_ReportDetail(
        PayOrder_Time,
         PayOrderType,
         PayOrderID,

         PayOrderDesc,
         EmployeeID,
       EmployeeName,
      Value,

        CurrencyID,
         CurrencyName,
         CurrencySymbol,

         ExchangeRate,
        PaysAmount,
         PaysRemain,
        RealValue,
         RealPays));
                }
                return list;
            }
            catch (Exception ee)
            {
                throw new Exception("Get_Report_PayOrders_Day_ReportDetail_List_AS_DataTable:" + ee.Message);
            }
        }


    }
}
