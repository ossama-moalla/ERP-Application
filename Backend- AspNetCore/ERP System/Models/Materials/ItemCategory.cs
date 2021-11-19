using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ERP_System.Models.Materials
{
    public class ItemCategory
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int? ParentID { get; set; }
        public DateTime CreateDate { get; set; }
        public string DefaultConsumeUnit { get; set; }

    }
}
