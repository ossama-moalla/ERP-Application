using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ERP_System.Models.Materials
{
    public class ItemSpecDisplay
    {
        public ItemCategory Type { get; set; }
        [Key]
        public int SpecID { get; set; }
        public string SpecName { get; set; }
        public int SpecIndex { get; set; }
        public bool Spectype { get; set; }

    }
}
