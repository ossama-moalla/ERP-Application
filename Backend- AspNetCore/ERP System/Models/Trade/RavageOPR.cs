using ERP_System.Models.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Trade
{
   
    public class RavageOPR
    {
        public Operation _Operation { get; }
        public DateTime RavageOPRDate { get; }
        public Department _Part { get; }
        public int ClauseCount { get; }
        public string Notes { get; }

        public RavageOPR(int RavageOPRID_, DateTime RavageOPRDate_,
            Department Part_, int ClauseCount_, string Notes_)
        {

            _Operation = new Operation(Operation.RavageOPR, RavageOPRID_);

            RavageOPRDate = RavageOPRDate_;
            _Part = Part_;

            ClauseCount = ClauseCount_;
            Notes = Notes_;
        }

    }
}
