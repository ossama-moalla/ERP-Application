using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
    public class BillAdditionalClause
    {
        public Operation _Operation;
        public uint ClauseID;
        public string Description;
        public double Value;
        public BillAdditionalClause(Operation Operation_, uint ClauseID_
            , string Description_, double Value_)
        {
            _Operation = Operation_;
            ClauseID = ClauseID_;
            Description = Description_;
            Value = Value_;

        }
    }
}
