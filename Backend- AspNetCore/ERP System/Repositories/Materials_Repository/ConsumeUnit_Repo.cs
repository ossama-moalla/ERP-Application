using ERP_System.Models.Materials;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class ConsumeUnit_Repo:IApplicationRepository<ConsumeUnit>
    {
        private readonly Application_Identity_DbContext Db_Context;
        public ConsumeUnit_Repo(Application_Identity_DbContext Db_Context_)
        {
            this.Db_Context = Db_Context_;
        }
        public ConsumeUnit Add(ConsumeUnit entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ConsumeUnit entity)
        {
            throw new NotImplementedException();
        }

        public ConsumeUnit GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ConsumeUnit> List()
        {
            throw new NotImplementedException();
        }
    }
}
