using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Customers.Reports
{
    public class Customer_BillCurrencyReport
    {
        public uint CurrencyID;
        public string CurrencyName;
        public string CurrencySymbol;
        public int BillINCount;
        public double BillINValue;
        public double BillIN_PaysValue;
        public int BillMaintenanceCount;
        public double BillMaintenanceValue;
        public double BillMaintenance_PaysValue;
        public int BillOUTCount;
        public double BillOUTValue;
        public double BillOUT_PaysValue;
        public Customer_BillCurrencyReport(
               uint CurrencyID_,
         string CurrencyName_,
         string CurrencySymbol_,
        int BillINCount_,
         double BillINValue_,
         double BillIN_PaysValue_,
         int BillMaintenanceCount_,
         double BillMaintenanceValue_,
         double BillMaintenance_PaysValue_,
         int BillOUTCount_,
         double BillOUTValue_,
         double BillOUT_PaysValue_)
        {
            CurrencyID = CurrencyID_;
            CurrencyName = CurrencyName_;
            CurrencySymbol = CurrencySymbol_;

            BillINCount = BillINCount_;
            BillINValue = BillINValue_;
            BillIN_PaysValue = BillIN_PaysValue_;
            BillMaintenanceCount = BillMaintenanceCount_;
            BillMaintenanceValue = BillMaintenanceValue_;
            BillMaintenance_PaysValue = BillMaintenance_PaysValue_;
            BillOUTCount = BillOUTCount_; ;
            BillOUTValue = BillOUTValue_;
            BillOUT_PaysValue = BillOUT_PaysValue_;
        }
        internal static List<Customer_BillCurrencyReport> Get_Customer_BillCurrencyReport_From_DataTable(System.Data.DataTable table)
        {

            try
            {
                List<Customer_BillCurrencyReport> list = new List<Customer_BillCurrencyReport>();


                ;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    uint CurrencyID = Convert.ToUInt32(table.Rows[i]["CurrencyID"]);
                    string CurrencyName = table.Rows[i]["CurrencyName"].ToString();
                    string CurrencySymbol = table.Rows[i]["CurrencySymbol"].ToString();
                    int BillINCount = Convert.ToInt32(table.Rows[i]["BillINCount"]);
                    double BillINValue = Convert.ToDouble(table.Rows[i]["BillINValue"]);
                    double BillIN_PaysValue = Convert.ToDouble(table.Rows[i]["BillIN_PaysValue"]);
                    int BillMaintenanceCount = Convert.ToInt32(table.Rows[i]["BillMaintenanceCount"]);
                    double BillMaintenanceValue = Convert.ToDouble(table.Rows[i]["BillMaintenanceValue"]);
                    double BillMaintenance_PaysValue = Convert.ToDouble(table.Rows[i]["BillMaintenance_PaysValue"]);
                    int BillOUTCount = Convert.ToInt32(table.Rows[i]["BillOUTCount"]);
                    double BillOUTValue = Convert.ToDouble(table.Rows[i]["BillOUTValue"]);
                    double BillOUT_PaysValue = Convert.ToDouble(table.Rows[i]["BillOUT_PaysValue"]);
                    list.Add(new Customer_BillCurrencyReport(CurrencyID,
                                 CurrencyName,
                                 CurrencySymbol,
                                BillINCount,
                                 BillINValue,
                                 BillIN_PaysValue,
                                BillMaintenanceCount,
                               BillMaintenanceValue,
                                 BillMaintenance_PaysValue,
                                 BillOUTCount,
                                BillOUTValue,
                                BillOUT_PaysValue));
                }
                return list;
            }
            catch (Exception ee)
            {
                throw new Exception("Get_Contact_Buys_ReportDetail_AS_DataTable:" + ee.Message);
            }
        }
    }
}
