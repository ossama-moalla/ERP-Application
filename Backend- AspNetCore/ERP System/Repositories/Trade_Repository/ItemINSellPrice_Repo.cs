using ERP_System.Models.Materials;
using ERP_System.Models.Trade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class ItemINSellPrice_Repo:IApplicationRepository_Set_Unset<ItemINSellPrice>
    {
        private readonly Application_Identity_DbContext DbContext;
        public ItemINSellPrice_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public void Set(ItemINSellPrice entity)
        {
            DbContext.Trade_ItemINSellPrice.Add(entity);
            DbContext.SaveChanges();
            
        }

        public void UnSet(List<int?> Ids)
        {
            var entity = GetEntity(Ids);
            if (entity == null) LocalException.ThrowNotFound("Delete Failed! Item In Sell Price Not Set");
            DbContext.Trade_ItemINSellPrice.Remove(entity);
            DbContext.SaveChanges();
            
        }
        public  void Update(ItemINSellPrice entity)
        {
            List<int?> Ids = new () { entity.ItemINId, entity.SellTypeId, entity.ConsumeUnitId };
            var iteminsellprice = GetEntity(Ids);
            if (iteminsellprice == null) LocalException.ThrowNotFound("Update Failed! Item In Sell Price  Not Set");
            iteminsellprice.Price = entity.Price;
            DbContext.SaveChanges();
            
        }
        public  ItemINSellPrice GetEntity(List<int?> Ids)
        {
            return DbContext.Trade_ItemINSellPrice.SingleOrDefault(x => x.ItemINId == Ids[0]&&x.SellTypeId== Ids[1]&& x.ConsumeUnitId== Ids[2]);
        }

        public IList<ItemINSellPrice> List(List<int?> Ids)
        {
            return DbContext.Trade_ItemINSellPrice.Where(x=>x.ItemINId==Ids[0]).ToList();
        }

    }
}
