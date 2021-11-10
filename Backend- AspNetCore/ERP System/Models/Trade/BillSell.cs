using ERP_System.Models.Accounting;
using ERP_System.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class BillSell:IBill
    {
        public SellType _SellType;
        public BillSell(uint BillID_, DateTime BillDate_, string BillDescription_, SellType SellType_, Customer Customer_, Currency Currency_, double ExchangeRate_, double Discount_, string Notes_)
        //:base (BillID_,BillDate_ ,BillDescription_ ,Customer_,Currency_ ,ExchangeRate_ ,Discount_ ,Notes_ )
        {
            _Operation = new Operation(Operation.BILL_SELL, BillID_);
            BillDate = BillDate_;
            BillDescription = BillDescription_;
            _SellType = SellType_;
            _Customer = Customer_;
            _Currency = Currency_;
            ExchangeRate = ExchangeRate_;
            Discount = Discount_;
            Notes = Notes_;
        }
    }
}
