using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.AvailableItems
{
    public class TradeState_AvailableAmount
    {
        public TradeState _TradeState { get; }
        public double AvailableAmount { get; }
        public TradeState_AvailableAmount(
         TradeState _TradeState_,
         double AvailableAmount_)
        {
            _TradeState = _TradeState_;
            AvailableAmount = AvailableAmount_;
        }

    }
}


