using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts
{
    public class AccessSellTypePremession
    {
        public int UserID;
        public SellType _SellType;
        public bool Access;
        public AccessSellTypePremession(
         int UserID_,
         SellType SellType_,
         bool Access_)
        {

            UserID = UserID_;
            _SellType = SellType_;
            Access = Access_;
        }
    }
}
