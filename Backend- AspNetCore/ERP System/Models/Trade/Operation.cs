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
        public const uint RAVAGE = 8;
        public const uint REPAIROPR = 9;
        /// <summary>
        /// ////////////
        /// </summary>
        public uint OperationType;
        public uint OperationID;
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
                case RAVAGE:
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
                case RAVAGE:
                    operationname = "اتلاف عنصر";
                    break;
                case REPAIROPR:
                    operationname = "اخراج مادة عن طريق عملية اضلاح";
                    break;
                default:
                    throw new Exception("عملية غير صحيحة");
            }
            return operationname;
        }
        //public static void FillComboBoxBillType_PayIN(ref System.Windows.Forms.ComboBox ComboBox_, uint OperationType)
        //{
        //    ComboBox_.Items.Clear();
        //    int selected_index = 0;
        //    try
        //    {
        //        List<ComboboxItem> PayIN_OperationTypeList = new List<ComboboxItem>();
        //        PayIN_OperationTypeList.Add(new ComboboxItem("مبيع", Operation.BILL_SELL));
        //        PayIN_OperationTypeList.Add(new ComboboxItem("صيانة", Operation.BILL_MAINTENANCE));
        //        for (int i = 0; i < PayIN_OperationTypeList.Count; i++)
        //        {
        //            ComboBox_.Items.Add(PayIN_OperationTypeList[i]);
        //            if (OperationType == PayIN_OperationTypeList[i].Value)
        //                selected_index = i;
        //        }
        //        ComboBox_.SelectedIndex = selected_index;

        //    }
        //    catch
        //    {

        //    }
        //}
        //public static void FillComboBoxBillType_PayOUT(ref System.Windows.Forms.ComboBox ComboBox_, uint OperationType)
        //{
        //    ComboBox_.Items.Clear();
        //    int selected_index = 0;
        //    try
        //    {
        //        List<ComboboxItem> PayOut_OperationTypeList = new List<ComboboxItem>();
        //        PayOut_OperationTypeList.Add(new ComboboxItem("شراء", Operation.BILL_BUY));
        //        for (int i = 0; i < PayOut_OperationTypeList.Count; i++)
        //        {
        //            ComboBox_.Items.Add(PayOut_OperationTypeList[i]);
        //            if (OperationType == PayOut_OperationTypeList[i].Value)
        //                selected_index = i;
        //        }
        //        ComboBox_.SelectedIndex = selected_index;

        //    }
        //    catch
        //    {

        //    }
        //}
    }
}
