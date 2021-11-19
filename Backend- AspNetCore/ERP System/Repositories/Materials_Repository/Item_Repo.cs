using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class Item_Repo : IApplicationRepository<Item>
    {
        Application_Identity_DbContext Db_Context;
        public Item_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public void Add(Item entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Item entity)
        {
            throw new NotImplementedException();
        }

        public Item GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Item> List()
        {
            throw new NotImplementedException();
        }

        
        
    }
}
