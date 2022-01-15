using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    public class PayIN
    {
        public int MoneyAccountId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MoneyAccount MoneyAccount { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? OperationId { get; set; }
        public int? OperationType { get; set; }
        [JsonIgnore]
        public IBill Bill { set { Bill = value; } }//sell or maintenance bill

        public string Description { get; set; }
        public int? CurrencyId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Currency Currency { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public double ExchangeRate { get; set; }
        public string Notes { get; set; }

        //-------------------
        public static PayIN_VM ConvertToPayIN_VM(PayIN payin)
        {
            if (payin == null) return null;
            if (payin.Currency == null) payin.Currency = Currency.ReferenceCurrency;
            return new PayIN_VM()
            {
                MoneyAccountId = payin.MoneyAccount.Id,
                MoneyAccountName = payin.MoneyAccount.Name,
                Id = payin.Id,
                Date = payin.Date,
                OperationId = payin.OperationId,
                OperationType = payin.OperationType,
                Description = payin.Description,
                CurrencyId = payin.CurrencyId ,
                CurrencyName = payin.Currency.Name,
                CurrencySymbol = payin.Currency.Symbol,
                Value = payin.Value,
                ExchangeRate = payin.ExchangeRate,
                Notes = payin.Notes
            };

        }
        public static IList<PayIN_VM> ConvertToPayIN_VM(IList<PayIN> payinList)
        {
            List<PayIN_VM> returnlist = new List<PayIN_VM>();
            foreach (var payin in payinList)
            {
                returnlist.Add(ConvertToPayIN_VM(payin));
            }
            return returnlist;
        }
    }
    public class PayIN_VM //view model
    {
        public int MoneyAccountId { get; set; }
        public string MoneyAccountName { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? OperationId { get; set; }
        public int? OperationType { get; set; }
       
        public string Description { get; set; }
        public int? CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public double Value { get; set; }
        public double ExchangeRate { get; set; }
        public string Notes { get; set; }        
    }
}
