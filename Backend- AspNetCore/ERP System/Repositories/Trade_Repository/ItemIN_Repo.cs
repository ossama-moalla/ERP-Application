using ERP_System.Models;
using ERP_System.Models.Accounting;
using ERP_System.Models.Trade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class ItemIN_Repo : IApplicationRepository<ItemIN>
    {
        private readonly Application_Identity_DbContext DbContext;

        public ItemIN_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }
        public ItemIN Add(ItemIN entity)
        {
            DbContext.Trade_ItemIN.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            if (entity == null) LocalException.ThrowNotFound("Delete Failed! Item IN with Id:" + entity.Id + " Not Exists");
            DbContext.Trade_ItemIN.Remove(entity);
            DbContext.SaveChanges();
            
        }

        public void Update(ItemIN entity)
        {
            var ItemIN = GetByID(entity.Id);
            if (ItemIN == null) LocalException.ThrowNotFound("Update Failed! Item IN with Id:" + entity.Id + " Not Exists"); ItemIN.ItemId = entity.ItemId;
            ItemIN.TradeStateId = entity.TradeStateId;
            ItemIN.ConsumeUnitId = entity.ConsumeUnitId;
            ItemIN.Amount = entity.Amount;
            ItemIN.SingleCost = entity.SingleCost;
            DbContext.SaveChanges();
            
        }
        private MoneyValue_Currency GetItemIN_SingleCost(ItemIN itemin)
        {
            //item in by Purchasesbill the singlecost willnot be null
            //item in by assembly  , the single cost will be calculated by sum of item in consists in assembly
            //item in by disassembly  , the single cost will be calculated by divide the orginal itemin by result items

            switch (itemin.OperationType)
            {
                case Operation.PURCHASES_BILL:
                   var purchasesbill=DbContext.Trade_PurchasesBill.Include(x=>x.Currency).SingleOrDefault(x=>x.Id==itemin.OperationId);
                    DbContext.Entry(purchasesbill).State = EntityState.Detached;
                    if (purchasesbill.Currency == null) purchasesbill.Currency = Currency.ReferenceCurrency;
                    return new MoneyValue_Currency() { MoneyValue=Convert.ToDouble(itemin.SingleCost),Currency=purchasesbill.Currency
                    ,ExchangeRate=purchasesbill.ExchangeRate};
                //case Operation.ASSEMBLAGE:
                //    var itemsout = ItemOUT_Repo.List().Where(x=>x.OperationId==itemin.OperationId&&x.OperationType==itemin.OperationType).ToList();
                //    double assemblage_itemincost = 0;
                //    foreach(var itemout in itemsout)
                //    {
                //        double single_cost=getItemIN_Value(itemout.ItemIN);
                //        assemblage_itemincost += (incost.Value / incost.ExchangeRate) * assemblage_itemoutlist[i].Amount;

                //    }
                //    for (int i = 0; i < assemblage_itemoutlist.Count; i++)
                //    {

                //        INCost incost = GetItemINCost(assemblage_itemoutlist[i]._ItemIN.ItemINID);

                //        assemblage_itemincost += (incost.Value / incost.ExchangeRate) * assemblage_itemoutlist[i].Amount;
                //    }
                //    double amount = Convert.ToDouble(t.Rows[0][ItemINTable.Amount].ToString());

                //    return new INCost(assemblage_itemincost / amount, referense_curruncy, 1);

                //case Operation.DISASSEMBLAGE:
                //    DisAssemblabgeOPR DisAssemblabgeOPR_ = new DisAssemblageSQL(DB).GetDisAssemblageOPR_INFO_BYID(_Operation.OperationID);
                //    return new INCost(Convert.ToDouble(t.Rows[0][2].ToString()), DisAssemblabgeOPR_._ItemOUT._OUTValue._Currency, DisAssemblabgeOPR_._ItemOUT._OUTValue.ExchangeRate);

                default:
                    throw new Exception("getItemIN_SingleCost:Incorrect ItemIN Data");
             }
        }
        public ItemIN GetByID(int id)
        {
            var itemin= DbContext.Trade_ItemIN.Include(x => x.ConsumeUnit)
                .Include(x => x.Item).Include(x => x.TradeState).SingleOrDefault(x => x.Id == id);
            DbContext.Entry(itemin).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            if (itemin == null) return null;
            itemin.SingleCost_MoneyValue_Currency = GetItemIN_SingleCost(itemin);
            return itemin;
        }

        public IList<ItemIN> List()
        {
            var itemsin= DbContext.Trade_ItemIN.Include(x => x.ConsumeUnit)
                .Include(x => x.Item).Include(x => x.TradeState).ToList();
            foreach(var itemin in itemsin)
            {
                DbContext.Entry(itemin).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                itemin.SingleCost_MoneyValue_Currency = GetItemIN_SingleCost(itemin);
            }
            return itemsin;
        }
    }
}
