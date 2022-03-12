using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class ItemINSellPrice//set the price(us dolldar) you want to sell by, with conditions ,like:price for specefic selltype and consume unit
    {
        [Key]
        public int ItemINId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ItemIN ItemIN { get; set; }
        public int? ConsumeUnitId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConsumeUnit ConsumeUnit { get; set; }
        public int SellTypeId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SellType SellType { get; set; }
        public double Price { get; set; }
    }
}
