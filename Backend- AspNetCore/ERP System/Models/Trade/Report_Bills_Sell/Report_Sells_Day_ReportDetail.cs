using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Report_Bills_Sell
{
    public class Report_Sells_Day_ReportDetail
    {
        public DateTime Bill_Time;
        public uint Bill_ID;
        public string SellType;
        public string Bill_Owner;
        public int ClauseS_Count;
        public double BillValue;
        public uint CurrencyID;
        public string CurrencyName;
        public string CurrencySymbol;
        public double ExchangeRate;
        public int PaysCount;
        public string PaysAmount;
        public double PaysRemain;
        public string Source_ItemsIN_Cost_Details;
        public double Source_ItemsIN_RealCost;
        public double ItemsOut_RealValue;
        public double RealPaysValue;
        public Report_Sells_Day_ReportDetail(DateTime Bill_Time_,
         uint Bill_ID_,
         string SellType_,
         string Bill_Owner_,
         int ClauseS_Count_,
         double BillValue_,
         uint CurrencyID_,
         string CurrencyName_,
         string CurrencySymbol_,
         double ExchangeRate_,
         int PaysCount_,
         string PaysAmount_,
         double PaysRemain_,
         string Source_ItemsIN_Cost_Details_,
         double Source_ItemsIN_RealCost_,
         double ItemsOut_RealValue_,
         double RealPaysValue_
           )
        {
            Bill_Time = Bill_Time_;
            Bill_ID = Bill_ID_;
            SellType = SellType_;
            Bill_Owner = Bill_Owner_;
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
            ItemsOut_RealValue = ItemsOut_RealValue_;
            RealPaysValue = RealPaysValue_;
        }
        internal static List<Report_Sells_Day_ReportDetail> Get_Report_Sells_Day_ReportDetail_List_From_DataTable(System.Data.DataTable table)
        {

            try
            {

                List<Report_Sells_Day_ReportDetail> list = new List<Report_Sells_Day_ReportDetail>();

                for (int i = 0; i < table.Rows.Count; i++)
                {

                    DateTime Bill_Date = Convert.ToDateTime(table.Rows[i]["Bill_Time"]);
                    uint Bill_ID = Convert.ToUInt32(table.Rows[i]["Bill_ID"]);
                    string SellType = table.Rows[i]["SellType"].ToString();
                    string Bill_Owner = table.Rows[i]["Bill_Owner"].ToString();
                    int ClauseS_Count = Convert.ToInt32(table.Rows[i]["ClauseS_Count"]);
                    double BillValue = Convert.ToDouble(table.Rows[i]["BillValue"]);
                    uint CurrencyID = Convert.ToUInt32(table.Rows[i]["CurrencyID"]);
                    string CurrencyName = table.Rows[i]["CurrencyName"].ToString();
                    string CurrencySymbol = table.Rows[i]["CurrencySymbol"].ToString();
                    double ExchangeRate = Convert.ToDouble(table.Rows[i]["ExchangeRate"]);
                    int PaysCount = Convert.ToInt32(table.Rows[i]["PaysCount"]);
                    string PaysAmount = table.Rows[i]["PaysAmount"].ToString();
                    double PaysRemain = Convert.ToDouble(table.Rows[i]["PaysRemain"]);
                    string Source_ItemsIN_Cost_Details = table.Rows[i]["Source_ItemsIN_Cost_Details"].ToString();
                    double Source_ItemsIN_RealCost = Convert.ToDouble(table.Rows[i]["Source_ItemsIN_RealCost"]);
                    double ItemsOut_RealValue = Convert.ToDouble(table.Rows[i]["ItemsOut_RealValue"]);
                    double RealPaysValue = Convert.ToDouble(table.Rows[i]["RealPaysValue"]);

                    list.Add(new Report_Sells_Day_ReportDetail(Bill_Date, Bill_ID, SellType, Bill_Owner, ClauseS_Count, BillValue,
                    CurrencyID, CurrencyName, CurrencySymbol, ExchangeRate, PaysCount, PaysAmount, PaysRemain,
                    Source_ItemsIN_Cost_Details, Source_ItemsIN_RealCost, ItemsOut_RealValue, RealPaysValue));
                }
                return list;
            }
            catch (Exception ee)
            {
                throw new Exception("Get_Report_Sells_Day_ReportDetail_List_AS_DataTable:" + ee.Message);
            }
        }
    }
}
