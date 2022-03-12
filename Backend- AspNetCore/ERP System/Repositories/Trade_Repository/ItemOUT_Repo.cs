using ERP_System.Models;
using ERP_System.Models.Accounting;
using ERP_System.Models.Materials;
using ERP_System.Models.Trade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class ItemOUT_Repo : IApplicationRepository<ItemOUT>
    {
        private readonly Application_Identity_DbContext DbContext;
        private readonly IApplicationRepository<ItemIN> itemIN_Repo;

        public ItemOUT_Repo(Application_Identity_DbContext DbContext_
            , IApplicationRepository<ItemIN> itemIN_Repo)
        {
            DbContext = DbContext_;
            this.itemIN_Repo = itemIN_Repo;
        }

        public ItemOUT Add(ItemOUT entity)
        {
            DbContext.Trade_ItemOUT.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var ItemOUT = GetByID(id);
            if (ItemOUT == null) LocalException.ThrowNotFound("Delete Failed! Item Out with Id:" + id + " Not Exists");
            DbContext.Trade_ItemOUT.Remove(ItemOUT);
            DbContext.SaveChanges();
            
        }

        public void Update(ItemOUT entity)
        {
            var ItemOUT = GetByID(entity.Id);
            if (ItemOUT == null) LocalException.ThrowNotFound("Update Failed! Item Out with Id:" + entity.Id + " Not Exists");
            ItemOUT.ItemINId = entity.ItemINId;
            ItemOUT.PlaceId = entity.PlaceId;
            ItemOUT.ConsumeUnitId = entity.ConsumeUnitId;
            ItemOUT.Amount = entity.Amount;
            ItemOUT.SingleOUTValue = entity.SingleOUTValue;
            DbContext.SaveChanges();
            
        }
        private MoneyValue_Currency GetItemOUT_SingleOUTValue(ItemOUT itemout)
        {
            //item out by salesbill the single out value willnot be null

            switch (itemout.OperationType)
            {
                case Operation.SALES_BILL:
                    var salesbill = DbContext.Trade_SalesBill.Include(x=>x.Currency)
                        .SingleOrDefault(x=>x.Id==itemout.OperationId);
                    DbContext.Entry(salesbill).State = EntityState.Detached;
                    if (salesbill.Currency == null) salesbill.Currency = Currency.ReferenceCurrency;
                    return new MoneyValue_Currency()
                    {
                        MoneyValue = Convert.ToDouble(itemout.SingleOUTValue),
                        Currency = salesbill.Currency,
                        ExchangeRate = salesbill.ExchangeRate
                    };
                //case Operation.ASSEMBLAGE:
                //    var itemsout = ItemOUT_Repo.List().Where(x=>x.OperationId==itemout.OperationId&&x.OperationType==itemout.OperationType).ToList();
                //    double assemblage_itemoutcost = 0;
                //    foreach(var itemout in itemsout)
                //    {
                //        double single_cost=getItemOUT_Value(itemout.ItemOUT);
                //        assemblage_itemoutcost += (incost.Value / incost.ExchangeRate) * assemblage_itemoutlist[i].Amount;

                //    }
                //    for (int i = 0; i < assemblage_itemoutlist.Count; i++)
                //    {

                //        INCost incost = GetItemOUTCost(assemblage_itemoutlist[i]._ItemOUT.ItemOUTID);

                //        assemblage_itemoutcost += (incost.Value / incost.ExchangeRate) * assemblage_itemoutlist[i].Amount;
                //    }
                //    double amount = Convert.ToDouble(t.Rows[0][ItemOUTTable.Amount].ToString());

                //    return new INCost(assemblage_itemoutcost / amount, referense_curruncy, 1);

                //case Operation.DISASSEMBLAGE:
                //    DisAssemblabgeOPR DisAssemblabgeOPR_ = new DisAssemblageSQL(DB).GetDisAssemblageOPR_INFO_BYID(_Operation.OperationID);
                //    return new INCost(Convert.ToDouble(t.Rows[0][2].ToString()), DisAssemblabgeOPR_._ItemOUT._OUTValue._Currency, DisAssemblabgeOPR_._ItemOUT._OUTValue.ExchangeRate);

                default:
                    throw new Exception("getItemOUT_SingleCost:Incorrect ItemOUT Data");
            }
        }
        public ItemOUT GetByID(int id)
        {
            var itemout = DbContext.Trade_ItemOUT.Include(x => x.ConsumeUnit).SingleOrDefault(x => x.Id == id);
            DbContext.Entry(itemout).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            if (itemout == null) return null;
            itemout.ItemIN = itemIN_Repo.GetByID(itemout.ItemINId);
            itemout.SingleOUTValue_MoneyValue_Currency = GetItemOUT_SingleOUTValue(itemout);
            return itemout;
        }

        public IList<ItemOUT> List()
        {
            var itemsout = DbContext.Trade_ItemOUT.Include(x=>x.ConsumeUnit).ToList();
            foreach (var itemout in itemsout)
            {
                DbContext.Entry(itemout).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                itemout.ItemIN = itemIN_Repo.GetByID(itemout.ItemINId);
                itemout.SingleOUTValue_MoneyValue_Currency = GetItemOUT_SingleOUTValue(itemout);

            }
            return itemsout;
        }
    }
}
