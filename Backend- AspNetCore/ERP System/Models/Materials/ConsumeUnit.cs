using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Materials
{
    public class ConsumeUnit
    {
        [Key]
        public uint ID { get; set; }
        
        public string Name { get; set; }
        public Item Item_ { get; set; }
        public double Factor { get; set; }

    }
}
