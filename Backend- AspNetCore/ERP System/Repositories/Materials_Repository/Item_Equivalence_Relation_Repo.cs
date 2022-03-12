using ERP_System.Models.Materials;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories.Materials_Repository
{
    public class Item_Equivalence_Relation_Repo :IApplicationRepository_Set_Unset<Item_Equivalence_Relation>
    {
        private readonly Application_Identity_DbContext Db_Context;
        public Item_Equivalence_Relation_Repo(Application_Identity_DbContext Db_Context_)
        {
            Db_Context = Db_Context_;
        }

        public Item_Equivalence_Relation GetEntity(List<int?> Ids)
        {
            throw new NotImplementedException();
        }

        public IList<Item_Equivalence_Relation> List(List<int?> Ids)
        {
            throw new NotImplementedException();
        }

        public void Set(Item_Equivalence_Relation entity)
        {
            throw new NotImplementedException();
        }

        public void UnSet(List<int?> Ids)
        {
            throw new NotImplementedException();
        }

        public void Update(Item_Equivalence_Relation entity)
        {
            throw new NotImplementedException();
        }
    }
}
