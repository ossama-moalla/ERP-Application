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
    public class Currency_ValidationError
    {
        public string nameError { get; set; }
        public string symbolError { get; set; }
        public string exchangeRateError { get; set; }

        public string ConvertToString()
        {
            string message = string.Empty;
            if (this.nameError != null) message = this.nameError;
            if (this.symbolError != null)
            {
                if (message.Length > 0) message += " /n ";
                message += this.symbolError;
            }
            if (this.exchangeRateError != null)
            {
                if (message.Length > 0) message += " /n ";
                message += this.exchangeRateError;
            }
            return message;
        }
    }
}
