using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class MaintenanceTagSummary
    {
        public int TagID { get; }
        public int TagType { get; }
        public int ID { get; }
        public string Desc { get; }
        public string TagINFO { get; }
        public MaintenanceTagSummary(int TagID_,
         int TagType_,
         int ID_,
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
