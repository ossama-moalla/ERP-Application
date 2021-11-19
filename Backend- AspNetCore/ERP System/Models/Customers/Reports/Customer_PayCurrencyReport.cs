using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Customers.Reports
{
    public class Customer_PayCurrencyReport
    {
        public int CurrencyID;
        public string CurrencyName;
        public string CurrencySymbol;
        public double PaysIN_Sell;
        public double PaysIN_Maintenance;
        public double PaysOUT_Buy;


        public Customer_PayCurrencyReport(int CurrencyID_, string CurrencyName_, string CurrencySymbol_,
        double PaysIN_Sell_, double PaysIN_Maintenance_, double PaysOUT_Buy_)
        {
            CurrencyID = CurrencyID_;
            CurrencyName = CurrencyName_;
            CurrencySymbol = CurrencySymbol_;
            PaysIN_Sell = PaysIN_Sell_;
            PaysIN_Maintenance = PaysIN_Maintenance_;
            PaysOUT_Buy = PaysOUT_Buy_;
        }
        internal static List<Customer_PayCurrencyReport> Get_Customer_PayCurrencyReport_List_From_DataTable(System.Data.DataTable table)
        {

            try
            {
                List<Customer_PayCurrencyReport> list = new List<Customer_PayCurrencyReport>();
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    int CurrencyID = Convert.ToInt32(table.Rows[i]["CurrencyID"]);
                    string CurrencyName = table.Rows[i]["CurrencyName"].ToString();
                    string CurrencySymbol = table.Rows[i]["CurrencySymbol"].ToString();
                    double PaysIN_Sell = Convert.ToDouble(table.Rows[i]["PaysIN_Sell"]);
                    double PaysIN_Maintenance = Convert.ToDouble(table.Rows[i]["PaysIN_Maintenance"]);
                    double PaysOUT_Buy = Convert.ToDouble(table.Rows[i]["PaysOUT_Buy"]);

                    list.Add(new Customer_PayCurrencyReport(CurrencyID, CurrencyName, CurrencySymbol, PaysIN_Sell
                        , PaysIN_Maintenance, PaysOUT_Buy));
                }
                return list;
            }
            catch (Exception ee)
            {
                throw new Exception("Get_Customer_PayCurrencyReport_List_From_DataTable:" + ee.Message);
            }
        }
    }
}
