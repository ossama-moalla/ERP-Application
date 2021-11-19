using ERP_System.Models.Accounting;
using ERP_System.Models.Materials;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class ItemOUT_Repo : IApplicationRepository<ItemOUT>
    {
        Application_Identity_DbContext DbContext;
        public ItemOUT_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public void Add(ItemOUT entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemOUT entity)
        {
            throw new NotImplementedException();
        }

        public ItemOUT GetByID(int id)
        {
            throw new NotImplementedException();
        }

        private OUTValue GetOUTValue(int itemoutid)
        {
            throw new NotImplementedException();
        }
        public bool Does_Operation_Has_ItemsOUT(int oprtype, int oprid)
        {
            throw new NotImplementedException();
        }
        public List<ItemOUT> GetItemOUTList(Operation operation)
        {
            throw new NotImplementedException();
        }
        public List<Money_Currency> GetItemOUTList_AS_Money_Currency(Operation operation)
        {
            throw new NotImplementedException();
        }
        public List<ItemOUT> GetItemIN_ItemOUTList(string Source, ItemIN itemin)
        {
            throw new NotImplementedException();
        }
        internal List<ItemOUT> GetItemOUTList_ForItem(Item Item_)
        {
            throw new NotImplementedException();
        }

        public IList<ItemOUT> List()
        {
            throw new NotImplementedException();
        }
    }
}
