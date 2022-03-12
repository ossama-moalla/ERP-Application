using ERP_System.Models.Trade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class Dealer_Repo : IApplicationRepository<Dealer>
    {
        private readonly Application_Identity_DbContext DbContext;
        public Dealer_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public Dealer Add(Dealer entity)
        {
            DbContext.Trade_Dealer.Add(entity);
            DbContext.SaveChanges();
            return entity;
            
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            if (entity == null) LocalException.ThrowNotFound("Delete Failed! Dealer with Id:" + id + " Not Exists");
            DbContext.Trade_Dealer.Remove(entity);
            DbContext.SaveChanges();
            
        }

        public void Update(Dealer entity)
        {
            var Dealer = GetByID(entity.Id);
            if (Dealer == null) LocalException.ThrowNotFound("Update Failed! Dealer with Id:" + entity.Id + " Not Exists");
            Dealer.FullName = entity.FullName;
            Dealer.Phone = entity.Phone;
            Dealer.Mobile = entity.Mobile;
            Dealer.Address = entity.Address;
            DbContext.SaveChanges();
            
        }

        public Dealer GetByID(int id)
        {
            return DbContext.Trade_Dealer.SingleOrDefault(x => x.Id == id);
        }

        public IList<Dealer> List()
        {
            return DbContext.Trade_Dealer.ToList();
        }
    }
}
