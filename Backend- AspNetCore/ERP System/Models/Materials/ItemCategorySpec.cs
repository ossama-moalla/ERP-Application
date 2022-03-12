using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace ERP_System.Models.Materials
{

    [Index(nameof(CategoryID), nameof(Index), IsUnique = true, Name = "Unique Index In Category Spec's")]
    [Index(nameof(CategoryID), nameof(Name), IsUnique = true, Name = "Unique name In Category Spec's")]
    public class ItemCategorySpec
    {
        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        [JsonIgnore]
        public virtual ItemCategory Category { get; set; }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsRestricted { get; set; }
        [Required]
        public int Index { get; set; }

    }
    public class ItemCategorySpec_ValidationError
    {
        public string nameError { get; set; }
        public string indexError { get; set; }
        public string ConvertToString()
        {
            string message = string.Empty;
            if (this.nameError != null) message = this.nameError;
            if (this.indexError != null)
            {
                if (message.Length > 0) message += " , ";
                message += this.indexError;
            }
            return message;
        }
    }
}
