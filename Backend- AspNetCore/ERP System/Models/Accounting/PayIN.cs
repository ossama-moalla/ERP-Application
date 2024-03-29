﻿using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? OperationId { get; set; }
        public int? OperationType { get; set; }
        public string Description { get; set; }
        [Required]
        public double Value { get; set; }
        public int? CurrencyId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Currency Currency { get; set; }
        public double ExchangeRate { get; set; }
        public string Notes { get; set; }
        [NotMapped]
        public virtual MoneyValue_Currency MoneyValue_Currency { get
            {
                return new MoneyValue_Currency()
                {
                    MoneyValue = this.Value,
                    Currency = this.Currency,
                    ExchangeRate = this.ExchangeRate
                };
            } } 

    }
}
