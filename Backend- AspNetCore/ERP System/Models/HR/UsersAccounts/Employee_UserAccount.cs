using ERP_System.Models.HR;
using ERP_System.Models.HR.UsersAccounts.Premmession;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts
{
    public class Employee_UserAccount:IdentityUser
    {
       
       // public DateTime adddate { get; set; }
        //public bool Disabled { get; set; }
        internal Employee _Employee { get; set; }
        internal List<Access_ItemCategory_Premession> AccessItemCategorysPremessionList { get; set; }
        internal List<Access_Money_Account_Premession> AccessContainerPremessionList { get; set; }
        internal List<Access_SellType_Premession> AccessSellTypePremessionList { get; set; }
        internal List<Access_StorePlace_Container_Premession> AccessStoreContainerPremessionList { get; set; }


    }
}
