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
        public int MoneyAccountID { get; set; }
        [JsonIgnore]
        public MoneyAccount MoneyAccount;
        [Key]
        public int Id { get; set; }
        public DateTime date { get; set; }
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
    }
}
