using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.Accounting
{
    public class Money_Account
    {
        public uint AccountIDID;
        public string AccountIDName;
        public Money_Account(uint AccountIDID_,
         string AccountIDName_)
        {
            AccountIDID = AccountIDID_;
            AccountIDName = AccountIDName_;
        }
    }
}
