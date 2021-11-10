using ERP_System.Models.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class Equivalence_Group_Repo : IApplicationRepository<Equivalence_Group>
    {
        Application_Identity_DbContext Db_Context;
        public Equivalence_Group_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }
        public void Add(Equivalence_Group entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Equivalence_Group entity)
        {
            throw new NotImplementedException();
        }

        public Equivalence_Group GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public List<Equivalence_Group> GetEquivalence_GroupList()
        {
            throw new NotImplementedException();

        }
    }
}
