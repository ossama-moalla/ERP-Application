using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts
{
    public class AccessItemCategorysPremession
    {
        public int PermissionID;
        public int UserID;
        public ItemCategory _ItemCategory;
        public AccessItemCategorysPremession(int PermissionID_,
         int UserID_,
         ItemCategory ItemCategory_)
        {
            PermissionID = PermissionID_;
            UserID = UserID_;
            _ItemCategory = ItemCategory_;
        }
    }
}
