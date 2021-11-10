using ERP_System.Models.Materials;
using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class ItemIN_StoreReport
    {
        public ItemIN _ItemIN;
        public StorePlace Place;
        public ConsumeUnit _ConsumeUnit;
        public double StoreAmount;
        public double SpentAmount;
        public ItemIN_StoreReport(ItemIN ItemIN_,
         StorePlace Place_,
         ConsumeUnit ConsumeUnit_,
         double StoreAmount_,
         double SpentAmount_)
        {
            _ItemIN = ItemIN_;
            Place = Place_;
            _ConsumeUnit = ConsumeUnit_;
            StoreAmount = StoreAmount_;
            SpentAmount = SpentAmount_;
        }
    }
}
