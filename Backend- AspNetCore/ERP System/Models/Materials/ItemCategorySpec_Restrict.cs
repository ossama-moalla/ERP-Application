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
        public int id { get; set; }
        public string name { get; set; }
        public int index { get; set; }

    }
}
