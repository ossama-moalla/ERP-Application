using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.Migrations
{
    public partial class App_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounting_Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ExchangeRate = table.Column<double>(type: "float", nullable: false),
                    Disable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting_Currency", x => x.Id);
                    table.CheckConstraint("Currency_Exchange Rate Must Be Greater Than Zero", "[ExchangeRate]>0");
                });

            migrationBuilder.CreateTable(
                name: "Accounting_MoneyAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting_MoneyAccount", x => x.Id);
                });

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
                name: "Materials_ItemCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    parentID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    defaultConsumeUnit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ItemCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCategory_Materials_ItemCategory_parentID",
                        column: x => x.parentID,
                        principalTable: "Materials_ItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounting_ExchangeOPR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoneyAccountId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceCurrencyId = table.Column<int>(type: "int", nullable: false),
                    SourceExchangeRate = table.Column<double>(type: "float", nullable: false),
                    OutMoneyValue = table.Column<double>(type: "float", nullable: false),
                    TargetCurrencyId = table.Column<int>(type: "int", nullable: false),
                    TargetExchangeRate = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting_ExchangeOPR", x => x.Id);
                    table.CheckConstraint("ExchangeOPR_Source Currency And Target Currency Must Not Be Same", "[SourceCurrencyId]<>[TargetCurrencyId]");
                    table.CheckConstraint("ExchangeOPR_Exchange Rate Must Be Greater Than Zero", "[SourceExchangeRate]>0 and [TargetExchangeRate]>0");
                    table.ForeignKey(
                        name: "FK_Accounting_ExchangeOPR_Accounting_Currency_SourceCurrencyId",
                        column: x => x.SourceCurrencyId,
                        principalTable: "Accounting_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounting_ExchangeOPR_Accounting_Currency_TargetCurrencyId",
                        column: x => x.TargetCurrencyId,
                        principalTable: "Accounting_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounting_ExchangeOPR_Accounting_MoneyAccount_MoneyAccountId",
                        column: x => x.MoneyAccountId,
                        principalTable: "Accounting_MoneyAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounting_MoneyTransFormOPR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceMoneyAccountId = table.Column<int>(type: "int", nullable: false),
                    TargetMoneyAccountId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    ExchangeRate = table.Column<double>(type: "float", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting_MoneyTransFormOPR", x => x.Id);
                    table.CheckConstraint("MoneyTransFormOPR _Source MoneyAccount And Target MoneyAccount Must Not Be Same", "[SourceMoneyAccountId]<>[TargetMoneyAccountId]");
                    table.CheckConstraint("MoneyTransFormOPR_Exchange Rate Must Be Greater Than Zero", "[ExchangeRate]>0");
                    table.CheckConstraint("MoneyTransFormOPR_Value  Must Be Greater Than Zero", "[Value]>0");
                    table.ForeignKey(
                        name: "FK_Accounting_MoneyTransFormOPR_Accounting_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Accounting_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounting_MoneyTransFormOPR_Accounting_MoneyAccount_SourceMoneyAccountId",
                        column: x => x.SourceMoneyAccountId,
                        principalTable: "Accounting_MoneyAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounting_MoneyTransFormOPR_Accounting_MoneyAccount_TargetMoneyAccountId",
                        column: x => x.TargetMoneyAccountId,
                        principalTable: "Accounting_MoneyAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounting_PayIN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoneyAccountId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: true),
                    OperationType = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    ExchangeRate = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting_PayIN", x => x.Id);
                    table.CheckConstraint("PayIN_Exchange Rate Must Be Greater Than Zero", "[ExchangeRate]>0 ");
                    table.CheckConstraint("PayIN_Value Must Be Greater Than Zero", "[Value]>0 ");
                    table.ForeignKey(
                        name: "FK_Accounting_PayIN_Accounting_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Accounting_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounting_PayIN_Accounting_MoneyAccount_MoneyAccountId",
                        column: x => x.MoneyAccountId,
                        principalTable: "Accounting_MoneyAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounting_PayOUT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoneyAccountId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: true),
                    OperationType = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    ExchangeRate = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting_PayOUT", x => x.Id);
                    table.CheckConstraint("PayOUT_Exchange Rate Must Be Greater Than Zero", "[ExchangeRate]>0 ");
                    table.CheckConstraint("PayOUT_Value Must Be Greater Than Zero", "[Value]>0 ");
                    table.ForeignKey(
                        name: "FK_Accounting_PayOUT_Accounting_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Accounting_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounting_PayOUT_Accounting_MoneyAccount_MoneyAccountId",
                        column: x => x.MoneyAccountId,
                        principalTable: "Accounting_MoneyAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MarketCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsumeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Item_Materials_ItemCategory_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalTable: "Materials_ItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials_ItemCategorySpec",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isRestricted = table.Column<bool>(type: "bit", nullable: false),
                    index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ItemCategorySpec", x => x.id);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCategorySpec_Materials_ItemCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Materials_ItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Currency Name Must Be Unique",
                table: "Accounting_Currency",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "Currency Symbol Must Be Unique",
                table: "Accounting_Currency",
                column: "Symbol",
                unique: true,
                filter: "[Symbol] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_ExchangeOPR_MoneyAccountId",
                table: "Accounting_ExchangeOPR",
                column: "MoneyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_ExchangeOPR_SourceCurrencyId",
                table: "Accounting_ExchangeOPR",
                column: "SourceCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_ExchangeOPR_TargetCurrencyId",
                table: "Accounting_ExchangeOPR",
                column: "TargetCurrencyId");

            migrationBuilder.CreateIndex(
                name: "Money Account Name Must Be Unique",
                table: "Accounting_MoneyAccount",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_MoneyTransFormOPR_CurrencyId",
                table: "Accounting_MoneyTransFormOPR",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_MoneyTransFormOPR_SourceMoneyAccountId",
                table: "Accounting_MoneyTransFormOPR",
                column: "SourceMoneyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_MoneyTransFormOPR_TargetMoneyAccountId",
                table: "Accounting_MoneyTransFormOPR",
                column: "TargetMoneyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_PayIN_CurrencyId",
                table: "Accounting_PayIN",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_PayIN_MoneyAccountId",
                table: "Accounting_PayIN",
                column: "MoneyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_PayOUT_CurrencyId",
                table: "Accounting_PayOUT",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounting_PayOUT_MoneyAccountId",
                table: "Accounting_PayOUT",
                column: "MoneyAccountId");

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
                name: "Item Name And Company must be unique in category",
                table: "Materials_Item",
                columns: new[] { "ItemCategoryId", "Name", "Company" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_ItemCategory_parentID_name",
                table: "Materials_ItemCategory",
                columns: new[] { "parentID", "name" },
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounting_ExchangeOPR");

            migrationBuilder.DropTable(
                name: "Accounting_MoneyTransFormOPR");

            migrationBuilder.DropTable(
                name: "Accounting_PayIN");

            migrationBuilder.DropTable(
                name: "Accounting_PayOUT");

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
                name: "Materials_Item");

            migrationBuilder.DropTable(
                name: "Materials_ItemCategorySpec");

            migrationBuilder.DropTable(
                name: "Accounting_Currency");

            migrationBuilder.DropTable(
                name: "Accounting_MoneyAccount");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Materials_ItemCategory");
        }
    }
}
