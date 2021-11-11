using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts
{
    public class MoneyAccountPremession
    {
        public MoneyAccount _MoneyAccount;
        public bool Allow;
        public MoneyAccountPremession(MoneyAccount MoneyAccount_, bool Allow_)
        {
            _MoneyAccount = MoneyAccount_;
            Allow = Allow_;
        }
    }
}
