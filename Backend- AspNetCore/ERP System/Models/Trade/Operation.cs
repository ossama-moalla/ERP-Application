using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class Operation
    {
        public const uint BILL_BUY = 1;
        public const uint BILL_SELL = 2;
        public const uint BILL_MAINTENANCE = 3;
        public const uint Employee_PayOrder = 4;
        public const uint MAINTENANCE_OPR = 5;
        public const uint ASSEMBLAGE = 6;
        public const uint DISASSEMBLAGE = 7;
        public const uint RavageOPR = 8;
        public const uint REPAIROPR = 9;
        /// <summary>
        /// ////////////
        /// </summary>
        public uint OperationType { get; }
        public uint OperationID { get; }
        public Operation(uint OperationType_, uint OperationID_)
        {
            OperationType = OperationType_;
            OperationID = OperationID_;
        }
        public static string GetOperationName(uint operationtype)
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
        public static string GetOperationItemOutDesc(uint operationtype)
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
