using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Materials
{
    [Keyless]
    public class ItemSpec_Restrict_Value
    {
        public Item item { get; set; }
        public ItemSpec_Restrict ItemSpecRestrict_ { get; set; }
        public ItemSpec_Restrict_Options ItemSpec_Restrict_Options_ { get; set; }

    }
}
