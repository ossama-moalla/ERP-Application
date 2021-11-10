using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Customers.Reports
{
    public class Customer_MaintenanceOPRs_ReportDetail
    {
        public DateTime MaintenanceOPR_Date;
        public uint MaintenanceOPR_ID;
        public uint ItemID;
        public string ItemName;
        public string ItemCompany;
        public string FolderName;
        public string FalutDesc;
        public DateTime? MaintenanceOPR_Endworkdate;
        public bool? MaintenanceOPR_Rpaired;
        public DateTime? MaintenanceOPR_DeliverDate;
        public DateTime? MaintenanceOPR_EndWarrantyDate;
        public uint? BillMaintenanceID;
        public double? BillValue;
        public uint? CurrencyID;
        public string CurrencyName;
        public string CurrencySymbol;
        public double? ExchangeRate;
        public string PaysAmount;
        public double? PaysRemain;
        public string Bill_ItemsOut_Value;
        public double? Bill_ItemsOut_RealValue;
        public double? Bill_RealValue;
        public double? Bill_Pays_RealValue;

        public Customer_MaintenanceOPRs_ReportDetail(
            DateTime MaintenanceOPR_Date_,
         uint MaintenanceOPR_ID_,
           uint ItemID_,
         string ItemName_,
         string ItemCompany_,
         string FolderName_,
        string FalutDesc_,
         DateTime? MaintenanceOPR_Endworkdate_,
         bool? MaintenanceOPR_Rpaired_,
         DateTime? MaintenanceOPR_DeliverDate_,
         DateTime? MaintenanceOPR_EndWarrantyDate_,
         uint? BillMaintenanceID_,
          double? BillValue_,
           uint? CurrencyID_,
         string CurrencyName_,
         string CurrencySymbol_,
        double? ExchangeRate_,
         string PaysAmount_,
         double? PaysRemain_,
        string Bill_ItemsOut_Value_,
         double? Bill_ItemsOut_RealValue_,
         double? Bill_RealValue_,
         double? Bill_Pays_RealValue_


           )
        {
            MaintenanceOPR_Date = MaintenanceOPR_Date_;
            MaintenanceOPR_ID = MaintenanceOPR_ID_;
            ItemID = ItemID_;
            ItemName = ItemName_;
            ItemCompany = ItemCompany_;
            FolderName = FolderName_;
            FalutDesc = FalutDesc_;
            MaintenanceOPR_Endworkdate = MaintenanceOPR_Endworkdate_;
            MaintenanceOPR_Rpaired = MaintenanceOPR_Rpaired_;
            MaintenanceOPR_DeliverDate = MaintenanceOPR_DeliverDate_;
            MaintenanceOPR_EndWarrantyDate = MaintenanceOPR_EndWarrantyDate_;
            BillMaintenanceID = BillMaintenanceID_;
            BillValue = BillValue_;
            CurrencyID = CurrencyID_;
            CurrencyName = CurrencyName_;
            CurrencySymbol = CurrencySymbol_;
            ExchangeRate = ExchangeRate_;
            PaysAmount = PaysAmount_;
            PaysRemain = PaysRemain_;
            Bill_ItemsOut_Value = Bill_ItemsOut_Value_;
            Bill_ItemsOut_RealValue = Bill_ItemsOut_RealValue_;
            Bill_RealValue = Bill_RealValue_;
            Bill_Pays_RealValue = Bill_Pays_RealValue_;


        }
        internal static List<Customer_MaintenanceOPRs_ReportDetail> Get_Customer_MaintenanceOPRs_ReportDetail_List_From_DataTable(System.Data.DataTable table)
        {

            try
            {
                List<Customer_MaintenanceOPRs_ReportDetail> list = new List<Customer_MaintenanceOPRs_ReportDetail>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DateTime MaintenanceOPR_Date = Convert.ToDateTime(table.Rows[i]["MaintenanceOPR_Date"]);
                    uint MaintenanceOPR_ID = Convert.ToUInt32(table.Rows[i]["MaintenanceOPR_ID"]);
                    uint ItemID = Convert.ToUInt32(table.Rows[i]["ItemID"]);
                    string ItemName = table.Rows[i]["ItemName"].ToString();
                    string ItemCompany = table.Rows[i]["ItemCompany"].ToString();
                    string FolderName = table.Rows[i]["FolderName"].ToString();
                    string FalutDesc = table.Rows[i]["FalutDesc"].ToString();

                    DateTime? MaintenanceOPR_Endworkdate;
                    if (table.Rows[i]["MaintenanceOPR_Endworkdate"] != DBNull.Value)

                    {
                        MaintenanceOPR_Endworkdate = Convert.ToDateTime(table.Rows[i]["MaintenanceOPR_Endworkdate"]);
                    }
                    else
                    {
                        MaintenanceOPR_Endworkdate = null;
                    }

                    bool? MaintenanceOPR_Rpaired;
                    try
                    {
                        MaintenanceOPR_Rpaired = Convert.ToBoolean(table.Rows[i]["MaintenanceOPR_Rpaired"]);
                    }
                    catch
                    {
                        MaintenanceOPR_Rpaired = null;
                    }


                    DateTime? MaintenanceOPR_DeliverDate;
                    try
                    {
                        MaintenanceOPR_DeliverDate = Convert.ToDateTime(table.Rows[i]["MaintenanceOPR_DeliverDate"]);
                    }
                    catch
                    {
                        MaintenanceOPR_DeliverDate = null;
                    }

                    DateTime? MaintenanceOPR_EndWarrantyDate;
                    if (table.Rows[i]["MaintenanceOPR_EndWarrantyDate"] != DBNull.Value)
                    {
                        MaintenanceOPR_EndWarrantyDate = Convert.ToDateTime(table.Rows[i]["MaintenanceOPR_EndWarrantyDate"]);
                    }
                    else
                    {
                        MaintenanceOPR_EndWarrantyDate = null;
                    }

                    uint? BillMaintenanceID;
                    try
                    {
                        BillMaintenanceID = Convert.ToUInt32(table.Rows[i]["BillMaintenanceID"]);
                    }
                    catch
                    {
                        BillMaintenanceID = null;
                    }

                    double? BillValue;
                    try
                    {
                        BillValue = Convert.ToDouble(table.Rows[i]["BillValue"]);
                    }
                    catch
                    {
                        BillValue = null;
                    }

                    uint? CurrencyID;
                    try
                    {
                        CurrencyID = Convert.ToUInt32(table.Rows[i]["CurrencyID"]);
                    }
                    catch
                    {
                        CurrencyID = null;
                    }

                    string CurrencyName;
                    try
                    {
                        CurrencyName = table.Rows[i]["CurrencyName"].ToString();
                    }
                    catch
                    {
                        CurrencyName = "";
                    }

                    string CurrencySymbol;
                    try
                    {
                        CurrencySymbol = table.Rows[i]["CurrencySymbol"].ToString();
                    }
                    catch
                    {
                        CurrencySymbol = "";
                    }

                    double? ExchangeRate;
                    try
                    {
                        ExchangeRate = Convert.ToDouble(table.Rows[i]["ExchangeRate"]);
                    }
                    catch
                    {
                        ExchangeRate = null;
                    }

                    string PaysAmount;
                    try
                    {
                        PaysAmount = table.Rows[i]["PaysAmount"].ToString();
                    }
                    catch
                    {
                        PaysAmount = "";
                    }

                    double? PaysRemain;
                    try
                    {
                        PaysRemain = Convert.ToDouble(table.Rows[i]["PaysRemain"]);
                    }
                    catch
                    {
                        PaysRemain = null;
                    }

                    string Bill_ItemsOut_Value;
                    try
                    {
                        Bill_ItemsOut_Value = table.Rows[i]["Bill_ItemsOut_Value"].ToString();
                    }
                    catch
                    {
                        Bill_ItemsOut_Value = "";
                    }

                    double? Bill_ItemsOut_RealValue;
                    try
                    {
                        Bill_ItemsOut_RealValue = Convert.ToDouble(table.Rows[i]["Bill_ItemsOut_RealValue"]);
                    }
                    catch
                    {
                        Bill_ItemsOut_RealValue = null;
                    }

                    double? Bill_RealValue;
                    try
                    {
                        Bill_RealValue = Convert.ToDouble(table.Rows[i]["Bill_RealValue"]);
                    }
                    catch
                    {
                        Bill_RealValue = null;
                    }

                    double? Bill_Pays_RealValue;
                    try
                    {
                        Bill_Pays_RealValue = Convert.ToDouble(table.Rows[i]["Bill_Pays_RealValue"]);
                    }
                    catch
                    {
                        Bill_Pays_RealValue = null;
                    }
                    list.Add(new Customer_MaintenanceOPRs_ReportDetail(MaintenanceOPR_Date,
         MaintenanceOPR_ID,
         ItemID,
        ItemName,
         ItemCompany,
         FolderName,
         FalutDesc,
        MaintenanceOPR_Endworkdate,
         MaintenanceOPR_Rpaired,
         MaintenanceOPR_DeliverDate,
        MaintenanceOPR_EndWarrantyDate,
         BillMaintenanceID,
         BillValue,
         CurrencyID,
        CurrencyName,
        CurrencySymbol,
        ExchangeRate,
         PaysAmount,
         PaysRemain,
         Bill_ItemsOut_Value,
         Bill_ItemsOut_RealValue,
         Bill_RealValue,
        Bill_Pays_RealValue));

                }

                return list;
            }
            catch (Exception ee)
            {
                throw new Exception("Get_Customer_MaintenanceOPRs_ReportDetail_List_From_DataTable:" + ee.Message);
            }
        }


    }
}
