using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.AvailableItems
{
    public class ItemIN_AvailableAmount_Report
    {
        public uint OperationType { get; }
        public uint OperationID { get; }
        public uint ItemINID { get; }
        public string ConsumeUnit { get; }
        public double Amount { get; }
        public uint ItemID { get; }
        public string ItemName { get; }

        public string ItemCompany { get; }
        public uint FolderID { get; }

        public string FolderName { get; }
        public string FolderPath { get; }
        public uint TradeStateID { get; }
        public string TradeStateName { get; }
        public double AvailableAmount { get; }

        public ItemIN_AvailableAmount_Report(
              uint OperationType_,
         uint OperationID_,
        uint ItemINID_,
         string ConsumeUnit_,
         double Amount_,
        uint ItemID_,
         string ItemName_,

         string ItemCompany_,
         uint FolderID_,
         string FolderName_,
         string FolderPath_,
         uint TradeStateID_,
         string TradeStateName_,
         double AvailableAmount_
    )
        {
            OperationType = OperationType_;
            OperationID = OperationID_;

            ItemINID = ItemINID_;
            ConsumeUnit = ConsumeUnit_;
            Amount = Amount_;
            ItemID = ItemID_;
            ItemName = ItemName_;
            ItemCompany = ItemCompany_;
            FolderID = FolderID_;
            FolderName = FolderName_;
            FolderPath = FolderPath_;
            TradeStateID = TradeStateID_;
            TradeStateName = TradeStateName_;
            AvailableAmount = AvailableAmount_;
        }
    //    internal static List<ItemIN_AvailableAmount_Report> Get_ItemIN_AvailableAmount_Report_List_From_DataTable(DataTable table)
    //    {
    //        try
    //        {
    //            List<ItemIN_AvailableAmount_Report> list = new List<ItemIN_AvailableAmount_Report>();
    //            for (int i = 0; i < table.Rows.Count; i++)
    //            {
    //                uint OperationType = Convert.ToUInt32(table.Rows[i]["OperationType"]);
    //                uint OperationID = Convert.ToUInt32(table.Rows[i]["OperationID"]);

    //                uint ItemINID = Convert.ToUInt32(table.Rows[i]["ItemINID"]);
    //                string ConsumeUnit = table.Rows[i]["ConsumeUnit"].ToString();
    //                double Amount = Convert.ToDouble(table.Rows[i]["Amount"]);

    //                uint ItemID = Convert.ToUInt32(table.Rows[i]["ItemID"]);
    //                string ItemName = table.Rows[i]["ItemName"].ToString();
    //                string ItemCompany = table.Rows[i]["ItemCompany"].ToString();
    //                uint FolderID = Convert.ToUInt32(table.Rows[i]["FolderID"]);
    //                string FolderName = table.Rows[i]["FolderName"].ToString();
    //                string FolderPath = table.Rows[i]["FolderPath"].ToString();
    //                uint TradeStateID = Convert.ToUInt32(table.Rows[i]["TradeStateID"]);

    //                string TradeStateName = table.Rows[i]["TradeStateName"].ToString();
    //                double AvailableAmount = Convert.ToDouble(table.Rows[i]["AvailableAmount"]);
    //                list.Add(new ItemIN_AvailableAmount_Report(OperationType, OperationID,
    //                    ItemINID, ConsumeUnit, Amount, ItemID,
    //      ItemName,
    //      ItemCompany,
    //       FolderID,
    //      FolderName,
    //      FolderPath,
    //      TradeStateID,
    //      TradeStateName,
    //      AvailableAmount

    //));
    //            }
    //            return list;
    //        }
    //        catch (Exception ee)
    //        {
    //            throw new Exception("Get_ItemIN_AvailableAmount_Report_List_From_DataTable:" + "," + ee.Message);
    //        }
    //    }

    }
}
