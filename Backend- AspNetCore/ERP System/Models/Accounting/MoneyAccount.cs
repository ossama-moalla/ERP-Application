using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    [Index(nameof(Name),IsUnique =true,Name ="Money Account Name Must Be Unique")]
    public class MoneyAccount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(6,ErrorMessage = "Money Account Name Must Be At Least 6 Charecters")]
        public string Name { get; set; }
    }
}
