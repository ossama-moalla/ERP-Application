﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade.Reports.SalesBillsReport
{
    public class SalesBillsReport_InYear : ISalesBillsReport, IYearInfo
    {
        public int YearNO { get ; set; }
    }
}

