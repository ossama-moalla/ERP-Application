using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts.Premmession
{
    public class Access_Money_Account_Premession
    {

        public MoneyAccount _Money_Account;
        public bool Allow;
        public Access_Money_Account_Premession(MoneyAccount Money_Account_, bool Allow_)
        {
            _Money_Account = Money_Account_;
            Allow = Allow_;
        }

    }
}
