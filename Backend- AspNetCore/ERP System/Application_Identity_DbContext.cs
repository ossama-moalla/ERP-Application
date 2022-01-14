using ERP_System.Models.Accounting;
using ERP_System.Models.HR.UsersAccounts;
using ERP_System.Models.Materials;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_System
{
    public class Application_Identity_DbContext : IdentityDbContext<Employee_UserAccount>
    {
        public Application_Identity_DbContext(DbContextOptions<Application_Identity_DbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ItemCategory>(p =>
            {
                p.HasOne<ItemCategory>()
                .WithMany()
                .HasForeignKey(e => e.parentID);
                p.HasIndex(e => new { e.parentID, e.name }).IsUnique(true).HasFilter(null);
            });
            builder.Entity<ExchangeOPR>(p =>
            {
                p.HasOne(c => c.SourceCurrency).WithMany().OnDelete(DeleteBehavior.Restrict);
                p.HasOne(c => c.TargetCurrency).WithMany().OnDelete(DeleteBehavior.Restrict);
                p.HasCheckConstraint("ExchangeOPR_Source Currency And Target Currency Must Not Be Same",
               "[SourceCurrencyId]<>[TargetCurrencyId]");
                p.HasCheckConstraint("ExchangeOPR_Exchange Rate Must Be Greater Than Zero",
               "[SourceExchangeRate]>0 and [TargetExchangeRate]>0");
            }
            );
            builder.Entity<Currency>(p =>
                p.HasCheckConstraint("Currency_Exchange Rate Must Be Greater Than Zero",
                "[ExchangeRate]>0")
            );
            builder.Entity<PayIN>(p =>
                p.HasCheckConstraint("PayIN_Exchange Rate Must Be Greater Than Zero",
                "[ExchangeRate]>0 ")
                .HasCheckConstraint("PayIN_Value Must Be Greater Than Zero",
                "[Value]>0 ")
            );
            builder.Entity<PayOUT>(p =>
                p.HasCheckConstraint("PayOUT_Exchange Rate Must Be Greater Than Zero",
                "[ExchangeRate]>0 ")
                .HasCheckConstraint("PayOUT_Value Must Be Greater Than Zero",
                "[Value]>0 ")
            );
            builder.Entity<MoneyTransFormOPR>(p =>
            {
                p.HasOne(x => x.SourceMoneyAccount).WithMany().OnDelete(DeleteBehavior.Restrict);
                p.HasOne(x => x.TargetMoneyAccount).WithMany().OnDelete(DeleteBehavior.Restrict);
                p.HasCheckConstraint("MoneyTransFormOPR _Source MoneyAccount And Target MoneyAccount Must Not Be Same",
               "[SourceMoneyAccountId]<>[TargetMoneyAccountId]")
               .HasCheckConstraint("MoneyTransFormOPR_Exchange Rate Must Be Greater Than Zero",
               "[ExchangeRate]>0")
               .HasCheckConstraint("MoneyTransFormOPR_Value  Must Be Greater Than Zero",
               "[Value]>0");
            }
            );
        }
        public DbSet<ItemCategory> Materials_ItemCategory { get;set;}
        public DbSet<Item> Materials_Item { get; set; }
        public DbSet<ItemCategorySpec> Materials_ItemCategorySpec { get; set; }

        //public DbSet<ConsumeUnit> Materials_ConsumeUnit { get; set; }
        // public DbSet<Item_Equivalence_Relation> Materials_Item_Equivalence_Relation { get; set; }
        //public DbSet<ItemCommonSellPrice> Materials_ItemCommonSellPrice { get; set; }
        //public DbSet<ItemFile> Materials_ItemFile { get; set; }
        // public DbSet<ItemRelation> Materials_ItemRelation { get; set; }
        //public DbSet<ItemCategorySpec_Options> Materials_ItemCategorySpec_Restrict_Options { get; set; }
        //public DbSet<ItemCategorySpec_Item_Value> Materials_ItemCategorySpec_Item_Value { get; set; }
        //public DbSet<ItemCategorySpec_Restrict_Item_Value> Materials_ItemCategorySpec_Restrict_Item_Value { get; set; }

        //------------------
        public DbSet<Currency> Accounting_Currency { get; set; }
        public DbSet<PayIN> Accounting_PayIN { get; set; }
        public DbSet<PayOUT> Accounting_PayOUT { get; set; }
        public DbSet<ExchangeOPR> Accounting_ExchangeOPR { get; set; }
        public DbSet<MoneyTransFormOPR> Accounting_MoneyTransFormOPR { get; set; }

    }
}
