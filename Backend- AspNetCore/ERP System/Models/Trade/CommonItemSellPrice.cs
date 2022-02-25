using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class CommonItemSellPrice //item or product common sell price in dollar 
    {
        public int ItemId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Item Item { get; set; }
        public int ConsumeUnitId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConsumeUnit ConsumeUnit { get; set; }
        public int SellTypeId { get; set; }

        public SellType SellType { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double Price { get; set; }
    }
}
