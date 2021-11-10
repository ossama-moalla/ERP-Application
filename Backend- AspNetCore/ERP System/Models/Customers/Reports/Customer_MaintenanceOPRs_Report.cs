using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Customers.Reports
{
    public class Customer_MaintenanceOPRs_Report
    {
        public int MaintenanceOPRs_Count;
        public int MaintenanceOPRs_EndWork_Count;
        public int MaintenanceOPRs_Repaired_Count;
        public int MaintenanceOPRs_Warranty_Count;
        public int MaintenanceOPRs_EndWarranty_Count;

        public int BillMaintenances_Count;
        public string BillMaintenances_Value;
        public string BillMaintenances_Pays_Value;
        public string BillMaintenances_Pays_Remain;
        public double BillMaintenances_Pays_Remain_UPON_MaintenanceOPRsCurrency;

        public string BillMaintenances_ItemsOut_Value;
        public double BillMaintenances_ItemsOut_RealValue;
        public double BillMaintenances_RealValue;
        public double BillMaintenances_Pays_RealValue;
        public Customer_MaintenanceOPRs_Report(
           int MaintenanceOPRs_Count_,
         int MaintenanceOPRs_EndWork_Count_,
         int MaintenanceOPRs_Repaired_Count_,
         int MaintenanceOPRs_Warranty_Count_,
         int MaintenanceOPRs_EndWarranty_Count_,

           int BillMaintenances_Count_,
         string BillMaintenances_Value_,
         string BillMaintenances_Pays_Value_,
         string BillMaintenances_Pays_Remain_,
         double BillMaintenances_Pays_Remain_UPON_MaintenanceOPRsCurrency_,

         string BillMaintenances_ItemsOut_Value_,
         double BillMaintenances_ItemsOut_RealValue_,
         double BillMaintenances_RealValue_,
         double BillMaintenances_Pays_RealValue_)
        {
            MaintenanceOPRs_Count = MaintenanceOPRs_Count_;
            MaintenanceOPRs_EndWork_Count = MaintenanceOPRs_EndWork_Count_;
            MaintenanceOPRs_Repaired_Count = MaintenanceOPRs_Repaired_Count_;
            MaintenanceOPRs_Warranty_Count = MaintenanceOPRs_Warranty_Count_;
            MaintenanceOPRs_EndWarranty_Count = MaintenanceOPRs_EndWarranty_Count_;

            BillMaintenances_Count = BillMaintenances_Count_;
            BillMaintenances_Value = BillMaintenances_Value_;
            BillMaintenances_Pays_Value = BillMaintenances_Pays_Value_;
            BillMaintenances_Pays_Remain = BillMaintenances_Pays_Remain_;
            BillMaintenances_Pays_Remain_UPON_MaintenanceOPRsCurrency = BillMaintenances_Pays_Remain_UPON_MaintenanceOPRsCurrency_;

            BillMaintenances_ItemsOut_Value = BillMaintenances_ItemsOut_Value_;
            BillMaintenances_ItemsOut_RealValue = BillMaintenances_ItemsOut_RealValue_;
            BillMaintenances_RealValue = BillMaintenances_RealValue_;
            BillMaintenances_Pays_RealValue = BillMaintenances_Pays_RealValue_;
        }
        internal static Customer_MaintenanceOPRs_Report Get_Customer_MaintenanceOPRs_Report_From_DataTable(System.Data.DataTable table)
        {
            try
            {
                int MaintenanceOPRs_Count = Convert.ToInt32(table.Rows[0]["MaintenanceOPRs_Count"]);
                int MaintenanceOPRs_EndWork_Count = Convert.ToInt32(table.Rows[0]["MaintenanceOPRs_EndWork_Count"]);
                int MaintenanceOPRs_Repaired_Count = Convert.ToInt32(table.Rows[0]["MaintenanceOPRs_Repaired_Count"]);
                int MaintenanceOPRs_Warranty_Count = Convert.ToInt32(table.Rows[0]["MaintenanceOPRs_Warranty_Count"]);
                int MaintenanceOPRs_EndWarranty_Count = Convert.ToInt32(table.Rows[0]["MaintenanceOPRs_EndWarranty_Count"]);

                int BillMaintenances_Count = Convert.ToInt32(table.Rows[0]["BillMaintenances_Count"]);
                string BillMaintenances_Value = table.Rows[0]["BillMaintenances_Value"].ToString();
                string BillMaintenances_Pays_Value = table.Rows[0]["BillMaintenances_Pays_Value"].ToString();
                string BillMaintenances_Pays_Remain = table.Rows[0]["BillMaintenances_Pays_Remain"].ToString();
                double BillMaintenances_Pays_Remain_UPON_MaintenanceOPRsCurrency = Convert.ToDouble(table.Rows[0]["MaintenanceOPRs_EndWarranty_Count"]);

                string BillMaintenances_ItemsOut_Value = table.Rows[0]["BillMaintenances_ItemsOut_Value"].ToString();
                double BillMaintenances_ItemsOut_RealValue = Convert.ToDouble(table.Rows[0]["BillMaintenances_ItemsOut_RealValue"]);
                double BillMaintenances_RealValue = Convert.ToDouble(table.Rows[0]["BillMaintenances_RealValue"]);
                double BillMaintenances_Pays_RealValue = Convert.ToDouble(table.Rows[0]["BillMaintenances_Pays_RealValue"]);


                return new Customer_MaintenanceOPRs_Report(MaintenanceOPRs_Count,
                             MaintenanceOPRs_EndWork_Count,
                            MaintenanceOPRs_Repaired_Count,
                            MaintenanceOPRs_Warranty_Count,
                             MaintenanceOPRs_EndWarranty_Count,

                            BillMaintenances_Count,
                            BillMaintenances_Value,
                            BillMaintenances_Pays_Value,
                             BillMaintenances_Pays_Remain,
                            BillMaintenances_Pays_Remain_UPON_MaintenanceOPRsCurrency,

                             BillMaintenances_ItemsOut_Value,
                           BillMaintenances_ItemsOut_RealValue,
                            BillMaintenances_RealValue,
                             BillMaintenances_Pays_RealValue);
            }
            catch (Exception ee)
            {
                throw new Exception("Get_Customer_MaintenanceOPRs_Report_From_DataTable:" + ee.Message);
            }

        }
    }
}
