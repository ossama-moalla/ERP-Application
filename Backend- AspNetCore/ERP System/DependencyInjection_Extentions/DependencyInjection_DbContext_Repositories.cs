using ERP_System.Models.Accounting;
using ERP_System.Models.Materials;
using ERP_System.Repositories;
using ERP_System.Repositories.Accounting_Repository;
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
            services.AddScoped<IApplicationRepositoryEntityAddReturn<Item>, Item_Repo>();
            services.AddScoped<IApplicationRepository<ItemCategorySpec>, ItemCategorySpec_Repo>();
            services.AddScoped<IApplicationRepository<Currency>, Currency_Repo>();
            services.AddScoped<IApplicationRepository<MoneyAccount>, MoneyAccount_Repo>();
            services.AddScoped<IApplicationRepository<PayIN>, PayIN_Repo>();
            services.AddScoped<IApplicationRepository<PayOUT>, PayOUT_Repo>();
            services.AddScoped<IApplicationRepository<ExchangeOPR>, ExchangeOPR_Repo>();
            services.AddScoped<IApplicationRepository<MoneyTransFormOPR>, MoneyTransFormOPR_Repo>();



            return services;
        }
    }
}
