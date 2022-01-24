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

        public DateTime OprTime{ get; set; }
        public short OprType{ get; set; }
        public short OprDirection{ get; set; }
        public int OprID{ get; set; }
        public int? TradeOperationId{ get; set; }
        public int? TradeOperationType { get; set; }

        public double Value{ get; set; }
        public int CurrencyID{ get; set; }
        public string CurrencyName{ get; set; }
        public string CurrencySymbol{ get; set; }
        public double ExchangeRate{ get; set; }
        public double RealValue{ get; set; }

        public static  List<MoneyAccountOperation> Convert_PayIN_To_MoneyAccountOperation(List<PayIN> PayINList)
        {
            try
            {
                List<MoneyAccountOperation> list = new List<MoneyAccountOperation>();
                for (int i = 0; i < PayINList.Count; i++)
                {
                    
                    MoneyAccountOperation moneyaccountoperation = new MoneyAccountOperation()
                    {
                        OprTime = PayINList[i].Date,
                        OprType = MoneyAccountOperation.TYPE_PAY_OPR,
                        OprDirection = MoneyAccountOperation.DIRECTION_IN,
                        OprID = PayINList[i].Id,
                        TradeOperationId = PayINList[i].OperationId,
                        TradeOperationType= PayINList[i].OperationType,
                        Value = PayINList[i].Value,
                        CurrencyID = PayINList[i].Currency.Id,
                        CurrencyName = PayINList[i].Currency.Name,
                        CurrencySymbol = PayINList[i].Currency.Symbol,
                        ExchangeRate = PayINList[i].ExchangeRate,
                        RealValue = Math.Round((PayINList[i].Value / PayINList[i].ExchangeRate), 3)

                    };
                    list.Add(moneyaccountoperation);
                }
                return list;
            }
            catch(Exception e)
            {
                throw new Exception("MoneyAccountOperation-Convert_PayIN_To_MoneyAccountOperation Error:" + e);
            } 
        }
        public static List<MoneyAccountOperation> Convert_PayOUT_To_MoneyAccountOperation(List<PayOUT> PayOUTList)
        {
            try
            {
                List<MoneyAccountOperation> list = new List<MoneyAccountOperation>();
                for (int i = 0; i < PayOUTList.Count; i++)
                {
                   
                    MoneyAccountOperation moneyaccountoperation = new MoneyAccountOperation()
                    {
                        OprTime = PayOUTList[i].Date,
                        OprType = MoneyAccountOperation.TYPE_PAY_OPR,
                        OprDirection = MoneyAccountOperation.DIRECTION_OUT,
                        OprID = PayOUTList[i].Id,
                        TradeOperationId = PayOUTList[i].OperationId,
                        TradeOperationType = PayOUTList[i].OperationType,
                        Value = PayOUTList[i].Value,
                        CurrencyID = PayOUTList[i].Currency.Id,
                        CurrencyName = PayOUTList[i].Currency.Name,
                        CurrencySymbol = PayOUTList[i].Currency.Symbol,
                        ExchangeRate = PayOUTList[i].ExchangeRate,
                        RealValue = Math.Round((PayOUTList[i].Value / PayOUTList[i].ExchangeRate), 3)

                    };
                    list.Add(moneyaccountoperation);
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception("MoneyAccountOperation-Convert_PayOUT_To_MoneyAccountOperation Error:" + e);
            }
        }
        public static List<MoneyAccountOperation> Convert_ExchangeOPR_To_MoneyAccountOperation(List<ExchangeOPR> ExchangeOPRList)
        {
            try
            {
                List<MoneyAccountOperation> list = new List<MoneyAccountOperation>();
                for (int i = 0; i < ExchangeOPRList.Count; i++)
                {
                    MoneyAccountOperation moneyaccountoperationOUT = new MoneyAccountOperation()
                    {
                        OprTime = ExchangeOPRList[i].Date,
                        OprType = MoneyAccountOperation.TYPE_EXCHANGE_OPR,
                        OprDirection = MoneyAccountOperation.DIRECTION_OUT,
                        OprID = ExchangeOPRList[i].Id,
                        TradeOperationId = null,
                        TradeOperationType = null,
                        Value = ExchangeOPRList[i].OutMoneyValue,
                        CurrencyID = ExchangeOPRList[i].SourceCurrency.Id,
                        CurrencyName = ExchangeOPRList[i].SourceCurrency.Name,
                        CurrencySymbol = ExchangeOPRList[i].SourceCurrency.Symbol,
                        ExchangeRate = ExchangeOPRList[i].SourceExchangeRate,
                        RealValue = Math.Round((ExchangeOPRList[i].OutMoneyValue / ExchangeOPRList[i].SourceExchangeRate), 3)

                    };
                    list.Add(moneyaccountoperationOUT);
                    MoneyAccountOperation moneyaccountoperationIN = new MoneyAccountOperation()
                    {
                        OprTime = ExchangeOPRList[i].Date,
                        OprType = MoneyAccountOperation.TYPE_EXCHANGE_OPR,
                        OprDirection = MoneyAccountOperation.DIRECTION_IN,
                        OprID = ExchangeOPRList[i].Id,
                        TradeOperationId = null,
                        TradeOperationType = null,
                        Value =Math.Round( ExchangeOPRList[i].OutMoneyValue
                            *(ExchangeOPRList[i].TargetExchangeRate/ ExchangeOPRList[i].SourceExchangeRate),3),
                        CurrencyID = ExchangeOPRList[i].TargetCurrency.Id,
                        CurrencyName = ExchangeOPRList[i].TargetCurrency.Name,
                        CurrencySymbol = ExchangeOPRList[i].TargetCurrency.Symbol,
                        ExchangeRate = ExchangeOPRList[i].TargetExchangeRate,
                        RealValue = Math.Round((ExchangeOPRList[i].OutMoneyValue / ExchangeOPRList[i].SourceExchangeRate), 3)

                    };
                    list.Add(moneyaccountoperationIN);
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception("MoneyAccountOperation-Convert_ExchangeOPR_To_MoneyAccountOperation Error:" + e);
            }
        }
        public static List<MoneyAccountOperation> Convert_MoneyTransformOPR_To_MoneyAccountOperation(int moneyAccountID, List<MoneyTransFormOPR> MoneyTransFormOPRList)
        {
            try
            {
                List<MoneyAccountOperation> list = new List<MoneyAccountOperation>();

                var MoneyTransFormOPRList_IN = MoneyTransFormOPRList.Where(x => x.TargetMoneyAccountId == moneyAccountID).ToList();
                var MoneyTransFormOPRList_OUT = MoneyTransFormOPRList.Where(x => x.SourceMoneyAccountId == moneyAccountID).ToList();

                for (int i = 0; i < MoneyTransFormOPRList_IN.Count; i++)
                {
                    MoneyAccountOperation moneyaccountoperation = new MoneyAccountOperation()
                    {
                        OprTime = MoneyTransFormOPRList_IN[i].Date,
                        OprType = MoneyAccountOperation.TYPE_MoneyTransform_OPR,
                        OprDirection = MoneyAccountOperation.DIRECTION_IN,
                        OprID = MoneyTransFormOPRList_IN[i].Id,
                        TradeOperationId = null,
                        TradeOperationType = null,
                        Value = MoneyTransFormOPRList_IN[i].Value,
                        CurrencyID = MoneyTransFormOPRList_IN[i].Currency.Id,
                        CurrencyName = MoneyTransFormOPRList_IN[i].Currency.Name,
                        CurrencySymbol = MoneyTransFormOPRList_IN[i].Currency.Symbol,
                        ExchangeRate = MoneyTransFormOPRList_IN[i].ExchangeRate,
                        RealValue = Math.Round((MoneyTransFormOPRList_IN[i].Value / MoneyTransFormOPRList_IN[i].ExchangeRate), 3)

                    };
                    list.Add(moneyaccountoperation);
                }
                for (int i = 0; i < MoneyTransFormOPRList_OUT.Count; i++)
                {
                    MoneyAccountOperation moneyaccountoperation = new MoneyAccountOperation()
                    {
                        OprTime = MoneyTransFormOPRList_OUT[i].Date,
                        OprType = MoneyAccountOperation.TYPE_MoneyTransform_OPR,
                        OprDirection = MoneyAccountOperation.DIRECTION_OUT,
                        OprID = MoneyTransFormOPRList_OUT[i].Id,
                        TradeOperationId = null,
                        TradeOperationType = null,
                        Value = MoneyTransFormOPRList_OUT[i].Value,
                        CurrencyID = MoneyTransFormOPRList_OUT[i].Currency.Id,
                        CurrencyName = MoneyTransFormOPRList_OUT[i].Currency.Name,
                        CurrencySymbol = MoneyTransFormOPRList_OUT[i].Currency.Symbol,
                        ExchangeRate = MoneyTransFormOPRList_OUT[i].ExchangeRate,
                        RealValue = Math.Round((MoneyTransFormOPRList_OUT[i].Value / MoneyTransFormOPRList_OUT[i].ExchangeRate), 3)

                    };
                    list.Add(moneyaccountoperation);
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception("MoneyAccountOperation-Convert_MoneyTransformOPR_To_MoneyAccountOperation Error:" + e);
            }
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
                if (i != 0 && i != currencyIdList.Count - 1) return_value += " - ";
                return_value += value + " " + currency_in_list[0].CurrencySymbol;
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
                if (i != 0 && i != currencyIdList.Count - 1) return_value += " - ";
                return_value += value + " " + currency_in_list[0].CurrencySymbol;
            }
            return return_value;
        }
    }
}
