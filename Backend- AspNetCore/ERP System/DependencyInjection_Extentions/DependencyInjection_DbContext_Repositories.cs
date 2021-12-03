using ERP_System.Models.Materials;
using ERP_System.Repositories;
using ERP_System.Repositories.Materials_Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection_DbContext_Repositories
    {
        public static IServiceCollection Add_ApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IApplicationRepositoryEntityAddReturn<ItemCategory>, ItemCategory_Repo>();
            return services;
        }
    }
}
