using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ERP_System.Models.Materials
{

    [Index(nameof(CategoryID), nameof(index), IsUnique = true, Name = "Unique Index In Category Spec's")]
    [Index(nameof(CategoryID), nameof(name), IsUnique = true, Name = "Unique name In Category Spec's")]
    public class ItemCategorySpec
    {
        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        [JsonIgnore]
        public virtual ItemCategory Category { get; set; }
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int index { get; set; }

    }
}
