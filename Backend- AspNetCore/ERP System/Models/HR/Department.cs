using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR
{
    public class Department
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public uint? ParentID { get; set; }

        public Department(uint ID_, string Name_, DateTime CreateDate_, uint? ParentID_)
        {
            ID = ID_;
            Name = Name_;
            CreateDate = CreateDate_;
            ParentID = ParentID_;

        }
    }
}
