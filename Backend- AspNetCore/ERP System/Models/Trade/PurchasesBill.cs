using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class PurchasesBill //no need to explain :)
    {
        [Key]
        public int Id { get; set; }
        public int OperationType { get { return Operation.PURCHASES_BILL; } }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int DealerId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dealer Dealer { get; set; }
        public int SellTypeId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SellType SellType { get; set; }
        public int? CurrencyId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Currency Currency { get; set; }
        public double ExchangeRate { get; set; }
        public double Discount { get; set; }
        public string Notes { get; set; }

        [NotMapped]
        public double BillValue { get; set; }
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
        public List<PayOUT> PaysOUT { get; set; }
        [NotMapped]
        public List<ItemIN> ItemsIN { get; set; }
    }
}
