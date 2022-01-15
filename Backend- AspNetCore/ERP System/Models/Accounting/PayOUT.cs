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
        [JsonIgnore]
        public MoneyAccount MoneyAccount { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? OperationId { get; set; }
        public int? OperationType { get; set; }
        [JsonIgnore]
        public IBill Bill { set { Bill = value; } }//bill buy
        [JsonIgnore]
        public EmployeePayOrder PayOrder { set { PayOrder = value; } } //payorder

        public string Description { get; set; }
        [Required]
        public double Value { get; set; }
        public int? CurrencyId { get; set; }
        [JsonIgnore]
        public Currency Currency { get; set; }
        [Required]
        public double ExchangeRate { get; set; }
        public string Notes { get; set; }
        public static PayOUT_VM ConvertToPayOUT_VM(PayOUT payout)
        {
            if (payout == null) return null;
            if (payout.Currency == null) payout.Currency = Currency.ReferenceCurrency;
            return new PayOUT_VM()
            {
                MoneyAccountId = payout.MoneyAccount.Id,
                MoneyAccountName = payout.MoneyAccount.Name,
                Id = payout.Id,
                Date = payout.Date,
                OperationId = payout.OperationId,
                OperationType = payout.OperationType,
                Description = payout.Description,
                CurrencyId = payout.CurrencyId,
                CurrencyName = payout.Currency.Name,
                CurrencySymbol = payout.Currency.Symbol,
                Value = payout.Value,
                ExchangeRate = payout.ExchangeRate,
                Notes = payout.Notes
            };

        }
        public static IList<PayOUT_VM> ConvertToPayOUT_VM(IList<PayOUT> payoutList)
        {
            List<PayOUT_VM> returnlist = new List<PayOUT_VM>();
            foreach (var payout in payoutList)
            {
                returnlist.Add(ConvertToPayOUT_VM(payout));
            }
            return returnlist;
        }
    }
    public class PayOUT_VM //view model
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
