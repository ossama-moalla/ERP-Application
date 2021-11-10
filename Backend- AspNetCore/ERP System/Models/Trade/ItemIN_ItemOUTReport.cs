using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class ItemIN_ItemOUTReport
    {
        public ItemIN _ItemIN;
        public List<ItemOUT> ItemOUTList;
        public ItemIN_ItemOUTReport(ItemIN ItemIN_, List<ItemOUT> ItemOUTList_)
        {
            _ItemIN = ItemIN_;
            ItemOUTList = ItemOUTList_;
        }
    }
}
