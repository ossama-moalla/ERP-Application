using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Report_Bills_Buy
{
    public class Report_Buys_Day_ReportDetail
    {
        public DateTime Bill_Time;
        public int Bill_ID;
        public string Bill_Owner;
        public int ClauseS_Count;
        public double Amount_IN;
        public double Amount_Remain;
        public double BillValue;
        public int CurrencyID;
        public string CurrencyName;
        public string CurrencySymbol;
        public double ExchangeRate;
        public string PaysAmount;
        public double PaysRemain;
        public double Bill_RealValue;
        public double Bill_Pays_RealValue;
        public string Bill_ItemsOut_Value;
        public double Bill_ItemsOut_RealValue;
        public string Bill_Pays_Return_Value;
        public double Bill_Pays_Return_RealValue;

        public Report_Buys_Day_ReportDetail(DateTime Bill_Time_,
         int Bill_ID_,
         string Bill_Owner_,
         int ClauseS_Count_,
         double Amount_IN_,
         double Amount_Remain_,
         double BillValue_,
          int CurrencyID_,
         string CurrencyName_,
         string CurrencySymbol_,
         double ExchangeRate_,
         string PaysAmount_,
         double PaysRemain_,
         double Bill_RealValue_,
         double Bill_Pays_RealValue_,
         string Bill_ItemsOut_Value_,
         double Bill_ItemsOut_RealValue_,
         string Bill_Pays_Return_Value_,
         double Bill_Pays_Return_RealValue_
           )
        {
            Bill_Time = Bill_Time_;
            Bill_ID = Bill_ID_;
            Bill_Owner = Bill_Owner_;
            ClauseS_Count = ClauseS_Count_;
            Amount_IN = Amount_IN_;
            Amount_Remain = Amount_Remain_;
            BillValue = BillValue_;
            CurrencyID = CurrencyID_;
            CurrencyName = CurrencyName_;
            CurrencySymbol = CurrencySymbol_;
            ExchangeRate = ExchangeRate_;
            PaysAmount = PaysAmount_;
            PaysRemain = PaysRemain_;
            Bill_RealValue = Bill_RealValue_;
            Bill_Pays_RealValue = Bill_Pays_RealValue_;
            Bill_ItemsOut_Value = Bill_ItemsOut_Value_;
            Bill_ItemsOut_RealValue = Bill_ItemsOut_RealValue_;
            Bill_Pays_Return_Value = Bill_Pays_Return_Value_;
            Bill_Pays_Return_RealValue = Bill_Pays_Return_RealValue_;

        }
        internal static List<Report_Buys_Day_ReportDetail> Get_Report_Buys_Day_ReportDetail_List_From_DataTable(System.Data.DataTable table)
        {

            try
            {
                List<Report_Buys_Day_ReportDetail> list = new List<Report_Buys_Day_ReportDetail>();


                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DateTime Bill_Time = Convert.ToDateTime(table.Rows[i]["Bill_Time"]);
                    int Bill_ID = Convert.ToInt32(table.Rows[i]["Bill_ID"]);
                    string Bill_Owner = table.Rows[i]["Bill_Owner"].ToString();
                    int ClauseS_Count = Convert.ToInt32(table.Rows[i]["ClauseS_Count"]);
                    double Amount_IN = Convert.ToDouble(table.Rows[i]["Amount_IN"]);
                    double Amount_Remain = Convert.ToDouble(table.Rows[i]["Amount_Remain"]);
                    double BillValue = Convert.ToDouble(table.Rows[i]["BillValue"]);
                    int CurrencyID = Convert.ToInt32(table.Rows[i]["CurrencyID"]);
                    string CurrencyName = table.Rows[i]["CurrencyName"].ToString();
                    string CurrencySymbol = table.Rows[i]["CurrencySymbol"].ToString();
                    double ExchangeRate = Convert.ToDouble(table.Rows[i]["ExchangeRate"]);
                    string PaysAmount = table.Rows[i]["PaysAmount"].ToString();
                    double PaysRemain = Convert.ToDouble(table.Rows[i]["PaysRemain"]);
                    double Bill_RealValue = Convert.ToDouble(table.Rows[i]["Bill_RealValue"]);
                    double Bill_Pays_RealValue = Convert.ToDouble(table.Rows[i]["Bill_Pays_RealValue"]);
                    string Bill_ItemsOut_Value = table.Rows[i]["Bill_ItemsOut_Value"].ToString();
                    double Bill_ItemsOut_RealValue = Convert.ToDouble(table.Rows[i]["Bill_ItemsOut_RealValue"]);
                    string Bill_Pays_Return_Value = table.Rows[i]["Bill_Pays_Return_Value"].ToString();
                    double Bill_Pays_Return_RealValue = Convert.ToDouble(table.Rows[i]["Bill_Pays_Return_RealValue"]);


                    list.Add(new Report_Buys_Day_ReportDetail(
         Bill_Time,
         Bill_ID,
         Bill_Owner,
        ClauseS_Count,
         Amount_IN,
         Amount_Remain,
         BillValue,
         CurrencyID,
         CurrencyName,
         CurrencySymbol,
       ExchangeRate,
         PaysAmount,
        PaysRemain,
        Bill_RealValue,
        Bill_Pays_RealValue,
        Bill_ItemsOut_Value,
        Bill_ItemsOut_RealValue,
        Bill_Pays_Return_Value,
        Bill_Pays_Return_RealValue));
                }
                return list;
            }
            catch (Exception ee)
            {
                throw new Exception("Get_Contact_Buys_ReportDetail_List_From_DataTable:" + ee.Message);
            }
        }
    }
}
