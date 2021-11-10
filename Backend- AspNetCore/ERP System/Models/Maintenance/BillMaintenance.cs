using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class BillMaintenance:IBill
    {
        public SellType _SellType { get; }
        public MaintenanceOPR _MaintenanceOPR { get; }
        public BillMaintenance(MaintenanceOPR MaintenanceOPR_, uint BillID_, DateTime BillDate_, SellType SellType_, Currency Currency_, double ExchangeRate_, double Discount_, string Notes_)
        {
            _MaintenanceOPR = MaintenanceOPR_;
            _Operation = new Operation(Operation.BILL_MAINTENANCE, BillID_);
            BillDate = BillDate_;
            _SellType = SellType_;
            BillDescription = "";
            _Customer = _MaintenanceOPR._Customer;
            _Currency = Currency_;
            ExchangeRate = ExchangeRate_;
            Discount = Discount_;
            Notes = Notes_;
        }
    }
}
