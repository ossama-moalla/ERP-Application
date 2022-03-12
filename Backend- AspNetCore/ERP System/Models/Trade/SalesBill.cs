using ERP_System.Models.Accounting;
using ERP_System.Models.Trade.Reports.SalesBillsReport;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class SalesBill //no need to explain :)
    {
        [Key]
        public int Id { get; set; }
        public int OperationType { get { return Operation.SALES_BILL; } }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int DealerId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dealer Dealer { get; set; }
        public int SellTypeId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SellType SellType { get; set; }
        [NotMapped]
        public double BillValue { get; set; }
        public int? CurrencyId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Currency Currency { get; set; }
        public double ExchangeRate { get; set; }
        public double Discount { get; set; }
        public string Notes { get; set; }
        [NotMapped]
        public virtual MoneyValue_Currency MoneyValue_Currency
        {
            get
            {
                return new MoneyValue_Currency()
                {
                    MoneyValue = this.BillValue,
                    Currency = this.Currency,
                    ExchangeRate = this.ExchangeRate
                };
            }
        }
        [NotMapped]
        public List<PayIN> PaysIN { get; set; }
        [NotMapped]
        public List<ItemOUT> ItemsOUT { get; set; }

        public double get_PaysValueAccordingToBillCurrency()
        {
            double PaysValueAccordingToBillCurrency = 0;
            foreach (var payin in this.PaysIN)
            {
                if (payin.Currency.Id == this.CurrencyId) PaysValueAccordingToBillCurrency += payin.Value;
                else PaysValueAccordingToBillCurrency = (payin.Value / payin.ExchangeRate) * this.ExchangeRate;
            }
            return PaysValueAccordingToBillCurrency;
        }
        public  SalesBill_Report Convert_To_SalesBill_Report()
        {
            return new SalesBill_Report()
            {
                Time = this.Date,
                Id = this.Id,
                Owner = this.Dealer.FullName,
                Clauses_Count = this.ItemsOUT.Count(),
                Bill_Value = Math.Round(this.BillValue, 2),
                TotalPays = MoneyValue_Currency.Combine_MoneyValue_Currency(this.PaysIN.Select(x=>x.MoneyValue_Currency).ToList()),
                Bill_Value_Remain = Math.Round(this.BillValue - this.get_PaysValueAccordingToBillCurrency(), 2),
                Currency = this.Currency,
                ExchangeRate = this.ExchangeRate,
                Bill_RealValue = Math.Round(this.BillValue / this.ExchangeRate, 2),
                Pays_RealValue = Math.Round(this.PaysIN.Sum(x => x.Value / x.ExchangeRate), 2)
            };
        }
        
    }
}
