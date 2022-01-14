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
        [JsonIgnore]
        public MoneyAccount MoneyAccount { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? OperationId { get; set; }
        public int? OperationType { get; set; }
        [JsonIgnore]
        public IBill Bill { set { Bill = value; } }//sell or maintenance bill

        public string Description { get; set; }
        [Required]
        public double Value { get; set; }
        public int? CurrencyId { get; set; }
        [JsonIgnore]
        public Currency Currency { get; set; }
        [Required]
        public double ExchangeRate { get; set; }
        public string Notes { get; set; }
    }
}
