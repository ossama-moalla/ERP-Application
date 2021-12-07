using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ERP_System.Models.Materials
{
    public class ItemCategorySpec_Restrict_Options
    {
        //options for ItemSpec_Restrict
        public ItemCategorySpec_Restrict ItemSpecRestrict_ { get; set; }
        public string OptionName { get; set; }
        [Key]
        public int OptionID { get; set; }

   
    }
}
