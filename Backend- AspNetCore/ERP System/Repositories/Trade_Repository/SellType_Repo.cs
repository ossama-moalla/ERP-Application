using ERP_System.Models.Trade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Trade_Repository
{
    public class SellType_Repo : IApplicationRepository<SellType>
    {
        Application_Identity_DbContext DbContext;
        public SellType_Repo(Application_Identity_DbContext DbContext_)
        {
            DbContext = DbContext_;
        }

        public void Add(SellType entity)
        {
            DbContext.Trade_SellType.Add(entity);
            DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetByID(id);
            DbContext.Trade_SellType.Remove(entity);
            DbContext.SaveChanges();
        }

        public void Update(SellType entity)
        {
            var SellType = GetByID(entity.Id);
            if (SellType != null)
            {
                SellType.Name = entity.Name;
                DbContext.SaveChanges();
            }
        }

        public SellType GetByID(int id)
        {
            return DbContext.Trade_SellType.SingleOrDefault(x => x.Id == id);
        }

        public IList<SellType> List()
        {
            return DbContext.Trade_SellType.ToList();
        }
    }
}
