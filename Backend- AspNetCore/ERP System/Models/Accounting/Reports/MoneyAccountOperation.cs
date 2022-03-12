using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting.Reports
{
    public class MoneyAccountOperation
    {
        public const short DIRECTION_IN = 0;
        public const short DIRECTION_OUT = 1;

        public const short TYPE_PAY_OPR = 0;
        public const short TYPE_EXCHANGE_OPR = 1;
        public const short TYPE_MoneyTransform_OPR = 2;

        public int Id { get; set; }
        public DateTime Date{ get; set; }
        public int MoneyAccountId { get; set; }
        public short OprType{ get; set; }
        public short OprDirection{ get; set; }
        public int? TradeOperationId { get; set; }
        public int? TradeOperationType { get; set; }
        public double Value{ get; set; }
        public int CurrencyID{ get; set; }
        public string CurrencyName{ get; set; }
        public string CurrencySymbol{ get; set; }
        public double ExchangeRate{ get; set; }
        public double RealValue{ get; set; }
        public string Details { get; set; }

        
        public static List<MoneyAccount_CurrencyReport> Convert_MoneyAccountOperation_To_CurrencyReport(List<MoneyAccountOperation> operationList)
        {
            try
            {
                var CurrencyReportList = new List<MoneyAccount_CurrencyReport>();
                List<int> CurrencyIdList = operationList.Select(x => x.CurrencyID).Distinct().ToList();
                for (int i = 0; i < CurrencyIdList.Count; i++)
                {
                    var operations_currency_List = operationList.Where(x => x.CurrencyID == CurrencyIdList[i]).ToList();
                    var moneyAccount_CurrencyReport = new MoneyAccount_CurrencyReport()
                    {
                        CurrencyID = operations_currency_List[0].CurrencyID,
                        CurrencyName = operations_currency_List[0].CurrencyName,
                        CurrencySymbol = operations_currency_List[0].CurrencySymbol,
                        MoneyIN_FromSells = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType != null && x.TradeOperationType == Operation.SALES_BILL).Sum(x => x.Value),
                        MoneyIN_FromMaintenance = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType != null && x.TradeOperationType == Operation.MAINTENANCE_BILL).Sum(x => x.Value),
                        MoneyIN_FromExchangeOPR = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value),
                        MoneyIN_FromMoneyTransform = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value),
                        MoneyIN_FromOther = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType == null).Sum(x => x.Value),

                        MoneyOUT_ByBuy = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType != null && x.TradeOperationType == Operation.PURCHASES_BILL).Sum(x => x.Value),
                        MoneyOUT_ByEmpPayOrders = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType != null && x.TradeOperationType == Operation.Employee_PayOrder).Sum(x => x.Value),
                        MoneyOUT_ByExchangeOPR = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value),
                        MoneyOUT_ByMoneyTransform = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value),
                        MoneyOUT_ByOther = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType == null).Sum(x => x.Value),


                    };
                    CurrencyReportList.Add(moneyAccount_CurrencyReport);
                }
                return CurrencyReportList;
            }
            catch(Exception e)
            {
                throw new Exception("MoneyAccountOperation-Convert_MoneyAccountOperation_To_CurrencyReport - Error:" + e);
            }
        }
        public static string Calculate_Operations_MoneyIN_Value(List<MoneyAccountOperation> list)
        {
            string return_value = string.Empty;
            var in_list = list.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_IN).ToList();
            List<int> currencyIdList = list.Select(x => x.CurrencyID).Distinct().ToList();
            for (int i = 0; i < currencyIdList.Count; i++)
            {
                var currency_in_list = in_list.Where(x => x.CurrencyID == currencyIdList[i]).ToList();
                double value = currency_in_list.Sum(x => x.Value);
                return_value += value + " " + currency_in_list[0].CurrencySymbol;
                if (i != currencyIdList.Count - 1) return_value += " , ";

            }
            return return_value;
        }
        public static string Calculate_Operations_MoneyOUT_Value(List<MoneyAccountOperation> list)
        {
            string return_value = string.Empty;
            var out_list = list.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).ToList();
            List<int> currencyIdList = list.Select(x => x.CurrencyID).Distinct().ToList();
            for (int i = 0; i < currencyIdList.Count; i++)
            {
                var currency_in_list = out_list.Where(x => x.CurrencyID == currencyIdList[i]).ToList();
                double value = currency_in_list.Sum(x => x.Value);
                return_value += value + " " + currency_in_list[0].CurrencySymbol;
                if (i != currencyIdList.Count - 1) return_value += " , ";

            }
            return return_value;
        }
    }
}
