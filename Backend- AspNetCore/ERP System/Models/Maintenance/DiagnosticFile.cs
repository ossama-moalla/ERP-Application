using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Maintenance
{
    public class DiagnosticFile
    {
        internal DiagnosticOPR _DiagnosticOPR;
        internal UInt32 FileID;
        internal string FileName;
        internal string FileDescription;
        internal long FileSize;
        internal DateTime AddDate;
        public DiagnosticFile(DiagnosticOPR DiagnosticOPR_, UInt32 FileID_, string FileName_, string FileDescription_, long filesize, DateTime addate)
        {
            _DiagnosticOPR = DiagnosticOPR_;
            FileID = FileID_;
            FileName = FileName_;
            FileDescription = FileDescription_;
            FileSize = filesize;
            AddDate = addate;
        }

    }
}
