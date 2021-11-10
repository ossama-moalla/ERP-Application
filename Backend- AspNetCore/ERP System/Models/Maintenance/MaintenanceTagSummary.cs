using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class MaintenanceTagSummary
    {
        public uint TagID { get; }
        public uint TagType { get; }
        public uint ID { get; }
        public string Desc { get; }
        public string TagINFO { get; }
        public MaintenanceTagSummary(uint TagID_,
         uint TagType_,
         uint ID_,
         string Desc_,
         string TagINFO_)
        {
            TagID = TagID_;
            TagType = TagType_;
            ID = ID_;
            Desc = Desc_;
            TagINFO = TagINFO_;
        }
    }
}
