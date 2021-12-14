using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.Migrations
{
    public partial class App_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equivalence_Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equivalence_Group", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    parentID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    defaultConsumeUnit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ItemCategory", x => x.id);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCategory_Materials_ItemCategory_parentID",
                        column: x => x.parentID,
                        principalTable: "Materials_ItemCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellType",
                columns: table => new
                {
                    SellTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellType", x => x.SellTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TradeState",
                columns: table => new
                {
                    TradeStateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeStateName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeState", x => x.TradeStateID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials_Item",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoryid = table.Column<int>(type: "int", nullable: true),
                    MarketCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefaultConsumeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_Item", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Materials_Item_Materials_ItemCategory_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "Materials_ItemCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemCategorySpec",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ItemCategorySpec", x => x.id);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCategorySpec_Materials_ItemCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Materials_ItemCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemCategorySpec_Restrict",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ItemCategorySpec_Restrict", x => x.id);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCategorySpec_Restrict_Materials_ItemCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Materials_ItemCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ConsumeUnit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item_ID = table.Column<int>(type: "int", nullable: true),
                    Factor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ConsumeUnit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Materials_ConsumeUnit_Materials_Item_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "Materials_Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_Item_Equivalence_Relation",
                columns: table => new
                {
                    _Equivalence_GroupGroupID = table.Column<int>(type: "int", nullable: true),
                    _ItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Materials_Item_Equivalence_Relation_Equivalence_Group__Equivalence_GroupGroupID",
                        column: x => x._Equivalence_GroupGroupID,
                        principalTable: "Equivalence_Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_Item_Equivalence_Relation_Materials_Item__ItemID",
                        column: x => x._ItemID,
                        principalTable: "Materials_Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemFile",
                columns: table => new
                {
                    FileID = table.Column<long>(type: "bigint", nullable: false),
                    Item_ID = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ItemFile", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_Materials_ItemFile_Materials_Item_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "Materials_Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemRelation",
                columns: table => new
                {
                    Item_ID = table.Column<int>(type: "int", nullable: true),
                    AnotherItemID = table.Column<int>(type: "int", nullable: true),
                    Relation_ = table.Column<int>(type: "int", nullable: false),
                    Inherit = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Materials_ItemRelation_Materials_Item_AnotherItemID",
                        column: x => x.AnotherItemID,
                        principalTable: "Materials_Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemRelation_Materials_Item_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "Materials_Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemCategorySpec_Item_Value",
                columns: table => new
                {
                    Item_ID = table.Column<int>(type: "int", nullable: true),
                    ItemSpec_id = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Materials_ItemCategorySpec_Item_Value_Materials_Item_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "Materials_Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCategorySpec_Item_Value_Materials_ItemCategorySpec_ItemSpec_id",
                        column: x => x.ItemSpec_id,
                        principalTable: "Materials_ItemCategorySpec",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemCategorySpec_Restrict_Options",
                columns: table => new
                {
                    OptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemSpecRestrict_id = table.Column<int>(type: "int", nullable: true),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ItemCategorySpec_Restrict_Options", x => x.OptionID);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCategorySpec_Restrict_Options_Materials_ItemCategorySpec_Restrict_ItemSpecRestrict_id",
                        column: x => x.ItemSpecRestrict_id,
                        principalTable: "Materials_ItemCategorySpec_Restrict",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemCommonSellPrice",
                columns: table => new
                {
                    Item_ID = table.Column<int>(type: "int", nullable: true),
                    _TradeStateTradeStateID = table.Column<int>(type: "int", nullable: true),
                    ConsumeUnit_ID = table.Column<int>(type: "int", nullable: true),
                    SellType_SellTypeID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Materials_ItemCommonSellPrice_Materials_ConsumeUnit_ConsumeUnit_ID",
                        column: x => x.ConsumeUnit_ID,
                        principalTable: "Materials_ConsumeUnit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCommonSellPrice_Materials_Item_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "Materials_Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCommonSellPrice_SellType_SellType_SellTypeID",
                        column: x => x.SellType_SellTypeID,
                        principalTable: "SellType",
                        principalColumn: "SellTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCommonSellPrice_TradeState__TradeStateTradeStateID",
                        column: x => x._TradeStateTradeStateID,
                        principalTable: "TradeState",
                        principalColumn: "TradeStateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemCategorySpec_Restrict_Item_Value",
                columns: table => new
                {
                    itemID = table.Column<int>(type: "int", nullable: true),
                    ItemSpecRestrict_id = table.Column<int>(type: "int", nullable: true),
                    ItemSpec_Restrict_Options_OptionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Materials_ItemCategorySpec_Restrict_Item_Value_Materials_Item_itemID",
                        column: x => x.itemID,
                        principalTable: "Materials_Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCategorySpec_Restrict_Item_Value_Materials_ItemCategorySpec_Restrict_ItemSpecRestrict_id",
                        column: x => x.ItemSpecRestrict_id,
                        principalTable: "Materials_ItemCategorySpec_Restrict",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCategorySpec_Restrict_Item_Value_Materials_ItemCategorySpec_Restrict_Options_ItemSpec_Restrict_Options_OptionID",
                        column: x => x.ItemSpec_Restrict_Options_OptionID,
                        principalTable: "Materials_ItemCategorySpec_Restrict_Options",
                        principalColumn: "OptionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ConsumeUnit_Item_ID",
                table: "Materials_ConsumeUnit",
                column: "Item_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Item_Categoryid",
                table: "Materials_Item",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Item_Equivalence_Relation__Equivalence_GroupGroupID",
                table: "Materials_Item_Equivalence_Relation",
                column: "_Equivalence_GroupGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Item_Equivalence_Relation__ItemID",
                table: "Materials_Item_Equivalence_Relation",
                column: "_ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCategory_parentID_Name",
                table: "Materials_ItemCategory",
                columns: new[] { "parentID", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unique Index In Category Spec's",
                table: "Materials_ItemCategorySpec",
                columns: new[] { "CategoryID", "index" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unique name In Category Spec's",
                table: "Materials_ItemCategorySpec",
                columns: new[] { "CategoryID", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCategorySpec_Item_Value_Item_ID",
                table: "Materials_ItemCategorySpec_Item_Value",
                column: "Item_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCategorySpec_Item_Value_ItemSpec_id",
                table: "Materials_ItemCategorySpec_Item_Value",
                column: "ItemSpec_id");

            migrationBuilder.CreateIndex(
                name: "Unique Index In Category Spec's1",
                table: "Materials_ItemCategorySpec_Restrict",
                columns: new[] { "CategoryID", "index" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unique name In Category Spec's1",
                table: "Materials_ItemCategorySpec_Restrict",
                columns: new[] { "CategoryID", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCategorySpec_Restrict_Item_Value_itemID",
                table: "Materials_ItemCategorySpec_Restrict_Item_Value",
                column: "itemID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCategorySpec_Restrict_Item_Value_ItemSpec_Restrict_Options_OptionID",
                table: "Materials_ItemCategorySpec_Restrict_Item_Value",
                column: "ItemSpec_Restrict_Options_OptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCategorySpec_Restrict_Item_Value_ItemSpecRestrict_id",
                table: "Materials_ItemCategorySpec_Restrict_Item_Value",
                column: "ItemSpecRestrict_id");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCategorySpec_Restrict_Options_ItemSpecRestrict_id",
                table: "Materials_ItemCategorySpec_Restrict_Options",
                column: "ItemSpecRestrict_id");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCommonSellPrice__TradeStateTradeStateID",
                table: "Materials_ItemCommonSellPrice",
                column: "_TradeStateTradeStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCommonSellPrice_ConsumeUnit_ID",
                table: "Materials_ItemCommonSellPrice",
                column: "ConsumeUnit_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCommonSellPrice_Item_ID",
                table: "Materials_ItemCommonSellPrice",
                column: "Item_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCommonSellPrice_SellType_SellTypeID",
                table: "Materials_ItemCommonSellPrice",
                column: "SellType_SellTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemFile_Item_ID",
                table: "Materials_ItemFile",
                column: "Item_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemRelation_AnotherItemID",
                table: "Materials_ItemRelation",
                column: "AnotherItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemRelation_Item_ID",
                table: "Materials_ItemRelation",
                column: "Item_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Materials_Item_Equivalence_Relation");

            migrationBuilder.DropTable(
                name: "Materials_ItemCategorySpec_Item_Value");

            migrationBuilder.DropTable(
                name: "Materials_ItemCategorySpec_Restrict_Item_Value");

            migrationBuilder.DropTable(
                name: "Materials_ItemCommonSellPrice");

            migrationBuilder.DropTable(
                name: "Materials_ItemFile");

            migrationBuilder.DropTable(
                name: "Materials_ItemRelation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Equivalence_Group");

            migrationBuilder.DropTable(
                name: "Materials_ItemCategorySpec");

            migrationBuilder.DropTable(
                name: "Materials_ItemCategorySpec_Restrict_Options");

            migrationBuilder.DropTable(
                name: "Materials_ConsumeUnit");

            migrationBuilder.DropTable(
                name: "SellType");

            migrationBuilder.DropTable(
                name: "TradeState");

            migrationBuilder.DropTable(
                name: "Materials_ItemCategorySpec_Restrict");

            migrationBuilder.DropTable(
                name: "Materials_Item");

            migrationBuilder.DropTable(
                name: "Materials_ItemCategory");
        }
    }
}
