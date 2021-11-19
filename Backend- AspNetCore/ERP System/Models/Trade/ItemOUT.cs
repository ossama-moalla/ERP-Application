using ERP_System.Models.Materials;
using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class ItemOUT
    {
        public int ItemOUTID { get; }
        public Operation _Operation { get; set; }
        public ItemIN _ItemIN { get; set; }
        public StorePlace Place { get; set; }
        public double Amount { get; set; }
        public ConsumeUnit _ConsumeUnit { get; set; }
        public OUTValue _OUTValue { get; set; }
        public string Notes { get; set; }
        public ItemOUT(int ItemOUTID_, Operation Operation_, ItemIN ItemIN_,StorePlace Place_, double Amount_, ConsumeUnit ConsumeUnit_, OUTValue OUTValue_, string Notes_)
        {
            ItemOUTID = ItemOUTID_;
            _Operation = Operation_;
            _ItemIN = ItemIN_;
            Place = Place_;
            Amount = Amount_;
            _ConsumeUnit = ConsumeUnit_;
            _OUTValue = OUTValue_;
            Notes = Notes_;

        }

    }
}
