using ERP_System.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
   
    public class RavageOPR //items out by value =0 $
    {
        [Key]
        public int Id { get; set; }
        public int OperationType { get { return Operation.RAVAGEOPR; } }
        public DateTime Date { get; set; }
        public string Notes { get; set; }


    }
}
