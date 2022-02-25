using ERP_System.Models.Materials;
using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class ItemINSellPrice_Repo
    {
        Application_Identity_DbContext DbContext;
        public ItemINSellPrice_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Set(ItemINSellPrice entity)
        {
            DbContext.Trade_ItemINSellPrice.Add(entity);
            DbContext.SaveChanges();
        }

        public void UnSet(int ItemINId,int SellTypeId,int? ConsumeUnitId)
        {
            var entity = GetByID(ItemINId,SellTypeId,ConsumeUnitId);
            DbContext.Trade_ItemINSellPrice.Remove(entity);
            DbContext.SaveChanges();
        }

        public ItemINSellPrice GetByID(int ItemINId, int SellTypeId, int? ConsumeUnitId)
        {
            return DbContext.Trade_ItemINSellPrice.SingleOrDefault(x => x.ItemINId == ItemINId&&x.SellTypeId==SellTypeId&&x.ConsumeUnitId==ConsumeUnitId);
        }

        public IList<ItemINSellPrice> List(int ItemINId)
        {
            return DbContext.Trade_ItemINSellPrice.Where(x=>x.ItemINId==ItemINId).ToList();
        }
    }
}
