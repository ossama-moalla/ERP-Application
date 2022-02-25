using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class TradeState //item tradestade mean:new or used or  used second class or scrap ....
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
