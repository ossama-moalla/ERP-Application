using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Models.HR.UsersAccounts
{
    public class MoneyAccountPremession
    {
        public Money_Account _MoneyAccount;
        public bool Allow;
        public MoneyAccountPremession(Money_Account MoneyAccount_, bool Allow_)
        {
            _MoneyAccount = MoneyAccount_;
            Allow = Allow_;
        }
    }
}
