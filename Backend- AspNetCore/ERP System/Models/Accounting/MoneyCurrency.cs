using ERP_System.Models.HR;
using ERP_System.Models.HR.Reports;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    public class MoneyCurrency
    {
        public Currency _Currency;
        public double Value;
        public double ExchangeRate;
        public MoneyCurrency(Currency Currency_,
         double Value_,
         double ExchangeRate_)
        {
            _Currency = Currency_;
            Value = Value_;
            ExchangeRate = ExchangeRate_;
        }
        public static string ConvertMoney_CurrencyList_TOString(List<MoneyCurrency> Money_CurrencyList)
        {
            string returnstring = "";
            try
            {
                List<Currency> currencyList = Money_CurrencyList.Select(x => x._Currency).ToList();
                List<uint> currencylist = Money_CurrencyList.Select(x => x._Currency.CurrencyID).Distinct().ToList();
                for (int i = 0; i < currencylist.Count; i++)
                {
                    Currency currency = currencyList.Where(y => y.CurrencyID == currencylist[i]).ToList()[0];
                    returnstring += Math.Round(Money_CurrencyList.Where(x => x._Currency.CurrencyID == currencylist[i]).Sum(y => y.Value), 3)
                        + currency.CurrencySymbol;
                    if (i < currencyList.Count - 1) returnstring += " , ";
                }
            }
            catch
            {
                //MessageBox.Show("ConvertMoney_CurrencyList_TOString:", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (returnstring.Length == 0) return " - ";
            else return returnstring;
        }
        public static List<MoneyCurrency> Get_Money_Currency_List_From_MoneyTransform(List<MoneyTransFormOPR> MoneyTransFormOPRList)
        {
            List<MoneyCurrency> Money_CurrencyList = new List<MoneyCurrency>();
            try
            {

                for (int i = 0; i < MoneyTransFormOPRList.Count; i++)
                {
                    Money_CurrencyList.Add(new MoneyCurrency(MoneyTransFormOPRList[i]._Currency, MoneyTransFormOPRList[i].Value, MoneyTransFormOPRList[i].ExchangeRate));
                }
            }
            catch
            {
                //MessageBox.Show("Get_Money_Currency_List_From_PayIN:", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return Money_CurrencyList;
        }
        public static List<MoneyCurrency> Get_Money_Currency_List_From_PayIN(List<PayIN> PayINList)
        {
            List<MoneyCurrency> Money_CurrencyList = new List<MoneyCurrency>();
            try
            {

                for (int i = 0; i < PayINList.Count; i++)
                {
                    Money_CurrencyList.Add(new MoneyCurrency(PayINList[i]._Currency, PayINList[i].Value, PayINList[i].ExchangeRate));
                }
            }
            catch
            {
                //MessageBox.Show("Get_Money_Currency_List_From_PayIN:", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return Money_CurrencyList;
        }
        public static List<MoneyCurrency> Get_Money_Currency_List_From_PayOUT(List<PayOUT> PayOUTList)
        {
            List<MoneyCurrency> Money_CurrencyList = new List<MoneyCurrency>();
            try
            {

                for (int i = 0; i < PayOUTList.Count; i++)
                {
                    Money_CurrencyList.Add(new MoneyCurrency(PayOUTList[i]._Currency, PayOUTList[i].Value, PayOUTList[i].ExchangeRate));
                }
            }
            catch
            {
               // MessageBox.Show("Get_Money_Currency_List_From_PayIN:", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return Money_CurrencyList;
        }

        public static List<MoneyCurrency> Get_Money_Currency_List_From_ExchangeOPR_INDirection(List<ExchangeOPR> ExchangeOPRList)
        {
            List<MoneyCurrency> Money_CurrencyList = new List<MoneyCurrency>();
            try
            {

                for (int i = 0; i < ExchangeOPRList.Count; i++)
                {
                    Money_CurrencyList.Add(new MoneyCurrency(ExchangeOPRList[i].TargetCurrency, ExchangeOPRList[i].OutMoneyValue * (ExchangeOPRList[i].TargetExchangeRate / ExchangeOPRList[i].SourceExchangeRate), ExchangeOPRList[i].TargetExchangeRate));
                }
            }
            catch
            {
                //MessageBox.Show("Get_Money_Currency_List_From_ExchangeOPR_INDirection:", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return Money_CurrencyList;
        }
        public static List<MoneyCurrency> Get_Money_Currency_List_From_ExchangeOPR_OUTDirection(List<ExchangeOPR> ExchangeOPRList)
        {
            List<MoneyCurrency> Money_CurrencyList = new List<MoneyCurrency>();
            try
            {

                for (int i = 0; i < ExchangeOPRList.Count; i++)
                {
                    Money_CurrencyList.Add(new MoneyCurrency(ExchangeOPRList[i].SourceCurrency, ExchangeOPRList[i].OutMoneyValue, ExchangeOPRList[i].SourceExchangeRate));
                }
            }
            catch
            {
               // MessageBox.Show("Get_Money_Currency_List_From_ExchangeOPR_OUTDirection:", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return Money_CurrencyList;
        }


        public static List<MoneyCurrency> Get_Money_Currency_List_From_ItemOUT(List<ItemOUT> ItemOUTList)
        {
            List<MoneyCurrency> Money_CurrencyList = new List<MoneyCurrency>();
            try
            {

                for (int i = 0; i < ItemOUTList.Count; i++)
                {
                    Money_CurrencyList.Add(new MoneyCurrency(ItemOUTList[i]._OUTValue._Currency, ItemOUTList[i]._OUTValue.Value * ItemOUTList[i].Amount, ItemOUTList[i]._OUTValue.ExchangeRate));
                }
            }
            catch
            {
                //MessageBox.Show("Get_Money_Currency_List_From_PayIN:", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return Money_CurrencyList;
        }
        public static List<MoneyCurrency> Get_Money_Currency_List_From_ItemIN(List<ItemIN> ItemINList)
        {
            List<MoneyCurrency> Money_CurrencyList = new List<MoneyCurrency>();
            try
            {

                for (int i = 0; i < ItemINList.Count; i++)
                {
                    Money_CurrencyList.Add(new MoneyCurrency(ItemINList[i]._INCost._Currency, ItemINList[i]._INCost.Value, ItemINList[i]._INCost.ExchangeRate));
                }
            }
            catch
            {
               // MessageBox.Show("Get_Money_Currency_List_From_PayIN:", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return Money_CurrencyList;
        }
        public static List<MoneyCurrency> Get_Money_Currency_List_From_ItemIN_By_ItemOUTList(List<ItemOUT> ItemOUTList)
        {
            List<MoneyCurrency> Money_CurrencyList = new List<MoneyCurrency>();
            try
            {

                for (int i = 0; i < ItemOUTList.Count; i++)
                {
                    Money_CurrencyList.Add(new MoneyCurrency(ItemOUTList[i]._ItemIN._INCost._Currency,
                        ItemOUTList[i]._ItemIN._INCost.Value * (ItemOUTList[i]._ConsumeUnit.Factor / ItemOUTList[i]._ItemIN._ConsumeUnit.Factor), ItemOUTList[i]._ItemIN._INCost.ExchangeRate));
                }
            }
            catch
            {
                //MessageBox.Show("Get_Money_Currency_List_From_PayIN:", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return Money_CurrencyList;
        }

        public static List<MoneyCurrency> Get_Money_Currency_List_From_EmployeePayOrder(List<EmployeePayOrder> employeePayOrderList)
        {
            List<MoneyCurrency> Money_CurrencyList = new List<MoneyCurrency>();
            try
            {

                for (int i = 0; i < employeePayOrderList.Count; i++)
                {
                    Money_CurrencyList.Add(new MoneyCurrency(employeePayOrderList[i]._Currency, employeePayOrderList[i].Value, employeePayOrderList[i].ExchangeRate));
                }
            }
            catch
            {
                //MessageBox.Show("Get_Money_Currency_List_From_PayIN:", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return Money_CurrencyList;
        }
        public static List<MoneyCurrency> Get_Money_Currency_List_From_PayOrderReport(List<PayOrderReport> PayOrderReportList)
        {
            List<MoneyCurrency> Money_CurrencyList = new List<MoneyCurrency>();
            try
            {

                for (int i = 0; i < PayOrderReportList.Count; i++)
                {
                    Money_CurrencyList.Add(new MoneyCurrency(PayOrderReportList[i]._Currency, PayOrderReportList[i].Value, PayOrderReportList[i].ExchangeRate));
                }
            }
            catch
            {
                //MessageBox.Show("Get_Money_Currency_List_From_PayOrderReport:", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return Money_CurrencyList;
        }

    }
}
