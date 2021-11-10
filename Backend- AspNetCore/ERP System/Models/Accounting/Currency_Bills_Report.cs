using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    public class Currency_Bills_Report
    {
        public int CurrencyID;
        public string CurrencyName;
        public int BillINCount;
        public double BillINValue;
        public double BillIN_PaysValue;
        public int BillMaintenanceCount;
        public double BillMaintenanceValue;
        public double BillMaintenance_PaysValue;
        public int BillOUTCount;
        public double BillOUTValue;
        public double BillOUT_PaysValue;
        public Currency_Bills_Report(
              int CurrencyID_,
         string CurrencyName_,
         int BillINCount_,
         double BillINValue_,
         double BillIN_PaysValue_,
         int BillMaintenanceCount_,
         double BillMaintenanceValue_,
         double BillMaintenance_PaysValue_,
         int BillOUTCount_,
         double BillOUTValue_,
         double BillOUT_PaysValue_)
        {
            CurrencyID = CurrencyID_;
            CurrencyName = CurrencyName_;
            BillINCount = BillINCount_;
            BillINValue = BillINValue_;
            BillIN_PaysValue = BillIN_PaysValue_;
            BillMaintenanceCount = BillMaintenanceCount_;
            BillMaintenanceValue = BillMaintenanceValue_;
            BillMaintenance_PaysValue = BillMaintenance_PaysValue_;
            BillOUTCount = BillOUTCount_; ;
            BillOUTValue = BillOUTValue_;
            BillOUT_PaysValue = BillOUT_PaysValue_;
        }
    }
}
