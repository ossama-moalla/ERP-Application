using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class ItemIN_Repo : IApplicationRepository<ItemIN>
    {
        Application_Identity_DbContext DbContext;
        public ItemIN_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Add(ItemIN entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemIN entity)
        {
            throw new NotImplementedException();
        }

        public ItemIN GetByID(int id)
        {
            throw new NotImplementedException();
        }
        //public bool Does_Operation_Has_ItemsIN(int oprtype, int oprid)
        //{
        //    throw new NotImplementedException();
        //}
        //public List<ItemIN_ItemOUTReport> GetItemIN_ItemOUTReport_List(Operation operation)
        //{
        //    throw new NotImplementedException();
        //}
        //private INCost GetItemINCost(int iteminid)
        //{
        //    throw new NotImplementedException();
        //}
        //public List<ItemIN> GetItemINList(Operation operation)
        //{
        //    throw new NotImplementedException();
        //}
        //public List<ItemIN> Get_ALL_ItemIN_List()
        //{
        //    throw new NotImplementedException();
        //}
        //public List<ItemIN_ItemOUTReport> GetItemINList_ForItem(Item item)
        //{
        //    throw new NotImplementedException();
        //}
        //internal List<ItemIN_StoreReport> GetItemIN_StoreReportList(ItemIN itemIN_)
        //{
        //    throw new NotImplementedException();
        //}

        public IList<ItemIN> List()
        {
            throw new NotImplementedException();
        }
    }
}
