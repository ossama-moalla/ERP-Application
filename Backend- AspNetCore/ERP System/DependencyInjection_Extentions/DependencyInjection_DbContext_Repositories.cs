using ERP_System.Models.Accounting;
using ERP_System.Models.Materials;
using ERP_System.Models.Trade;
using ERP_System.Repositories;
using ERP_System.Repositories.Accounting_Repository;
using ERP_System.Repositories.Materials_Repository;
using ERP_System.Repositories.Trade_Repository;
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
            //---------------
            services.AddScoped<IApplicationRepository<Currency>, Currency_Repo>();
            services.AddScoped<IApplicationRepository<MoneyAccount>, MoneyAccount_Repo>();
            services.AddScoped<IApplicationRepository<PayIN>, PayIN_Repo>();
            services.AddScoped<IApplicationRepository<PayOUT>, PayOUT_Repo>();
            services.AddScoped<IApplicationRepository<ExchangeOPR>, ExchangeOPR_Repo>();
            services.AddScoped<IApplicationRepository<MoneyTransFormOPR>, MoneyTransFormOPR_Repo>();
            services.AddScoped<MoneyAccountReport_Repo>();
            //---------------
            services.AddScoped<IApplicationRepository<Dealer>, Dealer_Repo>();
            services.AddScoped<IApplicationRepository<BillAdditionalClause>, BillAdditionalClause_Repo>();
            services.AddScoped<IApplicationRepository<ItemIN>, ItemIN_Repo>();
            services.AddScoped<ItemINSellPrice_Repo>();
            services.AddScoped<IApplicationRepository<ItemOUT>, ItemOUT_Repo>();
            services.AddScoped<IApplicationRepository<PurchasesBill>, PurchasesBill_Repo>();
            services.AddScoped<IApplicationRepository<RavageOPR>, RavageOPR_Repo>();
            services.AddScoped<IApplicationRepository<SalesBill>, SalesBill_Repo>();
            services.AddScoped<IApplicationRepository<SellType>, SellType_Repo>();
            services.AddScoped<IApplicationRepository<TradeState>, TradeState_Repo>();

            return services;
        }
    }
}
