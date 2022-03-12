using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERP_System.Models
{
    public  class MoneyValue_Currency
    {
        public  double MoneyValue { get; set; }
        public Currency Currency { get; set; }
        public  double ExchangeRate { get; set; }

        public static  string Combine_MoneyValue_Currency(List<MoneyValue_Currency> list)
        {
            string returnString = string.Empty;
            var distinctIds = list.Select(x => x.Currency.Id).Distinct().ToList();
            var count = distinctIds.Count();
            for (int i = 0; i < count; i++)
            {
                var currency = list.Where(x => x.Currency.Id == distinctIds[i]).ToList()[0].Currency;
                var sumbycurrency = list.Sum(x => x.MoneyValue);
                returnString += sumbycurrency + " " + currency.Symbol;
                if (i != count - 1) returnString += ",";
            }
            return returnString;
        }
    }
}
