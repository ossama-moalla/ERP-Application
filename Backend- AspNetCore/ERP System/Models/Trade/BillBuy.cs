using ERP_System.Models.Accounting;
using ERP_System.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class BillBuy:IBill
    {
        public BillBuy(uint BillID_, DateTime BillDate_, string BillDescription_, Customer Customer_, Currency Currency_, double ExchangeRate_, double Discount_, string Notes_)

        {
            _Operation = new Operation(Operation.BILL_BUY, BillID_);
            BillDate = BillDate_;
            BillDescription = BillDescription_;
            _Customer = Customer_;
            _Currency = Currency_;
            ExchangeRate = ExchangeRate_;
            Discount = Discount_;
            Notes = Notes_;
        }


    }
}
