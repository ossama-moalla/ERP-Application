using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class Missed_Fault_Item
    {
        public enum Missed_Fault:ushort
        {
            FAULT=1,
            MISSED=2
        }
        public int ID { get; }
        public ushort Type { get; }
        public DiagnosticOPR _DiagnosticOPR { get; }
        public Item _Item { get; }
        public string Location { get; }
        public string Notes { get; }
        public int TagsCount { get; }
        public Missed_Fault_Item(int ID_,
         ushort Type_,
         DiagnosticOPR DiagnosticOPR_,
         Item Item_,
         string Location_,
         string Notes_,
          int TagsCount_)
        {
            ID = ID_;
            Type = Type_;
            _DiagnosticOPR = DiagnosticOPR_;
            _Item = Item_;
            Location = Location_;
            Notes = Notes_;
            TagsCount = TagsCount_;

        }
        public string GetDesc()
        {
            if (Type ==(ushort) Missed_Fault.MISSED) return "عنصر مفقود ";
            else return "عنصر تالف ";
        }
    }
}
