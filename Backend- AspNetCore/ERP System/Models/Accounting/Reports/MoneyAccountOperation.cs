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

        public static  List<MoneyAccountOperation> Convert_PayIN_To_MoneyAccountOperation(List<PayIN> PayINList)
        {
            try
            {
                List<MoneyAccountOperation> list = new ();
                for (int i = 0; i < PayINList.Count; i++)
                {
                    string details = string.Empty;
                    if (PayINList[i].OperationId != null && PayINList[i].OperationType != null)
                    {
                        details = "belong to :" + Operation.GetOperationName(Convert.ToInt32(PayINList[i].OperationType))
                            + ",with ID:" + PayINList[i].OperationId;
                    }
                    else details = "not belong to any bill";
                    MoneyAccountOperation moneyaccountoperation = new ()
                    {
                        Id = PayINList[i].Id,
                        Date = PayINList[i].Date,
                        OprType = MoneyAccountOperation.TYPE_PAY_OPR,
                        OprDirection = MoneyAccountOperation.DIRECTION_IN,
                        TradeOperationId = PayINList[i].OperationId,
                        TradeOperationType = PayINList[i].OperationType,
                        Value = PayINList[i].Value,
                        CurrencyID = PayINList[i].Currency.Id,
                        CurrencyName = PayINList[i].Currency.Name,
                        CurrencySymbol = PayINList[i].Currency.Symbol,
                        ExchangeRate = PayINList[i].ExchangeRate,
                        RealValue = Math.Round((PayINList[i].Value / PayINList[i].ExchangeRate), 3),
                        Details = details
                    };
                    list.Add(moneyaccountoperation);
                }
                return list;
            }
            catch(Exception e)
            {
                throw new Exception("MoneyAccountOperation-Convert_PayIN_To_MoneyAccountOperation -Error:" + e);
            } 
        }
        public static List<MoneyAccountOperation> Convert_PayOUT_To_MoneyAccountOperation(List<PayOUT> PayOUTList)
        {
            try
            {
                List<MoneyAccountOperation> list = new ();
                for (int i = 0; i < PayOUTList.Count; i++)
                {
                    string details = string.Empty;
                    if (PayOUTList[i].OperationId != null && PayOUTList[i].OperationType != null)
                    {
                        details = "belong to :" + Operation.GetOperationName(Convert.ToInt32(PayOUTList[i].OperationType))
                            + ",with ID:" + PayOUTList[i].OperationId;
                    }
                    else details = "not belong to any bill or payprder";
                    var moneyaccountoperation = new MoneyAccountOperation()
                    {
                        Id = PayOUTList[i].Id,
                        Date = PayOUTList[i].Date,
                        OprType = MoneyAccountOperation.TYPE_PAY_OPR,
                        OprDirection = MoneyAccountOperation.DIRECTION_OUT,
                        TradeOperationId=PayOUTList[i].OperationId,
                        TradeOperationType= PayOUTList[i].OperationType,
                        Value = PayOUTList[i].Value,
                        CurrencyID = PayOUTList[i].Currency.Id,
                        CurrencyName = PayOUTList[i].Currency.Name,
                        CurrencySymbol = PayOUTList[i].Currency.Symbol,
                        ExchangeRate = PayOUTList[i].ExchangeRate,
                        RealValue = Math.Round((PayOUTList[i].Value / PayOUTList[i].ExchangeRate), 3),
                        Details = details,

                    };
                    list.Add(moneyaccountoperation);
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception("MoneyAccountOperation-Convert_PayOUT_To_MoneyAccountOperation -Error:" + e);
            }
        }
        public static List<MoneyAccountOperation> Convert_ExchangeOPR_To_MoneyAccountOperation(List<ExchangeOPR> ExchangeOPRList)
        {
            try
            {
                List<MoneyAccountOperation> list = new ();
                for (int i = 0; i < ExchangeOPRList.Count; i++)
                {
                    var  moneyaccountoperationOUT = new MoneyAccountOperation()
                    {
                        Id = ExchangeOPRList[i].Id,
                        Date = ExchangeOPRList[i].Date,
                        OprType = MoneyAccountOperation.TYPE_EXCHANGE_OPR,
                        OprDirection = MoneyAccountOperation.DIRECTION_OUT,
                        TradeOperationId = null,
                        TradeOperationType = null,
                        Value = ExchangeOPRList[i].OutMoneyValue,
                        CurrencyID = ExchangeOPRList[i].SourceCurrency.Id,
                        CurrencyName = ExchangeOPRList[i].SourceCurrency.Name,
                        CurrencySymbol = ExchangeOPRList[i].SourceCurrency.Symbol,
                        ExchangeRate = ExchangeOPRList[i].SourceExchangeRate,
                        RealValue = Math.Round((ExchangeOPRList[i].OutMoneyValue / ExchangeOPRList[i].SourceExchangeRate), 3),
                        Details = "Exchange from :" + ExchangeOPRList[i].SourceCurrency.Name + " to:" + ExchangeOPRList[i].TargetCurrency.Name


                    };
                    list.Add(moneyaccountoperationOUT);
                    var moneyaccountoperationIN = new MoneyAccountOperation()
                    {
                        Id = ExchangeOPRList[i].Id,
                        Date = ExchangeOPRList[i].Date,
                        OprType = MoneyAccountOperation.TYPE_EXCHANGE_OPR,
                        OprDirection = MoneyAccountOperation.DIRECTION_IN,
                        TradeOperationId = null,
                        TradeOperationType = null,
                        Value = Math.Round( ExchangeOPRList[i].OutMoneyValue
                            *(ExchangeOPRList[i].TargetExchangeRate/ ExchangeOPRList[i].SourceExchangeRate),3),
                        CurrencyID = ExchangeOPRList[i].TargetCurrency.Id,
                        CurrencyName = ExchangeOPRList[i].TargetCurrency.Name,
                        CurrencySymbol = ExchangeOPRList[i].TargetCurrency.Symbol,
                        ExchangeRate = ExchangeOPRList[i].TargetExchangeRate,
                        RealValue = Math.Round((ExchangeOPRList[i].OutMoneyValue / ExchangeOPRList[i].SourceExchangeRate), 3),
                        Details = "Exchange from :" + ExchangeOPRList[i].SourceCurrency.Name + " to:" + ExchangeOPRList[i].TargetCurrency.Name

                    };
                    list.Add(moneyaccountoperationIN);
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception("MoneyAccountOperation-Convert_ExchangeOPR_To_MoneyAccountOperation -Error:" + e);
            }
        }
        public static List<MoneyAccountOperation> Convert_MoneyTransformOPR_To_MoneyAccountOperation(int moneyAccountID, List<MoneyTransFormOPR> MoneyTransFormOPRList)
        {
            try
            {
                List<MoneyAccountOperation> list = new ();

                var MoneyTransFormOPRList_IN = MoneyTransFormOPRList.Where(x => x.TargetMoneyAccountId == moneyAccountID).ToList();
                var MoneyTransFormOPRList_OUT = MoneyTransFormOPRList.Where(x => x.SourceMoneyAccountId == moneyAccountID).ToList();

                for (int i = 0; i < MoneyTransFormOPRList_IN.Count; i++)
                {
                    var moneyaccountoperation = new MoneyAccountOperation()
                    {
                        Id = MoneyTransFormOPRList_IN[i].Id,
                        Date = MoneyTransFormOPRList_IN[i].Date,
                        OprType = MoneyAccountOperation.TYPE_MoneyTransform_OPR,
                        OprDirection = MoneyAccountOperation.DIRECTION_IN,
                        TradeOperationId =null,
                        TradeOperationType =null,
                        Value = MoneyTransFormOPRList_IN[i].Value,
                        CurrencyID = MoneyTransFormOPRList_IN[i].Currency.Id,
                        CurrencyName = MoneyTransFormOPRList_IN[i].Currency.Name,
                        CurrencySymbol = MoneyTransFormOPRList_IN[i].Currency.Symbol,
                        ExchangeRate = MoneyTransFormOPRList_IN[i].ExchangeRate,
                        RealValue = Math.Round((MoneyTransFormOPRList_IN[i].Value / MoneyTransFormOPRList_IN[i].ExchangeRate), 3),
                        Details = "transformed from :" + MoneyTransFormOPRList_IN[i].SourceMoneyAccount.Name,

                    };
                    list.Add(moneyaccountoperation);
                }
                for (int i = 0; i < MoneyTransFormOPRList_OUT.Count; i++)
                {
                    var moneyaccountoperation = new MoneyAccountOperation()
                    {
                        Id = MoneyTransFormOPRList_OUT[i].Id,
                        Date = MoneyTransFormOPRList_OUT[i].Date,
                        OprType = MoneyAccountOperation.TYPE_MoneyTransform_OPR,
                        OprDirection = MoneyAccountOperation.DIRECTION_OUT,
                        TradeOperationId = null,
                        TradeOperationType = null,
                        Value = MoneyTransFormOPRList_OUT[i].Value,
                        CurrencyID = MoneyTransFormOPRList_OUT[i].Currency.Id,
                        CurrencyName = MoneyTransFormOPRList_OUT[i].Currency.Name,
                        CurrencySymbol = MoneyTransFormOPRList_OUT[i].Currency.Symbol,
                        ExchangeRate = MoneyTransFormOPRList_OUT[i].ExchangeRate,
                        RealValue = Math.Round((MoneyTransFormOPRList_OUT[i].Value / MoneyTransFormOPRList_OUT[i].ExchangeRate), 3),
                        Details = "transformed to :" + MoneyTransFormOPRList_OUT[i].TargetMoneyAccount.Name,

                    };
                    list.Add(moneyaccountoperation);
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception("MoneyAccountOperation-Convert_MoneyTransformOPR_To_MoneyAccountOperation -Error:" + e);
            }
        }
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
                        MoneyIN_FromSells = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_SELL).Sum(x => x.Value),
                        MoneyIN_FromMaintenance = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_MAINTENANCE).Sum(x => x.Value),
                        MoneyIN_FromExchangeOPR = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_EXCHANGE_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value),
                        MoneyIN_FromMoneyTransform = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_MoneyTransform_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value),
                        MoneyIN_FromOther = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_IN && x.TradeOperationType == null).Sum(x => x.Value),

                        MoneyOUT_ByBuy = operations_currency_List.Where(x => x.OprType == MoneyAccountOperation.TYPE_PAY_OPR && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT && x.TradeOperationType != null && x.TradeOperationType == Operation.BILL_BUY).Sum(x => x.Value),
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
        public static double Get_Clear_MoneyValue_ByCurrency(int CurrencyID, List<MoneyAccountOperation> list)
        {
            List< MoneyAccountOperation> list_bycurrency = list.Where(x =>x.CurrencyID== CurrencyID).ToList();
            double currency_money_in = list_bycurrency.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value);
            double currency_money_out = list_bycurrency.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value);
            return currency_money_in - currency_money_out;
        }
        public static string Get_Clear_MoneyValue(List<MoneyAccountOperation> list)
        {
            string return_value = string.Empty;
            List<int> currencyIdList = list.Select(x => x.CurrencyID).Distinct().ToList();
            for (int i = 0; i < currencyIdList.Count; i++)
            {
                string symbol = list.Where(x => x.CurrencyID == currencyIdList[i]).ToList()[0].CurrencySymbol;
                double currency_money_in = list.Where(x => x.CurrencyID == currencyIdList[i]&&x.OprDirection==MoneyAccountOperation.DIRECTION_IN).Sum(x=>x.Value);
                double currency_money_out = list.Where(x => x.CurrencyID == currencyIdList[i] && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value);
                return_value += (currency_money_in- currency_money_out)  + symbol;
                if (i != currencyIdList.Count - 1) return_value += " , ";

            }
            return return_value;
        }
        public static string Get_MoneyIN_Value(List<MoneyAccountOperation> list)
        {
            string return_value = string.Empty;
            var in_list = list.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_IN).ToList();
            List<int> currencyIdList = list.Select(x => x.CurrencyID).Distinct().ToList();
            for(int i = 0; i < currencyIdList.Count; i++)
            {
                var currency_in_list = in_list.Where(x => x.CurrencyID == currencyIdList[i]).ToList();
                double value = currency_in_list.Sum(x => x.Value);
                return_value += value + " " + currency_in_list[0].CurrencySymbol;
                if (i != currencyIdList.Count - 1) return_value += " - ";

            }
            return return_value;
        }
        public static string Get_MoneyOUT_Value(List<MoneyAccountOperation> list)
        {
            string return_value = string.Empty;
            var out_list = list.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).ToList();
            List<int> currencyIdList = list.Select(x => x.CurrencyID).Distinct().ToList();
            for (int i = 0; i < currencyIdList.Count; i++)
            {
                var currency_in_list = out_list.Where(x => x.CurrencyID == currencyIdList[i]).ToList();
                double value = currency_in_list.Sum(x => x.Value);
                return_value += value + " " + currency_in_list[0].CurrencySymbol;
                if (i != currencyIdList.Count - 1) return_value += " - ";

            }
            return return_value;
        }
    }
}
