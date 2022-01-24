using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class Operation
    {
        public const int BILL_BUY = 1;
        public const int BILL_SELL = 2;
        public const int BILL_MAINTENANCE = 3;
        public const int Employee_PayOrder = 4;
        public const int MAINTENANCE_OPR = 5;
        public const int ASSEMBLAGE = 6;
        public const int DISASSEMBLAGE = 7;
        public const int RavageOPR = 8;
        public const int REPAIROPR = 9;
        /// <summary>
        /// ////////////
        /// </summary>
        public int OperationType { get; }
        public int OperationID { get; }
        public Operation(int OperationType_, int OperationID_)
        {
            OperationType = OperationType_;
            OperationID = OperationID_;
        }
        public static string GetOperationName(int operationtype)
        {
            switch (operationtype)
            {
                case BILL_BUY:
                    return "Buy Bill";
                case BILL_SELL:
                    return "Sell Bill";
                case BILL_MAINTENANCE:
                    return "Maintenance Bill";
                case Employee_PayOrder:
                    return "Pay Order";
                case MAINTENANCE_OPR:
                    return "Maintenance Operation";
                case ASSEMBLAGE:
                    return "Assemblage Operation";
                case DISASSEMBLAGE:
                    return "Disassemlage Operation";
                case RavageOPR:
                    return "Ravage Operation";
                case REPAIROPR:
                    return "Repair Operation";
                default:
                    throw new Exception( "Incorrect Operation");
            }
        }
        public static string GetOperationItemOutDesc(int operationtype)
        {

            string operationname = "";
            switch (operationtype)
            {

                case BILL_SELL:
                    operationname = "اخراج مادة عن طريق فاتورة مبيع";
                    break;

                case BILL_MAINTENANCE:
                    operationname = "اخراج مادة عن طريق فاتورة صيانة";
                    break;
                case ASSEMBLAGE:
                    operationname = "ادراج عنصر في عملية تجميع";
                    break;
                case DISASSEMBLAGE:
                    operationname = "تفكيك عنصر";
                    break;
                case RavageOPR:
                    operationname = "اتلاف عنصر";
                    break;
                case REPAIROPR:
                    operationname = "اخراج مادة عن طريق عملية اصلاح";
                    break;
                default:
                    throw new Exception("عملية غير صحيحة");
            }
            return operationname;
        }
        
    }
}
