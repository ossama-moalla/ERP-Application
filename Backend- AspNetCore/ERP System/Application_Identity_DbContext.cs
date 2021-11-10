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

        }
        public DbSet<ItemCategory> Materials_ItemCategory_Table { get;set;}
        public DbSet<Item> Materials_Item_Table { get; set; }
        public DbSet<ConsumeUnit> Materials_ConsumeUnit_Table { get; set; }
        public DbSet<Item_Equivalence_Relation> Materials_Item_Equivalence_Relation_Table { get; set; }
        public DbSet<ItemCommonSellPrice> Materials_ItemCommonSellPrice_Table { get; set; }
        public DbSet<ItemFile> Materials_ItemFile_Table { get; set; }
        public DbSet<ItemRelation> Materials_ItemRelation_Table { get; set; }
        public DbSet<ItemSpec> Materials_ItemSpec_Table { get; set; }
        public DbSet<ItemSpec_Value> Materials_ItemSpec_Value_Table { get; set; }

        public DbSet<ItemSpec_Restrict> Materials_ItemSpec_Restrict_Table { get; set; }
        public DbSet<ItemSpec_Restrict_Options> Materials_ItemSpec_Restrict_Options_Table { get; set; }
        public DbSet<ItemSpec_Restrict_Value> Materials_ItemSpec_Restrict_Value_Table { get; set; }
        //public DbSet<Equivalence_Group> Materials_Equivalence_Group_Table { get; set; }


    }
}
