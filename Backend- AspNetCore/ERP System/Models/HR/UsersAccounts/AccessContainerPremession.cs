using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts
{
    public class AccessContainerPremession
    {
        public int PermissionID;
        public int UserID;
        public StorePlace_Container Container;
        public AccessContainerPremession(int PermissionID_,
         int UserID_,
         StorePlace_Container Container_)
        {
            PermissionID = PermissionID_;
            UserID = UserID_;
            Container = Container_;
        }
    }
}
