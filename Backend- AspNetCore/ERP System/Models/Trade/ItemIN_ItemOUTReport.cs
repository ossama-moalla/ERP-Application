using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class ItemIN_ItemOUTReport //display where you spend ur items that you entered in to you company
    {
        public ItemIN ItemIN { get; set; }
        public List<ItemOUT> ItemOUTList { get; set; }
    }
}
