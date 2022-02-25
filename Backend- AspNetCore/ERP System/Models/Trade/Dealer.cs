using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class Dealer //person or company that you are deal with (sell,buy ,mainteneace) sometimes u need to buy from dealer or sell to
    {
        public const bool Dealer_PERSON = false;
        public const bool Dealer_COMPANY = true;

        public int Id { get; set; }
        public string Name { get; set; }
        public bool DealerType { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}
