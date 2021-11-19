using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.AvailableItems
{
    public class ItemIN_AvailableAmount_Report
    {
        public int OperationType { get; }
        public int OperationID { get; }
        public int ItemINID { get; }
        public string ConsumeUnit { get; }
        public double Amount { get; }
        public int ItemID { get; }
        public string ItemName { get; }

        public string ItemCompany { get; }
        public int FolderID { get; }

        public string FolderName { get; }
        public string FolderPath { get; }
        public int TradeStateID { get; }
        public string TradeStateName { get; }
        public double AvailableAmount { get; }

        public ItemIN_AvailableAmount_Report(
              int OperationType_,
         int OperationID_,
        int ItemINID_,
         string ConsumeUnit_,
         double Amount_,
        int ItemID_,
         string ItemName_,

         string ItemCompany_,
         int FolderID_,
         string FolderName_,
         string FolderPath_,
         int TradeStateID_,
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
    //                int OperationType = Convert.ToInt32(table.Rows[i]["OperationType"]);
    //                int OperationID = Convert.ToInt32(table.Rows[i]["OperationID"]);

    //                int ItemINID = Convert.ToInt32(table.Rows[i]["ItemINID"]);
    //                string ConsumeUnit = table.Rows[i]["ConsumeUnit"].ToString();
    //                double Amount = Convert.ToDouble(table.Rows[i]["Amount"]);

    //                int ItemID = Convert.ToInt32(table.Rows[i]["ItemID"]);
    //                string ItemName = table.Rows[i]["ItemName"].ToString();
    //                string ItemCompany = table.Rows[i]["ItemCompany"].ToString();
    //                int FolderID = Convert.ToInt32(table.Rows[i]["FolderID"]);
    //                string FolderName = table.Rows[i]["FolderName"].ToString();
    //                string FolderPath = table.Rows[i]["FolderPath"].ToString();
    //                int TradeStateID = Convert.ToInt32(table.Rows[i]["TradeStateID"]);

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
