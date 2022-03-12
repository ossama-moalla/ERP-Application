using ERP_System.Models.Materials;
using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class ItemOUT// show info about out of items in your company ,out by (salesbill,disassembly,internal consume,ravage,by maintenance bill,...)
    {
        [Key]
        public int Id { get; set; }
        public int OperationId { get; set; }
        public int OperationType { get; set; }
        public int ItemINId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ItemIN ItemIN { get; set; }
        public int? PlaceId { get; set; }//place where item out
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StorePlace Place { get; set; }

        public int? ConsumeUnitId { get; set; }//if null it will be default item consume unit
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConsumeUnit ConsumeUnit { get; set; }
        public double Amount { get; set; }
        public double? SingleOUTValue { get; set; }//null only by disassemply and assembly
        [NotMapped]
        public virtual MoneyValue_Currency SingleOUTValue_MoneyValue_Currency { get; set; }

    }
}
