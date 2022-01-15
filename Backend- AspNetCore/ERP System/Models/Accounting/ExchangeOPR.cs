using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    public class ExchangeOPR
    {
        public int MoneyAccountId { get; set; }
        [JsonIgnore]
        public MoneyAccount MoneyAccount { get; set; }
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int? SourceCurrencyId { get; set; }
        [JsonIgnore]
        public Currency SourceCurrency { get; set; }
        public double SourceExchangeRate { get; set; }
        public double OutMoneyValue { get; set; }
        [Required]
        public int? TargetCurrencyId { get; set; }
        [JsonIgnore]
        public Currency TargetCurrency { get; set; }
        public double TargetExchangeRate { get; set; }
        public string Notes { get; set; }

        //------------
        public static ExchangeOPR_VM ConvertToExchangeOPR_VM(ExchangeOPR exchangeopr)
        {
            if (exchangeopr == null) return null;
            if (exchangeopr.SourceCurrency == null) exchangeopr.SourceCurrency = Currency.ReferenceCurrency;
            if (exchangeopr.TargetCurrency == null) exchangeopr.TargetCurrency = Currency.ReferenceCurrency;
            return new ExchangeOPR_VM()
            {
                MoneyAccountId = exchangeopr.MoneyAccount.Id,
                MoneyAccountName = exchangeopr.MoneyAccount.Name,
                Id = exchangeopr.Id,
                Date = exchangeopr.Date,
                SourceCurrencyId = exchangeopr.SourceCurrencyId,
                SourceCurrencyName = exchangeopr.SourceCurrency.Name,
                SourceCurrencySymbol = exchangeopr.SourceCurrency.Symbol,
                SourceExchangeRate = exchangeopr.SourceExchangeRate,
                OutMoneyValue = exchangeopr.OutMoneyValue,
                TargetCurrencyId = exchangeopr.TargetCurrencyId,
                TargetCurrencyName = exchangeopr.TargetCurrency.Name,
                TargetCurrencySymbol = exchangeopr.TargetCurrency.Symbol,
                TargetExchangeRate = exchangeopr.TargetExchangeRate,
                Notes = exchangeopr.Notes
            };

        }
        public static IList<ExchangeOPR_VM> ConvertToExchangeOPR_VM(IList<ExchangeOPR> exchangeoprList)
        {
            List<ExchangeOPR_VM> returnlist = new List<ExchangeOPR_VM>();
            foreach (var exchangeopr in exchangeoprList)
            {
                returnlist.Add(ConvertToExchangeOPR_VM(exchangeopr));
            }
            return returnlist;
        }
    }
    public class ExchangeOPR_VM //view model
    {
        public int MoneyAccountId { get; set; }
        public string MoneyAccountName { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? SourceCurrencyId { get; set; }
        public string SourceCurrencyName { get; set; }
        public string SourceCurrencySymbol { get; set; }
        public double SourceExchangeRate { get; set; }
        public double OutMoneyValue { get; set; }
        public int? TargetCurrencyId { get; set; }
        public string TargetCurrencyName { get; set; }
        public string TargetCurrencySymbol { get; set; }
        public double TargetExchangeRate { get; set; }
        public string Notes { get; set; }
    }
}
