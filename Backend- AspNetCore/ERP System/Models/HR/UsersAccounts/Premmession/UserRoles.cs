using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts.Premmession
{

    public static class UserRoles
    {
        public const string Admin_All = "Admin_ALL";//Full Access
        public const string Admin_Sales = "Admin_Sales";//Create-update-delete Sales Bill
        public const string Admin_Purchase = "Admin_Purchase";
        public const string Admin_MAINTENANCE = "Admin_MAINTENANCE";
        public const string Admin_HR = "Admin_HR";
        public const string Admin_Dealers = "Admin_Dealers";
        public const string Admin_INDUSTRY = "Admin_INDUSTRY";
        public const string Admin_Store = "Admin_Store";
    }
}
