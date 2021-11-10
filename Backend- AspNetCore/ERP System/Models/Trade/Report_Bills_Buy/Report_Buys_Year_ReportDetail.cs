using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Report_Bills_Buy
{
    public class Report_Buys_Year_ReportDetail
    {
        public int MonthNO;
        public string MonthName;
        public int Bills_Count;
        public double Amount_IN;
        public double Amount_Remain;
        public string Bills_Value;

        public string Bills_Pays_Value;
        public string Bills_Pays_Remain;
        public double Bills_Pays_Remain_UPON_Bill_Currency;

        public double Bills_RealValue;
        public double Bills_Pays_RealValue;
        public string Bills_ItemsOut_Value;
        public double Bills_ItemsOut_RealValue;
        public string Bills_Pays_Return_Value;
        public double Bills_Pays_Return_RealValue;

        public Report_Buys_Year_ReportDetail(
                int MOnthNO_,
                string MonthName_,
           int Bills_Count_,
         double Amount_IN_,
         double Amount_Remain_,
         string Bills_Value_,
         string Bills_Pays_Value_,
         string Bills_Pays_Remain_,

         double Bills_Pays_Remain_UPON_Bill_Currency_,

         double Bills_RealValue_,
         double Bills_Pays_RealValue_,
         string Bills_ItemsOut_Value_,
         double Bills_ItemsOut_RealValue_,
         string Bills_Pays_Return_Value_,
         double Bills_Pays_Return_RealValue_)
        {
            MonthNO = MOnthNO_;
            MonthName = MonthName_;
            Bills_Count = Bills_Count_;
            Amount_IN = Amount_IN_;
            Amount_Remain = Amount_Remain_;

            Bills_Value = Bills_Value_;
            Bills_Pays_Value = Bills_Pays_Value_;
            Bills_Pays_Remain = Bills_Pays_Remain_;
            Bills_Pays_Remain_UPON_Bill_Currency = Bills_Pays_Remain_UPON_Bill_Currency_;

            Bills_RealValue = Bills_RealValue_;
            Bills_Pays_RealValue = Bills_Pays_RealValue_;
            Bills_ItemsOut_Value = Bills_ItemsOut_Value_;
            Bills_ItemsOut_RealValue = Bills_ItemsOut_RealValue_;
            Bills_Pays_Return_Value = Bills_Pays_Return_Value_;
            Bills_Pays_Return_RealValue = Bills_Pays_Return_RealValue_;
        }
        internal static List<Report_Buys_Year_ReportDetail> Get_Report_Buys_Year_ReportDetail_List_From_DataTable(System.Data.DataTable table)
        {

            try
            {
                List<Report_Buys_Year_ReportDetail> list = new List<Report_Buys_Year_ReportDetail>();

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int MonthNO = Convert.ToInt32(table.Rows[i]["MonthNO"]);
                    string MonthName = table.Rows[i]["MonthName"].ToString();
                    int Bills_Count = Convert.ToInt32(table.Rows[i]["Bills_Count"]);
                    double Amount_IN = Convert.ToDouble(table.Rows[i]["Amount_IN"]);
                    double Amount_Remain = Convert.ToDouble(table.Rows[i]["Amount_Remain"]);
                    string Bills_Value = table.Rows[i]["Bills_Value"].ToString();
                    string Bills_Pays_Value = table.Rows[i]["Bills_Pays_Value"].ToString();
                    string Bills_Pays_Remain = table.Rows[i]["Bills_Pays_Remain"].ToString();
                    double Bills_Pays_Remain_UPON_Bill_Currency = Convert.ToDouble(table.Rows[i]["Bills_Pays_Remain_UPON_Bill_Currency"]);
                    double Bills_RealValue = Convert.ToDouble(table.Rows[i]["Bills_RealValue"]);
                    double Bills_Pays_RealValue = Convert.ToDouble(table.Rows[i]["Bills_Pays_RealValue"]);
                    string Bills_ItemsOut_Value = table.Rows[i]["Bills_ItemsOut_Value"].ToString();
                    double Bills_ItemsOut_RealValue = Convert.ToDouble(table.Rows[i]["Bills_ItemsOut_RealValue"]);
                    string Bills_Pays_Return_Value = table.Rows[i]["Bills_Pays_Return_Value"].ToString();
                    double Bills_Pays_Return_RealValue = Convert.ToDouble(table.Rows[i]["Bills_Pays_Return_RealValue"]);
                    list.Add(new Report_Buys_Year_ReportDetail(MonthNO,
         MonthName,
       Bills_Count,
         Amount_IN,
        Amount_Remain,
        Bills_Value,
        Bills_Pays_Value,
       Bills_Pays_Remain,
        Bills_Pays_Remain_UPON_Bill_Currency,
        Bills_RealValue,
        Bills_Pays_RealValue,
        Bills_ItemsOut_Value,
        Bills_ItemsOut_RealValue,
        Bills_Pays_Return_Value,
        Bills_Pays_Return_RealValue
    ));
                }
                return list;
            }
            catch (Exception ee)
            {
                throw new Exception("Get_Report_Buys_Year_ReportDetail_List_From_DataTable:" + ee.Message);
            }
        }
    }
}
