using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting.Reports
{
    public class AccountOprMonthReportDetail
    {
        public int Year_Month;
        public string Year_Month_Name;
        public int PaysIN_Count;
        public int PaysOUT_Count;
        public int Exchange_Count;
        public int MoneyTransform_IN_Count;
        public int MoneyTransform_OUT_Count;
        public string PaysIN_Value;
        public double PaysIN_Real_Value;
        public string PaysOUT_Value;
        public double PaysOUT_Real_Value;
        public AccountOprMonthReportDetail(
            int Year_Month_,
         string Year_Month_Name_,
        int PaysIN_Count_,
         int PaysOUT_Count_,
         int Exchange_Count_,
             int MoneyTransform_IN_Count_,
         int MoneyTransform_OUT_Count_,
        string PaysIN_Value_,
         double PaysIN_Real_Value_,
         string PaysOUT_Value_,
         double PaysOUT_Real_Value_)
        {
            Year_Month = Year_Month_;
            Year_Month_Name = Year_Month_Name_;
            PaysIN_Count = PaysIN_Count_;
            PaysOUT_Count = PaysOUT_Count_;
            Exchange_Count = Exchange_Count_;
            MoneyTransform_IN_Count = MoneyTransform_IN_Count_;
            MoneyTransform_OUT_Count = MoneyTransform_OUT_Count_;
            PaysIN_Value = PaysIN_Value_;
            PaysIN_Real_Value = PaysIN_Real_Value_;
            PaysOUT_Value = PaysOUT_Value_;
            PaysOUT_Real_Value = PaysOUT_Real_Value_;
        }
        internal static List<AccountOprMonthReportDetail> Get_AccountOprMonthReportDetail_List_From_DataTable(DataTable table)
        {
            try
            {

                List<AccountOprMonthReportDetail> list = new List<AccountOprMonthReportDetail>();
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    int Year_Month = Convert.ToInt32(table.Rows[i]["Year_Month"]);
                    string Year_Month_Name = table.Rows[i]["Year_Month_Name"].ToString();

                    int PaysIN_Count = Convert.ToInt32(table.Rows[i]["PaysIN_Count"]); ;
                    int PaysOUT_Count = Convert.ToInt32(table.Rows[i]["PaysOUT_Count"]); ;
                    int Exchange_Count = Convert.ToInt32(table.Rows[i]["Exchange_Count"]); ;
                    int MoneyTransform_IN_Count = Convert.ToInt32(table.Rows[i]["MoneyTransform_IN_Count"]); ;
                    int MoneyTransform_OUT_Count = Convert.ToInt32(table.Rows[i]["MoneyTransform_OUT_Count"]); ;

                    string PaysIN_Value = table.Rows[i]["PaysIN_Value"].ToString();
                    double PaysIN_Real_Value = Convert.ToDouble(table.Rows[i]["PaysIN_Real_Value"]);
                    string PaysOUT_Value = table.Rows[i]["PaysOUT_Value"].ToString();
                    double PaysOUT_Real_Value = Convert.ToDouble(table.Rows[i]["PaysOUT_Real_Value"]);
                    list.Add(new AccountOprMonthReportDetail(Year_Month, Year_Month_Name, PaysIN_Count, PaysOUT_Count
                        , Exchange_Count, MoneyTransform_IN_Count, MoneyTransform_OUT_Count
                        , PaysIN_Value, PaysIN_Real_Value, PaysOUT_Value, PaysOUT_Real_Value));

                }
                return list;

            }
            catch (Exception ee)
            {
                throw new Exception("Get_AccountOprMonthReportDetail_List_From_DataTable:" + ee.Message);
            }
        }

    }
}
