using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ERP_System.Models.Materials
{

    [Index(nameof(CategoryID), nameof(index), IsUnique = true,Name ="Unique Index In Category Spec's")]
    [Index(nameof(CategoryID), nameof(name), IsUnique = true, Name = "Unique name In Category Spec's")]
    public class ItemCategorySpec_Restrict
    {
        //specs assigned to category and item inherit it
        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        [JsonIgnore]
        public  ItemCategory Category { get; set; }
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public int index { get; set; }

    }
}
