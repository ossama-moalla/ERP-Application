using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    [Index(nameof(Name),IsUnique =true,Name ="Currency Name Must Be Unique")]
    [Index(nameof(Symbol), IsUnique = true, Name = "Currency Symbol Must Be Unique")]

    public class Currency
    {
        public   static Currency ReferenceCurrency = new Currency()
        {
            Id=-1,
            Name = "US Dollar",
            Symbol = "$",
            ExchangeRate = 1,
            Disable = false
        };

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double ExchangeRate { get; set; }
        public bool Disable { get; set; }

    }
}
