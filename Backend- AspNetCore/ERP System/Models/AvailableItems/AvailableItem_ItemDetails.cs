using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.AvailableItems
{
    public class AvailableItem_ItemDetails
    {
        internal Item _Item;
        internal string AvailableAmount;
        internal string FolderPath;
        public AvailableItem_ItemDetails(Item Item_, string AvailableAmount_, string FolderPath_)
        {
            _Item = Item_;
            AvailableAmount = AvailableAmount_;
            FolderPath = FolderPath_;
        }
    }
}
