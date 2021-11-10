using ERP_System.Models.Trade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Materials
{
    [Keyless]
    public class ItemCommonSellPrice
    {
        public Item Item_ { get; set; }
        public TradeState _TradeState { get; set; }
        public ConsumeUnit ConsumeUnit_ { get; set; }
        public SellType SellType_ { get; set; }
        public double Price { get; set; }
  
    }
}
