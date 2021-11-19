using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Materials
{
    [Keyless]
    public class ItemRelation
    {
        public Item Item_ { get; set; }
        public Item AnotherItem { get; set; }
        public int Relation_ { get; set; }
        public bool Inherit { get; set; }
        public string Notes { get; set; }
 

    }
}
