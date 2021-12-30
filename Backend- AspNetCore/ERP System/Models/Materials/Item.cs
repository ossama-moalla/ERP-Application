using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_System.Models.Materials
{
    [Index(nameof(ItemCategoryId), nameof(Name),nameof(Company),IsUnique =true,Name ="Item Name And Company must be unique in category")]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        [Required(AllowEmptyStrings =true)]
        public string Company { get; set; }
        public string MarketCode { get; set; }
        public DateTime CreateDate { get; set; }
        public string DefaultConsumeUnit { get; set; }
        public int ItemCategoryId { get;set; }
        [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
        public ItemCategory ItemCategory { get; set; }

    }
}
