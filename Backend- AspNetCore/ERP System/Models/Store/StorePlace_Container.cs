using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Store
{
    public class StorePlace_Container
    {
        public int ID;
        public string Name;
        public int? ParentID;
        public string Desc;
        public StorePlace_Container(int ID_, string Name_, int? ParentID_, string Desc_)
        {
            ID = ID_;
            Name = Name_;
            ParentID = ParentID_;
            Desc = Desc_;
        }
    }
}
