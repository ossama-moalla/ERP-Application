using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Store
{
    public class StorePlace_Container
    {
        public uint ID;
        public string Name;
        public uint? ParentID;
        public string Desc;
        public StorePlace_Container(uint ID_, string Name_, uint? ParentID_, string Desc_)
        {
            ID = ID_;
            Name = Name_;
            ParentID = ParentID_;
            Desc = Desc_;
        }
    }
}
