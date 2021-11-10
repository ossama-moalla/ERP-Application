using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Customers.Reports
{
    public class Customer_Sells_Report
    {
        public int Bills_Count;
        public string Bills_Value;
        public string Bills_Pays_Value;
        public string Bills_Pays_Remain;
        public double Bills_Pays_Remain_UPON_BillsCurrency;
        public string Bills_ItemsIN_Value;
        public double Bills_ItemsIN_RealValue;
        public double Bills_RealValue;
        public double Bills_Pays_RealValue;
        public Customer_Sells_Report(
          int Bills_Count_,
         string Bills_Value_,
         string Bills_Pays_Value_,
         string Bills_Pays_Remain_,
         double Bills_Pays_Remain_UPON_BillsCurrency_,
         string Bills_ItemsIN_Value_,
         double Bills_ItemsIN_RealValue_,
         double Bills_RealValue_,
         double Bills_Pays_RealValue_)
        {

            Bills_Count = Bills_Count_;
            Bills_Value = Bills_Value_;
            Bills_Pays_Value = Bills_Pays_Value_;
            Bills_Pays_Remain = Bills_Pays_Remain_;
            Bills_Pays_Remain_UPON_BillsCurrency = Bills_Pays_Remain_UPON_BillsCurrency_;
            Bills_ItemsIN_Value = Bills_ItemsIN_Value_;
            Bills_ItemsIN_RealValue = Bills_ItemsIN_RealValue_;
            Bills_RealValue = Bills_RealValue_;
            Bills_Pays_RealValue = Bills_Pays_RealValue_;
        }
        internal static Customer_Sells_Report Get_Customer_Sells_Report_From_DataTable(System.Data.DataTable table)
        {

            try
            {


                int Bills_Count = Convert.ToInt32(table.Rows[0]["Bills_Count"]);
                string Bills_Value = table.Rows[0]["Bills_Value"].ToString();
                string Bills_Pays_Value = table.Rows[0]["Bills_Pays_Value"].ToString();
                string Bills_Pays_Remain = table.Rows[0]["Bills_Pays_Remain"].ToString();
                double Bills_Pays_Remain_UPON_BillsCurrency = Convert.ToDouble(table.Rows[0]["Bills_Pays_Remain_UPON_BillsCurrency"]);
                string Bills_ItemsIN_Value = table.Rows[0]["Bills_ItemsIN_Value"].ToString();
                double Bills_ItemsIN_RealValue = Convert.ToDouble(table.Rows[0]["Bills_ItemsIN_RealValue"]);
                double Bills_RealValue = Convert.ToDouble(table.Rows[0]["Bills_RealValue"]);
                double Bills_Pays_RealValue = Convert.ToDouble(table.Rows[0]["Bills_Pays_RealValue"]);


                return new Customer_Sells_Report(Bills_Count, Bills_Value, Bills_Pays_Value, Bills_Pays_Remain,
         Bills_Pays_Remain_UPON_BillsCurrency, Bills_ItemsIN_Value, Bills_ItemsIN_RealValue, Bills_RealValue,
        Bills_Pays_RealValue);
            }
            catch (Exception ee)
            {
                throw new Exception("Get_Customer_Sells_Report_From_DataTable:" + ee.Message);
            }
        }
    }
}
