using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.AvailableItems
{
    public class Item_AvailableAmount_Report
    {
        public int ItemID { get; }
        public string ItemName { get; }

        public string ItemCompany { get; }
        public int FolderID { get; }

        public string FolderName { get; }
        public string FolderPath { get; }
        public List<TradeState_AvailableAmount> TradeState_AvailableAmount { get; }

        public Item_AvailableAmount_Report(
            int ItemID_,
         string ItemName_,

         string ItemCompany_,
         int FolderID_,
         string FolderName_,
         string FolderPath_,
         List<TradeState_AvailableAmount> TradeState_AvailableAmount_
    )
        {
            ItemID = ItemID_;
            ItemName = ItemName_;
            ItemCompany = ItemCompany_;
            FolderID = FolderID_;
            FolderName = FolderName_;
            FolderPath = FolderPath_;
            TradeState_AvailableAmount = TradeState_AvailableAmount_;
        }
        private class Temp_Item_AvailableAmount_Report
        {
            public int ItemID { get; }
            public string ItemName { get; }

            public string ItemCompany { get; }
            public int FolderID { get; }

            public string FolderName { get; }
            public string FolderPath { get; }
            public int TradeStateID { get; }
            public string TradeStateName { get; }
            public double AvailableAmount { get; }

            public Temp_Item_AvailableAmount_Report(
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
        }
    //    internal static List<Item_AvailableAmount_Report> Get_Item_AvailableAmount_Report_List_From_DataTable(DataTable table)
    //    {
    //        try
    //        {
    //            List<Item_AvailableAmount_Report> list = new List<Item_AvailableAmount_Report>();
    //            List<Temp_Item_AvailableAmount_Report> Temp_list = new List<Temp_Item_AvailableAmount_Report>();
    //            for (int i = 0; i < table.Rows.Count; i++)
    //            {
    //                int ItemID = Convert.ToInt32(table.Rows[i]["ItemID"]);
    //                string ItemName = table.Rows[i]["ItemName"].ToString();
    //                string ItemCompany = table.Rows[i]["ItemCompany"].ToString();
    //                int FolderID = Convert.ToInt32(table.Rows[i]["FolderID"]);
    //                string FolderName = table.Rows[i]["FolderName"].ToString();
    //                string FolderPath = table.Rows[i]["FolderPath"].ToString();
    //                int TradeStateID = Convert.ToInt32(table.Rows[i]["TradeStateID"]);

    //                string TradeStateName = table.Rows[i]["TradeStateName"].ToString();
    //                double AvailableAmount = Convert.ToDouble(table.Rows[i]["AvailableAmount"]);
    //                Temp_list.Add(new Temp_Item_AvailableAmount_Report(ItemID,
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
    //            List<TradeState> TradeStateList = new List<TradeState>();
    //            List<int> TradeStateIDList = Temp_list.Select(x => x.TradeStateID).Distinct().ToList();
    //            for (int i = 0; i < TradeStateIDList.Count; i++)
    //            {
    //                Temp_Item_AvailableAmount_Report Temp_Item_AvailableAmount_Report_ = Temp_list.Where(x => x.TradeStateID == TradeStateIDList[i]).ToList()[0];
    //                TradeStateList.Add(new TradeState(TradeStateIDList[i], Temp_Item_AvailableAmount_Report_.TradeStateName));
    //            }
    //            List<int> ItemID_List = Temp_list.Select(x => x.ItemID).Distinct().ToList();
    //            for (int i = 0; i < ItemID_List.Count; i++)
    //            {
    //                List<Temp_Item_AvailableAmount_Report> Temp_Item_AvailableAmount_Report_List = Temp_list.Where(x => x.ItemID == ItemID_List[i]).ToList();
    //                List<TradeState_AvailableAmount> TradeState_AvailableAmountList = new List<Objects.TradeState_AvailableAmount>();
    //                for (int j = 0; j < TradeStateList.Count; j++)
    //                {
    //                    double a_v = Temp_Item_AvailableAmount_Report_List.Where(x => x.TradeStateID == TradeStateList[j].TradeStateID && ItemID_List[i] == x.ItemID).Sum(y => y.AvailableAmount);
    //                    TradeState_AvailableAmountList.Add(new Objects.TradeState_AvailableAmount(TradeStateList[j], a_v));
    //                }
    //                list.Add(new Item_AvailableAmount_Report(Temp_Item_AvailableAmount_Report_List[0].ItemID
    //                    , Temp_Item_AvailableAmount_Report_List[0].ItemName, Temp_Item_AvailableAmount_Report_List[0].ItemCompany
    //                    , Temp_Item_AvailableAmount_Report_List[0].FolderID, Temp_Item_AvailableAmount_Report_List[0].FolderName
    //                    , Temp_Item_AvailableAmount_Report_List[0].FolderPath, TradeState_AvailableAmountList));

    //            }
    //            return list;
    //        }
    //        catch (Exception ee)
    //        {
    //            throw new Exception("Get_Item_AvailableAmount_Report_List_From_DataTable:" + "," + ee.Message);
    //        }
    //    }

    }
}
