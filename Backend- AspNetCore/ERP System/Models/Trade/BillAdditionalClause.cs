using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class BillAdditionalClause //additional clause any thing u want to add to bill (sales,maintenenace,purchases) like transport or install or ....
    {
        [Key]
        public int Id { get; set; }
        public int OperationId { get; set; }
        public int OperationType { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        
    }
}
