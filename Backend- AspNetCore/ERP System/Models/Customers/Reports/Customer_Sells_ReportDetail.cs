using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Customers.Reports
{
    public class Customer_Sells_ReportDetail
    {
        public DateTime Bill_Date;
        public int Bill_ID;
        public string SellType;
        public int ClauseS_Count;
        public double BillValue;
        public int CurrencyID;
        public string CurrencyName;
        public string CurrencySymbol;
        public double ExchangeRate;
        public int PaysCount;
        public string PaysAmount;
        public double PaysRemain;
        public string Source_ItemsIN_Cost_Details;
        public double Source_ItemsIN_RealCost;
        public double BillValue_RealValue;
        public double RealPaysValue;
        public Customer_Sells_ReportDetail(DateTime Bill_Date_,
         int Bill_ID_,
         string SellType_,
         int ClauseS_Count_,
         double BillValue_,
         int CurrencyID_,
         string CurrencyName_,
         string CurrencySymbol_,
        double ExchangeRate_,
         int PaysCount_,
         string PaysAmount_,
         double PaysRemain_,
         string Source_ItemsIN_Cost_Details_,
         double Source_ItemsIN_RealCost_,
         double BillValue_RealValue_,
         double RealPaysValue_
           )
        {
            Bill_Date = Bill_Date_;
            Bill_ID = Bill_ID_;
            SellType = SellType_;
            ClauseS_Count = ClauseS_Count_;
            BillValue = BillValue_;
            CurrencyID = CurrencyID_;
            CurrencyName = CurrencyName_;
            CurrencySymbol = CurrencySymbol_;
            ExchangeRate = ExchangeRate_;
            PaysCount = PaysCount_;
            PaysAmount = PaysAmount_;
            PaysRemain = PaysRemain_;
            Source_ItemsIN_Cost_Details = Source_ItemsIN_Cost_Details_;
            Source_ItemsIN_RealCost = Source_ItemsIN_RealCost_;
            BillValue_RealValue = BillValue_RealValue_;
            RealPaysValue = RealPaysValue_;
        }
        internal static List<Customer_Sells_ReportDetail> Get_Customer_Sells_ReportDetail_List_From_DataTable(System.Data.DataTable table)
        {

            try
            {

                List<Customer_Sells_ReportDetail> list = new List<Customer_Sells_ReportDetail>();

                for (int i = 0; i < table.Rows.Count; i++)
                {

                    DateTime Bill_Date = Convert.ToDateTime(table.Rows[i]["Bill_Date"]);
                    int Bill_ID = Convert.ToInt32(table.Rows[i]["Bill_ID"]);
                    string SellType = table.Rows[i]["SellType"].ToString();
                    int ClauseS_Count = Convert.ToInt32(table.Rows[i]["ClauseS_Count"]);
                    double BillValue = Convert.ToDouble(table.Rows[i]["BillValue"]);
                    int CurrencyID = Convert.ToInt32(table.Rows[i]["CurrencyID"]);
                    string CurrencyName = table.Rows[i]["CurrencyName"].ToString();
                    string CurrencySymbol = table.Rows[i]["CurrencySymbol"].ToString();
                    double ExchangeRate = Convert.ToDouble(table.Rows[i]["ExchangeRate"]);
                    int PaysCount = Convert.ToInt32(table.Rows[i]["PaysCount"]);
                    string PaysAmount = table.Rows[i]["PaysAmount"].ToString();
                    double PaysRemain = Convert.ToDouble(table.Rows[i]["PaysRemain"]);
                    string Source_ItemsIN_Cost_Details = table.Rows[i]["Source_ItemsIN_Cost_Details"].ToString();
                    double Source_ItemsIN_RealCost = Convert.ToDouble(table.Rows[i]["Source_ItemsIN_RealCost"]);
                    double BillValue_RealValue = Convert.ToDouble(table.Rows[i]["BillValue_RealValue"]);
                    double RealPaysValue = Convert.ToDouble(table.Rows[i]["RealPaysValue"]);

                    list.Add(new Customer_Sells_ReportDetail(Bill_Date, Bill_ID, SellType, ClauseS_Count, BillValue,
                    CurrencyID, CurrencyName, CurrencySymbol, ExchangeRate, PaysCount, PaysAmount, PaysRemain,
                    Source_ItemsIN_Cost_Details, Source_ItemsIN_RealCost, BillValue_RealValue, RealPaysValue));
                }
                return list;
            }
            catch (Exception ee)
            {
                throw new Exception("Get_Customer_Sells_ReportDetail_List_AS_DataTable:" + ee.Message);
            }
        }


    }
}
