using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP_System.Models.Materials
{
    public class ItemCategory
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("parentID ")]
        public  int? parentID { get; set; }
        public DateTime CreateDate { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string defaultConsumeUnit { get; set; }

    }
}
