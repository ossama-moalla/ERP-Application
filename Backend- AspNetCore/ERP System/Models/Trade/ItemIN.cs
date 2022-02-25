using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class ItemIN //products u bring it to your company by(purchasesbill or assembly operation)
    {
        public int Id { get; set; }
        public int OperationId { get; set; }
        public int OperationType { get; set; }
        public int ItemId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Item Item { get; set; }
        public int TradeStateId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TradeState TradeState { get; set; }
        public int? ConsumeUnitId { get; set; }//if null it will be default item consume unit
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConsumeUnit ConsumeUnit { get; set; }
        public double Amount { get; set; }
        public double SingleCost { get; set; }
    }
}
