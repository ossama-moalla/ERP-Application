using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class TradeState
    {
        [Key]
        public uint TradeStateID { get; set; }
        public string TradeStateName { get; set; }
    }
}
