using ERP_System.Models.Store;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.AvailableItems
{
    public class ItemIN_AvailableAmount_Report_PlaceDetail
    {
        public ItemIN _ItemIN { get; }
        public StorePlace Place { get; }
        public double StoreAmount { get; }
        public double AvailableAmount { get; }
        public double SpentAmount { get; }

        public ItemIN_AvailableAmount_Report_PlaceDetail(
        ItemIN ItemIN_,
        StorePlace Place_,
        double StoreAmount_,
         double AvailableAmount_,
        double SpentAmount_
     )
        {
            _ItemIN = ItemIN_;
            Place = Place_;
            StoreAmount = StoreAmount_;
            SpentAmount = SpentAmount_;
            AvailableAmount = AvailableAmount_;
        }
    }
}
