using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts.Premmession
{
    public class Access_StorePlace_Container_Premession
    {
        public int PermissionID;
        public int UserID;
        public StorePlace_Container Container;
        public Access_StorePlace_Container_Premession(int PermissionID_,
         int UserID_,
         StorePlace_Container Container_)
        {
            PermissionID = PermissionID_;
            UserID = UserID_;
            Container = Container_;
        }

    }
}
