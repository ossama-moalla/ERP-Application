using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ERP_System.Models.Materials
{
    public class ItemSpec
    {
        public ItemCategory Type { get; set; }
        [Key]
        public uint SpecID { get; set; }
        public string SpecName { get; set; }
        public uint SpecIndex { get; set; }

    }
}
