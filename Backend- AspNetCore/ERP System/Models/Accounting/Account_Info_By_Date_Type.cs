using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    public class Account_Info_By_Date_Type
    {
        public class YearRange
        {
            public int min_year;
            public int max_year;
            public YearRange(int y1, int y2)
            {
                if (y1 > y2)
                {
                    min_year = y2;
                    max_year = y1;
                }
                else
                {
                    min_year = y1;
                    max_year = y2;
                }
            }

        }
        public YearRange YearRange_;
        public int Year;
        public int Month;
        public int Day;
        public Account_Info_By_Date_Type( YearRange YearRange__, int year, int month, int day)
        {
            YearRange_ = YearRange__;
            Year = year;
            Month = month;
            Day = day;
        }


        public string GetAccountDateString()
        {
            string returnstring = "";
            if (Day != -1)
                returnstring = "[" + Day.ToString() + "] \\ [" + Month.ToString() + "] \\ [" + Year.ToString() + " ]";

            else if (Month != -1)
            {
                returnstring = "[" + Month.ToString() + " ] [ " + Year.ToString() + " ]";
            }
            else if (Year != -1)
            {
                returnstring = Year.ToString();
            }
            else
            {
                returnstring = YearRange_.max_year.ToString() + "-" + YearRange_.min_year.ToString();
            }
            return returnstring;
        }

        public void Account_Date_UP()
        {
            if (this.Day != -1) this.Day = -1;
            else if (this.Month != -1) this.Month = -1;
            else if (this.Year != -1) this.Year = -1;
            else return;
        }
        public void Account_Date_Down(int value)
        {
            if (this.Year == -1)
            {
                if (Year < 1990 && Year > 2200) return;
                Year = value;
            }
            else if (Month == -1)
            {
                if (Month < 1 && Month > 12) return;
                Month = value;
            }
            else if (Day == -1)
            {

                if (Day < 1 && Day > DateTime.DaysInMonth(Convert.ToInt32(Year), Convert.ToInt32(Month))) return;
                Day = value;

            }
            else return;
        }

    }
}
