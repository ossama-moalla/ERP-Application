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
        public int SourceMoneyAccountId { get; set; }
        [JsonIgnore]
        public MoneyAccount SourceMoneyAccount { get; set; }
        public int TargetMoneyAccountId { get; set; }
        [JsonIgnore]
        public MoneyAccount TargetMoneyAccount { get; set; }
        [Required]
        public int? CurrencyId { get; set; }
        [JsonIgnore]
        public Currency Currency { get; set; }
        [Required]
        public double ExchangeRate { get; set; }
        public double Value { get; set; }
        public string Notes { get; set; }
        /*
        public int? Creator_EmployeeId { get; set; }//early to implement this(soon)
        [JsonIgnore]
        public Employee Creator_Employee { get; set; }
        public int? Confirm_EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Confirm_Employee { get; set; }*/
        public static MoneyTransFormOPR_VM ConvertToMoneyTransFormOPR_VM(MoneyTransFormOPR moneytransformopr)
        {
            if (moneytransformopr == null) return null;
            if (moneytransformopr.Currency == null) moneytransformopr.Currency = Currency.ReferenceCurrency;
            return new MoneyTransFormOPR_VM()
            {
                Id = moneytransformopr.Id,
                Date = moneytransformopr.Date,
                SourceMoneyAccountId = moneytransformopr.SourceMoneyAccountId,
                SourceMoneyAccountName = moneytransformopr.SourceMoneyAccount.Name,
                TargetMoneyAccountId = moneytransformopr.TargetMoneyAccountId,
                TargetMoneyAccountName = moneytransformopr.TargetMoneyAccount.Name,
                CurrencyId = moneytransformopr.CurrencyId,
                CurrencyName = moneytransformopr.Currency.Name,
                CurrencySymbol = moneytransformopr.Currency.Symbol,
                ExchangeRate = moneytransformopr.ExchangeRate,
                Value = moneytransformopr.Value,
                Notes = moneytransformopr.Notes
            };

        }
        public static IList<MoneyTransFormOPR_VM> ConvertToMoneyTransFormOPR_VM(IList<MoneyTransFormOPR> moneytransformoprList)
        {
            List<MoneyTransFormOPR_VM> returnlist = new List<MoneyTransFormOPR_VM>();
            foreach (var moneytransformopr in moneytransformoprList)
            {
                returnlist.Add(ConvertToMoneyTransFormOPR_VM(moneytransformopr));
            }
            return returnlist;
        }
    }
    public class MoneyTransFormOPR_VM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SourceMoneyAccountId { get; set; }
        public string SourceMoneyAccountName { get; set; }

        public int TargetMoneyAccountId { get; set; }
        public string TargetMoneyAccountName { get; set; }
        public int? CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public double ExchangeRate { get; set; }
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
