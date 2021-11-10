using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class ItemINSellPrice
    {
        public ItemIN _ItemIN;
        public ConsumeUnit ConsumeUnit_;
        public SellType SellType_;
        public double Price;
        public ItemINSellPrice(ItemIN ItemIN_, ConsumeUnit ConsumeUnit__, SellType SellType__, double Price_)
        {

            _ItemIN = ItemIN_;
            ConsumeUnit_ = ConsumeUnit__;
            SellType_ = SellType__;
            Price = Price_;
        }
    }
}
