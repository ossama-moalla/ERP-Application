using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Report_Bills_Sell
{
    public class Report_Sells_Month_ReportDetail
    {
        public int DayID;
        public DateTime DayDate;
        public int Bills_Count;
        public int Bills_Clause_Count;
        public string Bills_Value;
        public string Bills_Pays_Value;
        public string Bills_Pays_Remain;
        public double Bills_Pays_Remain_UPON_BillsCurrency;
        public string Bills_ItemsIN_Value;
        public double Bills_ItemsIN_RealValue;
        public double Bills_RealValue;
        public double Bills_Pays_RealValue;
        public Report_Sells_Month_ReportDetail(
                int DayID_,
                DateTime DayDate_,
          int Bills_Count_,
         int Bills_Clause_Count_,
         string Bills_Value_,
         string Bills_Pays_Value_,
         string Bills_Pays_Remain_,
         double Bills_Pays_Remain_UPON_BillsCurrency_,
         string Bills_ItemsIN_Value_,
         double Bills_ItemsIN_RealValue_,
         double Bills_RealValue_,
         double Bills_Pays_RealValue_)
        {
            DayID = DayID_;
            DayDate = DayDate_;
            Bills_Count = Bills_Count_;
            Bills_Clause_Count = Bills_Clause_Count_;
            Bills_Value = Bills_Value_;
            Bills_Pays_Value = Bills_Pays_Value_;
            Bills_Pays_Remain = Bills_Pays_Remain_;
            Bills_Pays_Remain_UPON_BillsCurrency = Bills_Pays_Remain_UPON_BillsCurrency_;
            Bills_ItemsIN_Value = Bills_ItemsIN_Value_;
            Bills_ItemsIN_RealValue = Bills_ItemsIN_RealValue_;
            Bills_RealValue = Bills_RealValue_;
            Bills_Pays_RealValue = Bills_Pays_RealValue_;
        }
        internal static List<Report_Sells_Month_ReportDetail> Get_Report_Sells_Month_ReportDetail_List_From_DataTable(System.Data.DataTable table)
        {

            try
            {
                List<Report_Sells_Month_ReportDetail> list = new List<Report_Sells_Month_ReportDetail>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int DayID = Convert.ToInt32(table.Rows[i]["DayID"]);
                    DateTime DayDate = Convert.ToDateTime(table.Rows[i]["DayDate"]);
                    int Bills_Count = Convert.ToInt32(table.Rows[i]["Bills_Count"]);
                    int Bills_Clause_Count = Convert.ToInt32(table.Rows[i]["Bills_Clause_Count"]);
                    string Bills_Value = table.Rows[i]["Bills_Value"].ToString();
                    string Bills_Pays_Value = table.Rows[i]["Bills_Pays_Value"].ToString();
                    string Bills_Pays_Remain = table.Rows[i]["Bills_Pays_Remain"].ToString();
                    double Bills_Pays_Remain_UPON_BillsCurrency = Convert.ToDouble(table.Rows[i]["Bills_Pays_Remain_UPON_BillsCurrency"]);
                    string Bills_ItemsIN_Value = table.Rows[i]["Bills_ItemsIN_Value"].ToString();
                    double Bills_ItemsIN_RealValue = Convert.ToDouble(table.Rows[i]["Bills_ItemsIN_RealValue"]);
                    double Bills_RealValue = Convert.ToDouble(table.Rows[i]["Bills_RealValue"]);
                    double Bills_Pays_RealValue = Convert.ToDouble(table.Rows[i]["Bills_Pays_RealValue"]);


                    list.Add(new Report_Sells_Month_ReportDetail(DayID, DayDate, Bills_Count, Bills_Clause_Count, Bills_Value, Bills_Pays_Value, Bills_Pays_Remain,
             Bills_Pays_Remain_UPON_BillsCurrency, Bills_ItemsIN_Value, Bills_ItemsIN_RealValue, Bills_RealValue,
            Bills_Pays_RealValue));

                }
                return list;
            }
            catch (Exception ee)
            {
                throw new Exception("Get_Report_Sells_Month_ReportDetail_From_DataTable:" + ee.Message);
            }
        }
    }
}
