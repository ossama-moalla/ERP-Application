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
            string operationname = "";
            switch (operationtype)
            {
                case BILL_BUY:
                    operationname = "فاتور شراء";
                    break;
                case BILL_SELL:
                    operationname = "فاتور مبيع";
                    break;
                case BILL_MAINTENANCE:
                    operationname = "فاتور صيانة";
                    break;
                case Employee_PayOrder:
                    operationname = "امر صرف";
                    break;
                case MAINTENANCE_OPR:
                    operationname = "عملية صيانة";
                    break;
                case ASSEMBLAGE:
                    operationname = "عملية تجميع";
                    break;
                case DISASSEMBLAGE:
                    operationname = "عملية تفكيك";
                    break;
                case RavageOPR:
                    operationname = "عملية اتلاف";
                    break;
                case REPAIROPR:
                    operationname = "عملية اصلاح";
                    break;
            }
            return operationname;
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
