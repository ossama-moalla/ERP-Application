using ERP_System.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Accounting_Repository
{
    public class MoneyTransFormOPR_Repo : IApplicationRepository<MoneyTransFormOPR>
    {
        public void Add(MoneyTransFormOPR entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(MoneyTransFormOPR entity)
        {
            throw new NotImplementedException();
        }

        public MoneyTransFormOPR GetByID(int id)
        {
            throw new NotImplementedException();
        }
        internal List<MoneyTransFormOPR> Get_All_MoneyTransFormOPRList()
        {
            throw new NotImplementedException();
        }
        internal List<MoneyCurrency> GetMoneyTransFormOPRList_As_MoneyCurrency()
        {
            throw new NotImplementedException();
        }
        internal List<MoneyTransFormOPR> Get_Stuck_MoneyTransformOPR_IN_List(MoneyAccount moneyAccount)
        {
            throw new NotImplementedException();
        }
        internal List<MoneyTransFormOPR> Get_Stuck_MoneyTransformOPR_OUT_List(MoneyAccount moneyAccount)
        {
            throw new NotImplementedException();
        }
    }
}
