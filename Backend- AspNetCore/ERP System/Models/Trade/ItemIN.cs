using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class ItemIN
    {
        public int ItemINID;
        public Operation _Operation;
        public Item _Item;
        public TradeState _TradeState;
        public double Amount;
        public ConsumeUnit _ConsumeUnit;
        public INCost _INCost;
        public string Notes;
        public ItemIN(int ItemINID_, Operation Operation_,
            Item Item_, TradeState TradeState_, double Amount_,
            ConsumeUnit ConsumeUnit_, INCost INCost_, string Notes_)
        {

            ItemINID = ItemINID_;
            _Operation = Operation_;
            _Item = Item_;
            _TradeState = TradeState_;
            Amount = Amount_;
            _ConsumeUnit = ConsumeUnit_;
            _INCost = INCost_;
            Notes = Notes_;

        }
    }
}
