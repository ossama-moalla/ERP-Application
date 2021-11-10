using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance.Reports
{
    public class Report_MaintenanceOPRs_YearRange_ReportDetail
    {
        public int YearNO;
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
        public Report_MaintenanceOPRs_YearRange_ReportDetail(
                int YearNO_,
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
            YearNO = YearNO_;

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
        internal static List<Report_MaintenanceOPRs_YearRange_ReportDetail> Get_Report_MaintenanceOPRs_YearRange_ReportDetail_From_DataTable(System.Data.DataTable table)
        {
            try
            {
                List<Report_MaintenanceOPRs_YearRange_ReportDetail> list = new List<Report_MaintenanceOPRs_YearRange_ReportDetail>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int YearNO = Convert.ToInt32(table.Rows[i]["YearNO"]);
                    int MaintenanceOPRs_Count = Convert.ToInt32(table.Rows[i]["MaintenanceOPRs_Count"]);
                    int MaintenanceOPRs_EndWork_Count = Convert.ToInt32(table.Rows[i]["MaintenanceOPRs_EndWork_Count"]);
                    int MaintenanceOPRs_Repaired_Count = Convert.ToInt32(table.Rows[i]["MaintenanceOPRs_Repaired_Count"]);
                    int MaintenanceOPRs_Warranty_Count = Convert.ToInt32(table.Rows[i]["MaintenanceOPRs_Warranty_Count"]);
                    int MaintenanceOPRs_EndWarranty_Count = Convert.ToInt32(table.Rows[i]["MaintenanceOPRs_EndWarranty_Count"]);

                    int BillMaintenances_Count = Convert.ToInt32(table.Rows[i]["BillMaintenances_Count"]);
                    string BillMaintenances_Value = table.Rows[i]["BillMaintenances_Value"].ToString();
                    string BillMaintenances_Pays_Value = table.Rows[i]["BillMaintenances_Pays_Value"].ToString();
                    string BillMaintenances_Pays_Remain = table.Rows[i]["BillMaintenances_Pays_Remain"].ToString();
                    double BillMaintenances_Pays_Remain_UPON_MaintenanceOPRsCurrency = Convert.ToDouble(table.Rows[i]["MaintenanceOPRs_EndWarranty_Count"]);

                    string BillMaintenances_ItemsOut_Value = table.Rows[i]["BillMaintenances_ItemsOut_Value"].ToString();
                    double BillMaintenances_ItemsOut_RealValue = Convert.ToDouble(table.Rows[i]["BillMaintenances_ItemsOut_RealValue"]);
                    double BillMaintenances_RealValue = Convert.ToDouble(table.Rows[i]["BillMaintenances_RealValue"]);
                    double BillMaintenances_Pays_RealValue = Convert.ToDouble(table.Rows[i]["BillMaintenances_Pays_RealValue"]);


                    list.Add(new Report_MaintenanceOPRs_YearRange_ReportDetail(
                        YearNO,
                        MaintenanceOPRs_Count,
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
                                 BillMaintenances_Pays_RealValue));

                }
                return list;

            }
            catch (Exception ee)
            {
                throw new Exception("Get_Report_MaintenanceOPRs_YearRange_ReportDetail_List_From_DataTable:" + ee.Message);
            }

        }
    }
}
