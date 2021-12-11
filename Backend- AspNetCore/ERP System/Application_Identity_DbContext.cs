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
                .HasForeignKey(p => p.parentID);
                p.HasIndex(e => new { e.parentID, e.Name }).IsUnique(true);
            });

            builder.Entity<ItemCategorySpec>(p =>
            {
                p.HasIndex(e => new { e.CategoryID, e.name }).IsUnique(true);
                p.HasIndex(e => new { e.CategoryID, e.index }).IsUnique(true);
            });
            //builder.Entity<ItemCategory>()
            //    .HasOne<ItemCategory>()
            //    .WithMany()
            //    .HasForeignKey(p => p.ParentID);

           // builder.Entity<ItemCategory>()
           //.HasIndex(p => new { p.ParentID, p.Name })
           //.IsUnique(true);

            //builder.Entity<ItemCategorySpec>()
            //.HasIndex(p => new { p.CategoryID, p.name })
            //.IsUnique(true);

        }
        public DbSet<ItemCategory> Materials_ItemCategory { get;set;}
        public DbSet<Item> Materials_Item { get; set; }
        public DbSet<ConsumeUnit> Materials_ConsumeUnit { get; set; }
        public DbSet<Item_Equivalence_Relation> Materials_Item_Equivalence_Relation { get; set; }
        public DbSet<ItemCommonSellPrice> Materials_ItemCommonSellPrice { get; set; }
        public DbSet<ItemFile> Materials_ItemFile { get; set; }
        public DbSet<ItemRelation> Materials_ItemRelation { get; set; }
        public DbSet<ItemCategorySpec> Materials_ItemCategorySpec { get; set; }
        public DbSet<ItemCategorySpec_Restrict> Materials_ItemCategorySpec_Restrict { get; set; }
        public DbSet<ItemCategorySpec_Restrict_Options> Materials_ItemCategorySpec_Restrict_Options { get; set; }
        public DbSet<ItemCategorySpec_Item_Value> Materials_ItemCategorySpec_Item_Value { get; set; }
        public DbSet<ItemCategorySpec_Restrict_Item_Value> Materials_ItemCategorySpec_Restrict_Item_Value { get; set; }
        //public DbSet<Equivalence_Group> Materials_Equivalence_Group { get; set; }


    }
}
