using ERP_System.Models.Accounting;
using ERP_System.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class IBill
    {
        public Operation _Operation;
        public DateTime BillDate;
        public string BillDescription;
        public Customer _Customer;
        public Currency _Currency;
        public double ExchangeRate;
        public double Discount;
        public string Notes;

    }
}
