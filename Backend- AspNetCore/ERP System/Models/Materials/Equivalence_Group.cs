using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Materials
{
    public class Equivalence_Group
    {
        [Key]
        public int GroupID { get; set; }
        public string GroupName { get; set; }
    
    }
}
