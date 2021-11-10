using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories
{
    interface IApplicationRepository<TEntity>
    {
        //IList<TEntity> List();
        TEntity GetByID(int id);
        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Delete(int id);
    }
}
