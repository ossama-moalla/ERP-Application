using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class Dealer //person or company that you are deal with (sell,buy ,mainteneace) sometimes u need to buy from dealer or sell to
    {
       
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}
