﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.SalesBillsReport
{
    public class SalesBillsReport_DayReport
    {

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }


        public List<SalesBill_Report> SalesBillReport_List { get; set; }
    }
}
