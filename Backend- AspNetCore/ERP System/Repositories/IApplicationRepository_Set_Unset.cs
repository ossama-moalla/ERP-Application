using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories
{
    public interface IApplicationRepository_Set_Unset<TEntity>
    {
        IList<TEntity> List(List<int?> Ids);
        TEntity GetEntity(List<int?> Ids);
        void Set(TEntity entity);
        void Update(TEntity entity);

        void UnSet(List<int?> Ids);
    }
}
