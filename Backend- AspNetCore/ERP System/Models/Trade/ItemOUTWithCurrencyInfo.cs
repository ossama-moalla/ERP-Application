using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    //public class ItemOUTWithCurrencyInfo
    //{
    //    public ItemOUT _ItemOUT;
    //    public Currency _Currency;
    //    public ItemOUTWithCurrencyInfo(DatabaseInterface DB, ItemOUT ItemOUT_)
    //    {
    //        _ItemOUT = ItemOUT_;
    //        _Currency = new TradeSQL.OperationSQL(DB).GetOperationItemOUTCurrency(ItemOUT_._Operation);
    //    }
    //    public static List<ItemOUTWithCurrencyInfo> ConvertTo_ItemOUTWithCurrencyInfoList(DatabaseInterface DB, List<ItemOUT> ItemOUTList)
    //    {
    //        List<ItemOUTWithCurrencyInfo> list = new List<ItemOUTWithCurrencyInfo>();
    //        try
    //        {
    //            for (int i = 0; i < ItemOUTList.Count; i++)
    //            {
    //                list.Add(new ItemOUTWithCurrencyInfo(DB, ItemOUTList[i]));
    //            }
    //            return list;
    //        }
    //        catch
    //        {

    //            return list;
    //        }
    //    }
        //public static string GetTotalItemsOUTValue(List<ItemOUTWithCurrencyInfo> ItemOUTWithCurrencyInfoList)
        //{
        //    string value_str = "";
        //    try
        //    {

        //        List<int> currencyIDlist = ItemOUTWithCurrencyInfoList.Select(x => x._Currency.CurrencyID).Distinct().ToList();
        //        for (int i = 0; i < currencyIDlist.Count; i++)
        //        {

        //            double valuecurrency = 0;
        //            List<ItemOUTWithCurrencyInfo> templist = ItemOUTWithCurrencyInfoList.Where(x => x._Currency.CurrencyID == currencyIDlist[i]).ToList();
        //            Currency cuurency = templist[0]._Currency;
        //            for (int j = 0; j < templist.Count; j++)
        //            {
        //                valuecurrency = valuecurrency + templist[j]._ItemOUT._OUTValue.Value;
        //            }
        //            value_str = value_str + valuecurrency + " " + cuurency.CurrencySymbol.Replace(" ", string.Empty) + "  ";
        //        }
        //        if (value_str.Length < 1)
        //            return "-";
        //        else
        //            return value_str;
        //    }
        //    catch (Exception ee)
        //    {
        //        return "حصل خطأ" + ee.Message;
        //    }
        //}

    //}
}
