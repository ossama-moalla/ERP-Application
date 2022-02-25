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
            DbContext.Trade_ItemOUT.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            DbContext.Trade_ItemOUT.Remove(entity);
            DbContext.SaveChanges();
        }

        public void Update(ItemOUT entity)
        {
            var ItemOUT = GetByID(entity.Id);
            if (ItemOUT != null)
            {
                ItemOUT.ItemINId = entity.ItemINId;
                ItemOUT.PlaceId = entity.PlaceId;
                ItemOUT.ConsumeUnitId = entity.ConsumeUnitId;
                ItemOUT.Amount = entity.Amount;
                ItemOUT.SingleOUTValue = entity.SingleOUTValue;
                DbContext.SaveChanges();
            }
        }

        public ItemOUT GetByID(int id)
        {
            return DbContext.Trade_ItemOUT.SingleOrDefault(x => x.Id == id);
        }

        public IList<ItemOUT> List()
        {
            return DbContext.Trade_ItemOUT.ToList();
        }
    }
}
