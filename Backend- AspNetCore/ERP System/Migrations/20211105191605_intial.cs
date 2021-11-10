using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.Migrations
{
    public partial class intial : Migration
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
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    adddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Materials_ItemCategory_Table",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentID = table.Column<long>(type: "bigint", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefaultConsumeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ItemCategory_Table", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SellType",
                columns: table => new
                {
                    SellTypeID = table.Column<long>(type: "bigint", nullable: false),
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
                    TradeStateID = table.Column<long>(type: "bigint", nullable: false),
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
                name: "Materials_Item_Table",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeID = table.Column<long>(type: "bigint", nullable: true),
                    MarketCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefaultConsumeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_Item_Table", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Materials_Item_Table_Materials_ItemCategory_Table_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Materials_ItemCategory_Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemSpec_Restrict_Table",
                columns: table => new
                {
                    SpecID = table.Column<long>(type: "bigint", nullable: false),
                    TypeID = table.Column<long>(type: "bigint", nullable: true),
                    SpecName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecIndex = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ItemSpec_Restrict_Table", x => x.SpecID);
                    table.ForeignKey(
                        name: "FK_Materials_ItemSpec_Restrict_Table_Materials_ItemCategory_Table_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Materials_ItemCategory_Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemSpec_Table",
                columns: table => new
                {
                    SpecID = table.Column<long>(type: "bigint", nullable: false),
                    TypeID = table.Column<long>(type: "bigint", nullable: true),
                    SpecName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecIndex = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ItemSpec_Table", x => x.SpecID);
                    table.ForeignKey(
                        name: "FK_Materials_ItemSpec_Table_Materials_ItemCategory_Table_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Materials_ItemCategory_Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ConsumeUnit_Table",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item_ID = table.Column<int>(type: "int", nullable: true),
                    Factor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ConsumeUnit_Table", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Materials_ConsumeUnit_Table_Materials_Item_Table_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "Materials_Item_Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_Item_Equivalence_Relation_Table",
                columns: table => new
                {
                    _Equivalence_GroupGroupID = table.Column<int>(type: "int", nullable: true),
                    _ItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Materials_Item_Equivalence_Relation_Table_Equivalence_Group__Equivalence_GroupGroupID",
                        column: x => x._Equivalence_GroupGroupID,
                        principalTable: "Equivalence_Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_Item_Equivalence_Relation_Table_Materials_Item_Table__ItemID",
                        column: x => x._ItemID,
                        principalTable: "Materials_Item_Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemFile_Table",
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
                    table.PrimaryKey("PK_Materials_ItemFile_Table", x => x.FileID);
                    table.ForeignKey(
                        name: "FK_Materials_ItemFile_Table_Materials_Item_Table_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "Materials_Item_Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemRelation_Table",
                columns: table => new
                {
                    Item_ID = table.Column<int>(type: "int", nullable: true),
                    AnotherItemID = table.Column<int>(type: "int", nullable: true),
                    Relation_ = table.Column<long>(type: "bigint", nullable: false),
                    Inherit = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Materials_ItemRelation_Table_Materials_Item_Table_AnotherItemID",
                        column: x => x.AnotherItemID,
                        principalTable: "Materials_Item_Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemRelation_Table_Materials_Item_Table_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "Materials_Item_Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemSpec_Restrict_Options_Table",
                columns: table => new
                {
                    OptionID = table.Column<long>(type: "bigint", nullable: false),
                    ItemSpecRestrict_SpecID = table.Column<long>(type: "bigint", nullable: true),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ItemSpec_Restrict_Options_Table", x => x.OptionID);
                    table.ForeignKey(
                        name: "FK_Materials_ItemSpec_Restrict_Options_Table_Materials_ItemSpec_Restrict_Table_ItemSpecRestrict_SpecID",
                        column: x => x.ItemSpecRestrict_SpecID,
                        principalTable: "Materials_ItemSpec_Restrict_Table",
                        principalColumn: "SpecID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemSpec_Value_Table",
                columns: table => new
                {
                    Item_ID = table.Column<int>(type: "int", nullable: true),
                    ItemSpec_SpecID = table.Column<long>(type: "bigint", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Materials_ItemSpec_Value_Table_Materials_Item_Table_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "Materials_Item_Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemSpec_Value_Table_Materials_ItemSpec_Table_ItemSpec_SpecID",
                        column: x => x.ItemSpec_SpecID,
                        principalTable: "Materials_ItemSpec_Table",
                        principalColumn: "SpecID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemCommonSellPrice_Table",
                columns: table => new
                {
                    Item_ID = table.Column<int>(type: "int", nullable: true),
                    _TradeStateTradeStateID = table.Column<long>(type: "bigint", nullable: true),
                    ConsumeUnit_ID = table.Column<long>(type: "bigint", nullable: true),
                    SellType_SellTypeID = table.Column<long>(type: "bigint", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Materials_ItemCommonSellPrice_Table_Materials_ConsumeUnit_Table_ConsumeUnit_ID",
                        column: x => x.ConsumeUnit_ID,
                        principalTable: "Materials_ConsumeUnit_Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCommonSellPrice_Table_Materials_Item_Table_Item_ID",
                        column: x => x.Item_ID,
                        principalTable: "Materials_Item_Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCommonSellPrice_Table_SellType_SellType_SellTypeID",
                        column: x => x.SellType_SellTypeID,
                        principalTable: "SellType",
                        principalColumn: "SellTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCommonSellPrice_Table_TradeState__TradeStateTradeStateID",
                        column: x => x._TradeStateTradeStateID,
                        principalTable: "TradeState",
                        principalColumn: "TradeStateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemSpec_Restrict_Value_Table",
                columns: table => new
                {
                    itemID = table.Column<int>(type: "int", nullable: true),
                    ItemSpecRestrict_SpecID = table.Column<long>(type: "bigint", nullable: true),
                    ItemSpec_Restrict_Options_OptionID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Materials_ItemSpec_Restrict_Value_Table_Materials_Item_Table_itemID",
                        column: x => x.itemID,
                        principalTable: "Materials_Item_Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemSpec_Restrict_Value_Table_Materials_ItemSpec_Restrict_Options_Table_ItemSpec_Restrict_Options_OptionID",
                        column: x => x.ItemSpec_Restrict_Options_OptionID,
                        principalTable: "Materials_ItemSpec_Restrict_Options_Table",
                        principalColumn: "OptionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materials_ItemSpec_Restrict_Value_Table_Materials_ItemSpec_Restrict_Table_ItemSpecRestrict_SpecID",
                        column: x => x.ItemSpecRestrict_SpecID,
                        principalTable: "Materials_ItemSpec_Restrict_Table",
                        principalColumn: "SpecID",
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
                name: "IX_Materials_ConsumeUnit_Table_Item_ID",
                table: "Materials_ConsumeUnit_Table",
                column: "Item_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Item_Equivalence_Relation_Table__Equivalence_GroupGroupID",
                table: "Materials_Item_Equivalence_Relation_Table",
                column: "_Equivalence_GroupGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Item_Equivalence_Relation_Table__ItemID",
                table: "Materials_Item_Equivalence_Relation_Table",
                column: "_ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_Item_Table_TypeID",
                table: "Materials_Item_Table",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCommonSellPrice_Table__TradeStateTradeStateID",
                table: "Materials_ItemCommonSellPrice_Table",
                column: "_TradeStateTradeStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCommonSellPrice_Table_ConsumeUnit_ID",
                table: "Materials_ItemCommonSellPrice_Table",
                column: "ConsumeUnit_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCommonSellPrice_Table_Item_ID",
                table: "Materials_ItemCommonSellPrice_Table",
                column: "Item_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCommonSellPrice_Table_SellType_SellTypeID",
                table: "Materials_ItemCommonSellPrice_Table",
                column: "SellType_SellTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemFile_Table_Item_ID",
                table: "Materials_ItemFile_Table",
                column: "Item_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemRelation_Table_AnotherItemID",
                table: "Materials_ItemRelation_Table",
                column: "AnotherItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemRelation_Table_Item_ID",
                table: "Materials_ItemRelation_Table",
                column: "Item_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemSpec_Restrict_Options_Table_ItemSpecRestrict_SpecID",
                table: "Materials_ItemSpec_Restrict_Options_Table",
                column: "ItemSpecRestrict_SpecID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemSpec_Restrict_Table_TypeID",
                table: "Materials_ItemSpec_Restrict_Table",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemSpec_Restrict_Value_Table_itemID",
                table: "Materials_ItemSpec_Restrict_Value_Table",
                column: "itemID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemSpec_Restrict_Value_Table_ItemSpec_Restrict_Options_OptionID",
                table: "Materials_ItemSpec_Restrict_Value_Table",
                column: "ItemSpec_Restrict_Options_OptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemSpec_Restrict_Value_Table_ItemSpecRestrict_SpecID",
                table: "Materials_ItemSpec_Restrict_Value_Table",
                column: "ItemSpecRestrict_SpecID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemSpec_Table_TypeID",
                table: "Materials_ItemSpec_Table",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemSpec_Value_Table_Item_ID",
                table: "Materials_ItemSpec_Value_Table",
                column: "Item_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemSpec_Value_Table_ItemSpec_SpecID",
                table: "Materials_ItemSpec_Value_Table",
                column: "ItemSpec_SpecID");
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
                name: "Materials_Item_Equivalence_Relation_Table");

            migrationBuilder.DropTable(
                name: "Materials_ItemCommonSellPrice_Table");

            migrationBuilder.DropTable(
                name: "Materials_ItemFile_Table");

            migrationBuilder.DropTable(
                name: "Materials_ItemRelation_Table");

            migrationBuilder.DropTable(
                name: "Materials_ItemSpec_Restrict_Value_Table");

            migrationBuilder.DropTable(
                name: "Materials_ItemSpec_Value_Table");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Equivalence_Group");

            migrationBuilder.DropTable(
                name: "Materials_ConsumeUnit_Table");

            migrationBuilder.DropTable(
                name: "SellType");

            migrationBuilder.DropTable(
                name: "TradeState");

            migrationBuilder.DropTable(
                name: "Materials_ItemSpec_Restrict_Options_Table");

            migrationBuilder.DropTable(
                name: "Materials_ItemSpec_Table");

            migrationBuilder.DropTable(
                name: "Materials_Item_Table");

            migrationBuilder.DropTable(
                name: "Materials_ItemSpec_Restrict_Table");

            migrationBuilder.DropTable(
                name: "Materials_ItemCategory_Table");
        }
    }
}
