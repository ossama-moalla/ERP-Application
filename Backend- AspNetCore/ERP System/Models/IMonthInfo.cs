using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models
{
    public interface IMonthInfo
    {
        public int MonthNO { get; set; }
        public string MonthName { get; set; }
    }
}
