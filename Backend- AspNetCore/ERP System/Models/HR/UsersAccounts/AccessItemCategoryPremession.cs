using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts
{
    public class AccessItemCategorysPremession
    {
        public uint PermissionID;
        public uint UserID;
        public ItemCategory _ItemCategory;
        public AccessItemCategorysPremession(uint PermissionID_,
         uint UserID_,
         ItemCategory ItemCategory_)
        {
            PermissionID = PermissionID_;
            UserID = UserID_;
            _ItemCategory = ItemCategory_;
        }
    }
}
