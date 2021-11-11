using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.AvailableItems
{
    public class StorePlace_Item_AvailableAmount_Report
    {
        public StorePlace_Item _StorePlace_Item { get; }
        public double AvailableAmount { get; }
        public StorePlace_Item_AvailableAmount_Report(
         StorePlace_Item StorePlace_Item_,
         double AvailableAmount_)
        {
            _StorePlace_Item = StorePlace_Item_;
            AvailableAmount = AvailableAmount_;
        }
    }
}
