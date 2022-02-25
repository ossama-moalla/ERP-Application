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
            DbContext.Trade_ItemIN.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            DbContext.Trade_ItemIN.Remove(entity);
            DbContext.SaveChanges();
        }

        public void Update(ItemIN entity)
        {
            var ItemIN = GetByID(entity.Id);
            if (ItemIN != null)
            {
                ItemIN.ItemId = entity.ItemId;
                ItemIN.TradeStateId = entity.TradeStateId;
                ItemIN.ConsumeUnitId = entity.ConsumeUnitId;
                ItemIN.Amount = entity.Amount;
                ItemIN.SingleCost = entity.SingleCost;
                DbContext.SaveChanges();
            }
        }

        public ItemIN GetByID(int id)
        {
            return DbContext.Trade_ItemIN.SingleOrDefault(x => x.Id == id);
        }

        public IList<ItemIN> List()
        {
            return DbContext.Trade_ItemIN.ToList();
        }
    }
}
