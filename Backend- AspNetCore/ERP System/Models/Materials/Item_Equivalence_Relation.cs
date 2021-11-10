using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Materials
{
    [Keyless]
    public class Item_Equivalence_Relation
    {
        public Equivalence_Group _Equivalence_Group { get; set; }
        public Item _Item { get; set; }
     
    }
}
