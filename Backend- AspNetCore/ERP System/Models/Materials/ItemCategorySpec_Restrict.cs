using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ERP_System.Models.Materials
{
    public class ItemCategorySpec_Restrict
    {
        //specs assigned to category and item inherit it
        public ItemCategory Category { get; set; }
        [Key]
        public int SpecID { get; set; }
        public string SpecName { get; set; }
        public int SpecIndex { get; set; }

    }
}
