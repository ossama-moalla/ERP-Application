using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.Reports
{
    public class Report_PayOrders_Year_ReportDetail
    {
        public int MonthNO;
        public string MonthName;
        public int Salary_PayOrders_Count;
        public int Other_PayOrders_Count;
        public string PayOrders_Value;
        public string PayOrders_Pays_Value;
        public string PayOrders_Pays_Remain;

        public double PayOrders_Pays_Remain_UPON_PayOrdersCurrency;
        public double PayOrders_RealValue;
        public double PayOrders_Pays_RealValue;

        public Report_PayOrders_Year_ReportDetail(
                int MOnthNO_,
                string MonthName_,
          int Salary_PayOrders_Count_,
         int Other_PayOrders_Count_,
         string PayOrders_Value_,
         string PayOrders_Pays_Value_,
         string PayOrders_Pays_Remain_,

         double PayOrders_Pays_Remain_UPON_PayOrdersCurrency_,
         double PayOrders_RealValue_,
         double PayOrders_Pays_RealValue_)
        {
            MonthNO = MOnthNO_;
            MonthName = MonthName_;
            Salary_PayOrders_Count = Salary_PayOrders_Count_;
            Other_PayOrders_Count = Other_PayOrders_Count_;
            PayOrders_Value = PayOrders_Value_;
            PayOrders_Pays_Value = PayOrders_Pays_Value_;
            PayOrders_Pays_Remain = PayOrders_Pays_Remain_;

            PayOrders_Pays_Remain_UPON_PayOrdersCurrency = PayOrders_Pays_Remain_UPON_PayOrdersCurrency_;
            PayOrders_RealValue = PayOrders_RealValue_;
            PayOrders_Pays_RealValue = PayOrders_Pays_RealValue_;
        }
        internal static List<Report_PayOrders_Year_ReportDetail> Get_Report_PayOrders_Year_ReportDetail_List_From_DataTable(System.Data.DataTable table)
        {

            try
            {

                List<Report_PayOrders_Year_ReportDetail> list = new List<Report_PayOrders_Year_ReportDetail>();


                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int MonthNO = Convert.ToInt32(table.Rows[i]["MonthNO"]);
                    string MonthName = table.Rows[i]["MonthName"].ToString();
                    int Salary_PayOrders_Count = Convert.ToInt32(table.Rows[i]["Salary_PayOrders_Count"]);
                    int Other_PayOrders_Count = Convert.ToInt32(table.Rows[i]["Other_PayOrders_Count"]);
                    string PayOrders_Value = table.Rows[i]["PayOrders_Value"].ToString();
                    string PayOrders_Pays_Value = table.Rows[i]["PayOrders_Pays_Value"].ToString();
                    string PayOrders_Pays_Remain = table.Rows[i]["PayOrders_Pays_Remain"].ToString();
                    double PayOrders_Pays_Remain_UPON_PayOrdersCurrency = Convert.ToDouble(table.Rows[i]["PayOrders_Pays_Remain_UPON_PayOrdersCurrency"]);
                    double PayOrders_RealValue = Convert.ToDouble(table.Rows[i]["PayOrders_RealValue"]);
                    double PayOrders_Pays_RealValue = Convert.ToDouble(table.Rows[i]["PayOrders_Pays_RealValue"]);


                    list.Add(new Report_PayOrders_Year_ReportDetail(
         MonthNO,
        MonthName,
         Salary_PayOrders_Count,
        Other_PayOrders_Count,
         PayOrders_Value,
         PayOrders_Pays_Value,
         PayOrders_Pays_Remain,

         PayOrders_Pays_Remain_UPON_PayOrdersCurrency,
        PayOrders_RealValue,
         PayOrders_Pays_RealValue
));
                }
                return list;
            }
            catch (Exception ee)
            {
                throw new Exception("Get_Report_PayOrders_Year_ReportDetail_List_AS_DataTable:" + ee.Message);
            }
        }
    }
}
