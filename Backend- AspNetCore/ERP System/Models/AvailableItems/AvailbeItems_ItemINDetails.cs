using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.AvailableItems
{
    public class AvailbeItems_ItemINDetails
    {
        public ItemIN _ItemIN;
        public double SpentAmount;
        public double AvailableAmount;
        public AvailbeItems_ItemINDetails(
        ItemIN ItemIN_,
         double SpentAmount_,
         double AvailableAmount_)
        {
            _ItemIN = ItemIN_;
            SpentAmount = SpentAmount_;
            AvailableAmount = AvailableAmount_;
        }
    }
}
