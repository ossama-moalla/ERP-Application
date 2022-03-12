using ERP_System.Models.Accounting;
using ERP_System.Models.Accounting.Reports;
using ERP_System.Models.Materials;
using ERP_System.Models.Trade;
using ERP_System.Models.Trade.Reports.PurchasesBillsReport;
using ERP_System.Models.Trade.Reports.SalesBillsReport;
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
            services.AddScoped<IApplicationRepository<ItemCategory>, ItemCategory_Repo>();
            services.AddScoped<IApplicationRepository<Item>, Item_Repo>();
            services.AddScoped<IApplicationRepository<ItemCategorySpec>, ItemCategorySpec_Repo>();
            //---------------
            services.AddScoped<IApplicationRepository<Currency>, Currency_Repo>();
            services.AddScoped<IApplicationRepository<MoneyAccount>, MoneyAccount_Repo>();
            services.AddScoped<IReportByDateTypeRepository<MoneyAccountOperation, MoneyAccount_DayReport,
                MoneyAccount_MonthReport, MoneyAccount_YearReport
            , MoneyAccount_YearRangeReport>, MoneyAccount_Repo>();
            services.AddScoped<IApplicationRepository<PayIN>, PayIN_Repo>();
            services.AddScoped<IApplicationRepository<PayOUT>, PayOUT_Repo>();
            services.AddScoped<IApplicationRepository<ExchangeOPR>, ExchangeOPR_Repo>();
            services.AddScoped<IApplicationRepository<MoneyTransFormOPR>, MoneyTransFormOPR_Repo>();
            //---------------
            services.AddScoped<IApplicationRepository<SalesBill>, SalesBill_Repo>();
            services.AddScoped<IApplicationRepository<PurchasesBill>, PurchasesBill_Repo>();
            services.AddScoped<IApplicationRepository<Dealer>, Dealer_Repo>();
            services.AddScoped<IApplicationRepository<BillAdditionalClause>, BillAdditionalClause_Repo>();
            services.AddScoped<IApplicationRepository<ItemIN>, ItemIN_Repo>();
            services.AddScoped<IApplicationRepository_Set_Unset<ItemINSellPrice>, ItemINSellPrice_Repo>();
            services.AddScoped<IApplicationRepository<ItemOUT>, ItemOUT_Repo>();
            services.AddScoped<IApplicationRepository<RavageOPR>, RavageOPR_Repo>();
            services.AddScoped<IApplicationRepository<SellType>, SellType_Repo>();
            services.AddScoped<IApplicationRepository<TradeState>, TradeState_Repo>();
            services.AddScoped<IReportByDateTypeRepository<SalesBill, SalesBillsReport_DayReport,
                SalesBillsReport_MonthReport , SalesBillsReport_YearReport,
                SalesBillsReport_YearRangeReport>, SalesBill_Repo>();
            services.AddScoped<IReportByDateTypeRepository<PurchasesBill,PurchasesBillsReport_DayReport, 
                PurchasesBillsReport_MonthReport, PurchasesBillsReport_YearReport,
                PurchasesBillsReport_YearRangeReport>, PurchasesBill_Repo>();

            return services;

            

        }
    }
}
