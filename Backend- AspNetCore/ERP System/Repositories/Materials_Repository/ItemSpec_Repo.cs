﻿using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ItemSpec_Repo : IApplicationRepository<ItemSpec>
    {
        Application_Identity_DbContext Db_Context;
        public ItemSpec_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public void Add(ItemSpec entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(ItemSpec entity)
        {
            throw new NotImplementedException();
        }

        public ItemSpec GetByID(int id)
        {
            throw new NotImplementedException();
        }

        
        public List<ItemSpec> GetItemSpecList(ItemCategory ItemCategory_)
        {
            return new List<ItemSpec>();
        }
    }
}
