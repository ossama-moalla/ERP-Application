using ERP_System.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class InternalConsume //items or products that u spend in your company ,items out by value =0 $
    {
        [Key]
        public int Id { get; set; }
        public int OperationType { get { return Operation.INTERNALCONSUME; } }
        public DateTime Date { get; set; }
        public int PartId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Department Part { get; set; }
        public int EmployeeId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Employee Employee { get; set; }
        public string Notes { get; set; }
    }
}
