using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class Operation
    {
        //operation is used becuase some objects need to belong to many objects like:
        // payin belong to :no thing,salses bill,mainteneace bill
        //payout belong to :no thing,purchases bill,employeepayorder
        //itemin by:purchases bill or assembly operation
        //itemout by:sales bill,repair operation(belong to maintenance bill),internal consume,ravage opr ,disassmbly
        public const int PURCHASES_BILL = 1;
        public const int SALES_BILL = 2;
        public const int MAINTENANCE_BILL = 3;
        public const int Employee_PayOrder = 4;
        public const int MAINTENANCE_OPR = 5;
        public const int ASSEMBLAGE = 6;
        public const int DISASSEMBLAGE = 7;
        public const int RAVAGEOPR = 8;
        public const int INTERNALCONSUME = 9;
        public const int REPAIROPR = 10;
        /// <summary>
        /// ////////////
        /// </summary>
        public int OperationType { get; set; }
        public int OperationID { get; set; }
        public static string GetOperationName(int operationtype)
        {
            return (operationtype) switch
            {
                PURCHASES_BILL => "Purchases Bill",
                SALES_BILL => "Sales Bill",
                MAINTENANCE_BILL => "Maintenance Bill",
                Employee_PayOrder => "Pay Order",
                MAINTENANCE_OPR => "Maintenance Operation",
                ASSEMBLAGE => "Assemblage Operation",
                DISASSEMBLAGE => "Disassemlage Operation",
                RAVAGEOPR => "Ravage Operation",
                INTERNALCONSUME => "Internal Consume Operation",
                REPAIROPR => "Repair Operation",
                _ => throw new Exception("Incorrect Operation"),
            };
        }
        
    }
}
