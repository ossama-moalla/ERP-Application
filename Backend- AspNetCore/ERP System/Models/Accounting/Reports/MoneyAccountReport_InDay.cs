using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting.Reports
{
    public class MoneyAccountReport_InDay:IMoneyAccountReport
    {
        public int DateDayNo { get; set; }
        public DateTime Date_day { get; set; }

    }
}
