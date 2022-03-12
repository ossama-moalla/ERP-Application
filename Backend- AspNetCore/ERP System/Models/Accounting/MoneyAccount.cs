using ERP_System.Models.Accounting.Reports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    [Index(nameof(Name),IsUnique =true,Name ="Money Account Name Must Be Unique")]
    public class MoneyAccount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public List<MoneyAccountOperation> OperationList { get; set; } 

        public  double MoneyAccountValue_By_Currency(int? CurrencyID)
        {
            if (CurrencyID == null) CurrencyID = -1; 
            List<MoneyAccountOperation> list_bycurrency = OperationList.Where(x => x.CurrencyID == CurrencyID).ToList();
            double currency_money_in = list_bycurrency.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value);
            double currency_money_out = list_bycurrency.Where(x => x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value);
            return currency_money_in - currency_money_out;
        }
        public  string MoneyAccountValue()
        {
            string return_value = string.Empty;

            List<int> currencyIdList = OperationList.Select(x => x.CurrencyID).Distinct().ToList();
            for (int i = 0; i < currencyIdList.Count; i++)
            {
                string symbol = OperationList.Where(x => x.CurrencyID == currencyIdList[i]).ToList()[0].CurrencySymbol;
                double currency_money_in = OperationList.Where(x => x.CurrencyID == currencyIdList[i] && x.OprDirection == MoneyAccountOperation.DIRECTION_IN).Sum(x => x.Value);
                double currency_money_out = OperationList.Where(x => x.CurrencyID == currencyIdList[i] && x.OprDirection == MoneyAccountOperation.DIRECTION_OUT).Sum(x => x.Value);
                return_value += (currency_money_in - currency_money_out) + symbol;
                if (i != currencyIdList.Count - 1) return_value += " , ";

            }
            return return_value;
        }
        
    }
}
