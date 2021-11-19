using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts.Premmession
{

    public class Access_ItemCategory_Premession
    {
        public int PermissionID;
        public int UserID;
        public ItemCategory _ItemCategory;
        public Access_ItemCategory_Premession(int PermissionID_,
         int UserID_,
         ItemCategory ItemCategory_)
        {
            PermissionID = PermissionID_;
            UserID = UserID_;
            _ItemCategory = ItemCategory_;
        }

    }
}
