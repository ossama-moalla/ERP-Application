using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts.Premmession
{
    public class Access_SellType_Premession
    {
        public uint UserID;
        public SellType _SellType;
        public bool Access;
        public Access_SellType_Premession(
         uint UserID_,
         SellType SellType_,
         bool Access_)
        {

            UserID = UserID_;
            _SellType = SellType_;
            Access = Access_;
        }

    }
}
