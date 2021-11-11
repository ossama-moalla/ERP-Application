using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Store
{
    public class StorePlace
    {
        public uint ID;
        public string Name;
        public StorePlace_Container _Container;
        public string Desc;
        public StorePlace(uint ID_, string Name_, StorePlace_Container Container_, string Desc_)
        {
            ID = ID_;
            Name = Name_;
            _Container = Container_;
            Desc = Desc_;
        }

        internal string GetPlaceInfo()
        {
            if (_Container == null) return Name;
            return _Container.Name + " : " + Name;
        }
    }
}
