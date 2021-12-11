using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP_System.Models.Materials
{
    public class ItemCategorySpec_Restrict
    {
        //specs assigned to category and item inherit it
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
