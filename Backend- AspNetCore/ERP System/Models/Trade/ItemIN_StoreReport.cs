using ERP_System.Models.Materials;
using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class ItemINStoreReport//display where ur items stored ,place=null mean that the items have  not been sent to store
    {
        public ItemIN ItemIN { get; set; }
        public StorePlace Place { get; set; }
        public ConsumeUnit ConsumeUnit { get; set; }
        public double StoreAmount { get; set; }
        public double SpentAmount { get; set; }
    }
}
