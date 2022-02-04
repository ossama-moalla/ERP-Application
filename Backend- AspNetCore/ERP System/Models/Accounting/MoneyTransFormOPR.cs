using ERP_System.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    public class MoneyTransFormOPR
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int SourceMoneyAccountId { get; set; }
        [JsonIgnore]
        public MoneyAccount SourceMoneyAccount { get; set; }
        [Required]
        public int TargetMoneyAccountId { get; set; }
        [JsonIgnore]
        public MoneyAccount TargetMoneyAccount { get; set; }
        public int? CurrencyId { get; set; }
        [JsonIgnore]
        public Currency Currency { get; set; }
        [Required]
        public double ExchangeRate { get; set; }
        [Required]
        public double Value { get; set; }
        public string Notes { get; set; }
        /*
        public int? Creator_EmployeeId { get; set; }//early to implement this(soon)
        [JsonIgnore]
        public Employee Creator_Employee { get; set; }
        public int? Confirm_EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Confirm_Employee { get; set; }*/
        
    }
}
