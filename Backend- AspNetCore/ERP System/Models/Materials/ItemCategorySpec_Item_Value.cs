﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Materials
{
    [Keyless]
    public class ItemCategorySpec_Item_Value
    {
        public Item Item_ { get; set; }
        public ItemCategorySpec ItemSpec_ { get; set; }
        public string Value { get; set; }

    }
}
