using ERP_System.Models.HR;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    public class PayOUT
    {
        public int MoneyAccountId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MoneyAccount MoneyAccount { get; set; }
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set;  }
        public int? OperationId { get; set; }
        public int? OperationType { get; set; }
       /* [JsonIgnore]
        public IBill Bill { get; set; } //bill buy
        [JsonIgnore]
        public EmployeePayOrder PayOrder { get; set; } //payorder
       */
        public string Description { get; set; }
        [Required]
        public double Value { get; set; }
        public int? CurrencyId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Currency Currency { get; set; }
        [Required]
        public double ExchangeRate { get; set; }
        public string Notes { get; set; }
      
    }
}
