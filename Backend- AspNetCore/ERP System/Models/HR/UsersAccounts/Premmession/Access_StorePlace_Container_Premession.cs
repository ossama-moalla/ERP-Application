using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts.Premmession
{
    public class Access_StorePlace_Container_Premession
    {
        public uint PermissionID;
        public uint UserID;
        public StorePlaces_Container Container;
        public Access_StorePlace_Container_Premession(uint PermissionID_,
         uint UserID_,
         StorePlaces_Container Container_)
        {
            PermissionID = PermissionID_;
            UserID = UserID_;
            Container = Container_;
        }

    }
}
