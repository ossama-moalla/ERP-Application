using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ERP_System.Models.Materials
{
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
