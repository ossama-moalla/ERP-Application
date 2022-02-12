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
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MoneyAccount MoneyAccount { get; set; }
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? SourceCurrencyId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Currency SourceCurrency { get; set; }
        [Required]
        public double SourceExchangeRate { get; set; }
        [Required]
        public double OutMoneyValue { get; set; }
        public int? TargetCurrencyId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Currency TargetCurrency { get; set; }
        [Required]
        public double TargetExchangeRate { get; set; }
        public string Notes { get; set; }
    }
}
