﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System.Repositories
{
    public interface IApplicationRepository<TEntity>
    {
        IList<TEntity> List();
        TEntity GetByID(int id);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
