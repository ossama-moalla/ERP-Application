using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR
{
    public class SalarysPayOrder
    {
        public int SalarysPayOrderID;
        public DateTime OrderDate;
        public int ExecuteYear;
        public int ExecuteMonth;
        public string Notes;

        public SalarysPayOrder(int SalarysPayOrderID_, DateTime OrderDate_, int ExecuteYear_, int ExecuteMonth_,
           string Notes_)
        {
            SalarysPayOrderID = SalarysPayOrderID_;
            OrderDate = OrderDate_;
            ExecuteYear = ExecuteYear_;
            ExecuteMonth = ExecuteMonth_;
            Notes = Notes_;
        }
    }
}
