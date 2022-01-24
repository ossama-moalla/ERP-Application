using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting.Reports
{
    public class MoneyAccountReport_InMonth:MoneyAccountReport
    {
        public int Year_Month { get; set; }
        public string Year_Month_Name { get; set; }
    }
}
