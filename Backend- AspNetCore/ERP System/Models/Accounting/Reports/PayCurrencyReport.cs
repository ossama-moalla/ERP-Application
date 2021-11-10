using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting.Reports
{
    public class PayCurrencyReport
    {
        public uint CurrencyID;
        public string CurrencyName;
        public string CurrencySymbol;

        public double PaysIN_Sell;
        public double PaysIN_Maintenance;
        public double PaysIN_MoneyTransform;
        public double PaysIN_NON;
        public double PaysIN_Exchange;
        public double PaysOUT_Buy;
        public double PaysOUT_Emp;
        public double PaysOUT_MoneyTransform;
        public double PaysOUT_NON;
        public double PaysOUT_Exchange;

        public PayCurrencyReport(

         uint CurrencyID_,
         string CurrencyName_,
         string CurrencySymbol_,
         double PaysIN_Sell_,
         double PaysIN_Maintenance_,
         double PaysIN_MoneyTransform_,
        double PaysIN_NON_,
         double PaysIN_Exchange_,
         double PaysOUT_Buy_,
         double PaysOUT_Emp_,
         double PaysOUT_MoneyTransform_,
        double PaysOUT_NON_,
         double PaysOUT_Exchange_)
        {
            CurrencyID = CurrencyID_;
            CurrencyName = CurrencyName_;
            CurrencySymbol = CurrencySymbol_;
            PaysIN_Sell = PaysIN_Sell_;
            PaysIN_Maintenance = PaysIN_Maintenance_;
            PaysIN_MoneyTransform = PaysIN_MoneyTransform_;
            PaysIN_NON = PaysIN_NON_;
            PaysIN_Exchange = PaysIN_Exchange_;
            PaysOUT_Buy = PaysOUT_Buy_;
            PaysOUT_Emp = PaysOUT_Emp_;
            PaysOUT_MoneyTransform = PaysOUT_MoneyTransform_;
            PaysOUT_NON = PaysOUT_NON_;
            PaysOUT_Exchange = PaysOUT_Exchange_;
        }
        internal static List<PayCurrencyReport> Get_PayCurrencyReport_List_From_DataTable(System.Data.DataTable table)
        {
            try
            {

                List<PayCurrencyReport> list = new List<PayCurrencyReport>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    uint CurrencyID = Convert.ToUInt32(table.Rows[i]["CurrencyID"]);
                    string CurrencyName = table.Rows[i]["CurrencyName"].ToString();
                    string CurrencySymbol = table.Rows[i]["CurrencySymbol"].ToString();

                    double PaysIN_Sell = Convert.ToDouble(table.Rows[i]["PaysIN_Sell"]);

                    double PaysIN_Maintenance = Convert.ToDouble(table.Rows[i]["PaysIN_Maintenance"]);

                    double PaysIN_MoneyTransform = Convert.ToDouble(table.Rows[i]["PaysIN_MoneyTransform"]);

                    double PaysIN_NON = Convert.ToDouble(table.Rows[i]["PaysIN_NON"]);

                    double PaysIN_Exchange = Convert.ToDouble(table.Rows[i]["PaysIN_Exchange"]);

                    double PaysOUT_Buy = Convert.ToDouble(table.Rows[i]["PaysOUT_Buy"]);

                    double PaysOUT_Emp = Convert.ToDouble(table.Rows[i]["PaysOUT_Emp"]);

                    double PaysOUT_MoneyTransform = Convert.ToDouble(table.Rows[i]["PaysOUT_MoneyTransform"]);

                    double PaysOUT_NON = Convert.ToDouble(table.Rows[i]["PaysOUT_NON"]);

                    double PaysOUT_Exchange = Convert.ToDouble(table.Rows[i]["PaysOUT_Exchange"]);


                    list.Add(new PayCurrencyReport(CurrencyID, CurrencyName, CurrencySymbol, PaysIN_Sell, PaysIN_Maintenance, PaysIN_MoneyTransform
                        , PaysIN_NON, PaysIN_Exchange, PaysOUT_Buy, PaysOUT_Emp, PaysOUT_MoneyTransform, PaysOUT_NON, PaysOUT_Exchange));

                }
                return list;

            }
            catch (Exception ee)
            {
                throw new Exception("Get_PayCurrencyReport_List_From_DataTable:" + ee.Message);
            }
        }
    }
}
