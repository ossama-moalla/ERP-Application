using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int? CurrencyId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Currency Currency { get; set; }
        public double ExchangeRate { get; set; }
        public double Discount { get; set; }
        public string Notes { get; set; }
    }
}
