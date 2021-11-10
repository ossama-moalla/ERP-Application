using ERP_System.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts
{
    public class AccessContainerPremession
    {
        public uint PermissionID;
        public uint UserID;
        public StorePlaces_Container Container;
        public AccessContainerPremession(uint PermissionID_,
         uint UserID_,
         StorePlaces_Container Container_)
        {
            PermissionID = PermissionID_;
            UserID = UserID_;
            Container = Container_;
        }
    }
}
