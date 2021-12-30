using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_System.Models.Materials
{
    //[Index(nameof(Name), nameof(parentID), IsUnique = true, Name = "Unique name In Parent Category")]
    public class ItemCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }

        [ForeignKey("parentID ")]
        public  int? parentID { get; set; }
        public DateTime CreateDate { get; set; }
        [Required(AllowEmptyStrings = true)]
        public string defaultConsumeUnit { get; set; }

    }

    public class ItemCategory_ValidationError
    {
        public string nameError { get; set; }
    }
}
