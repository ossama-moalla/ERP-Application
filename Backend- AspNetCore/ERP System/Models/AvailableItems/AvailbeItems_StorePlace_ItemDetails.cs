using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.AvailableItems
{
    public class AvailbeItems_StorePlace_ItemDetails
    {
        public int ID;
        public string Name;
        public string Company;
        public string Type;
        public string AvailableStates;
        public AvailbeItems_StorePlace_ItemDetails(int ID_, string Name_, string Company_, string Type_, string AvailableStates_)
        {
            ID = ID_;
            Name = Name_;
            Company = Company_;
            Type = Type_;
            AvailableStates = AvailableStates_;
        }
    }
}
