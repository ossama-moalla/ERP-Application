using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models
{
    public interface  IDayInfo
    {
        public int DayNO { get; set; }
        public DateTime DayDate { get; set; }
    }
}
