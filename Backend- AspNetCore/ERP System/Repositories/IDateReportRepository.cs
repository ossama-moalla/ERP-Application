using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories
{
    public interface IReportByDateTypeRepository<Operation, Operations_DayReport, Operations_MonthReport, Operations_YearReport, Operations_YearRangeReport>
    {
        public Operations_DayReport DayReport(List<Operation> Operations,int year, int month, int day);
        public Operations_MonthReport MonthReport(List<Operation> Operations, int year, int month);
        public Operations_YearReport YearReport(List<Operation> Operations, int year);
        public Operations_YearRangeReport YearRangeReport(List<Operation> Operations, int year1,int year2);


    }
}
