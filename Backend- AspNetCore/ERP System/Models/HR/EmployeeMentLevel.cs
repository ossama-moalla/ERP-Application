using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR
{
    public class EmployeeMentLevel
    {
        public uint LevelID;
        public string LevelName;
        public EmployeeMentLevel(uint LevelID_, string LevelName_)
        {
            LevelID = LevelID_;
            LevelName = LevelName_;
        }
    }
}
