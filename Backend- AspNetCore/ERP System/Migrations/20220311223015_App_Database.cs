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
                name: "StorePlace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorePlace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trade_BillAdditionalClause",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    OperationType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade_BillAdditionalClause", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trade_Dealer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade_Dealer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trade_RavageOPR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade_RavageOPR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trade_SellType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade_SellType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trade_TradeState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade_TradeState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounting_ExchangeOPR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoneyAccountId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    SourceCurrencyId = table.Column<int>(type: "int", nullable: true),
                    SourceExchangeRate = table.Column<double>(type: "float", nullable: false),
                    OutMoneyValue = table.Column<double>(type: "float", nullable: false),
                    TargetCurrencyId = table.Column<int>(type: "int", nullable: true),
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
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    SourceMoneyAccountId = table.Column<int>(type: "int", nullable: false),
                    TargetMoneyAccountId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
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
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
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
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsRestricted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials_ItemCategorySpec", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_ItemCategorySpec_Materials_ItemCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Materials_ItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trade_PurchasesBill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    SellTypeId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    ExchangeRate = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade_PurchasesBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trade_PurchasesBill_Accounting_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Accounting_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trade_PurchasesBill_Trade_Dealer_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Trade_Dealer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trade_PurchasesBill_Trade_SellType_SellTypeId",
                        column: x => x.SellTypeId,
                        principalTable: "Trade_SellType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trade_SalesBill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    SellTypeId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    ExchangeRate = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade_SalesBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trade_SalesBill_Accounting_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Accounting_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trade_SalesBill_Trade_Dealer_DealerId",
                        column: x => x.DealerId,
                        principalTable: "Trade_Dealer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trade_SalesBill_Trade_SellType_SellTypeId",
                        column: x => x.SellTypeId,
                        principalTable: "Trade_SellType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumeUnit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Item_Id = table.Column<int>(type: "int", nullable: true),
                    Factor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumeUnit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConsumeUnit_Materials_Item_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Materials_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trade_ItemIN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    OperationType = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    TradeStateId = table.Column<int>(type: "int", nullable: false),
                    ConsumeUnitId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    SingleCost = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade_ItemIN", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trade_ItemIN_ConsumeUnit_ConsumeUnitId",
                        column: x => x.ConsumeUnitId,
                        principalTable: "ConsumeUnit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trade_ItemIN_Materials_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Materials_Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trade_ItemIN_Trade_TradeState_TradeStateId",
                        column: x => x.TradeStateId,
                        principalTable: "Trade_TradeState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trade_ItemINSellPrice",
                columns: table => new
                {
                    ItemINId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemINId1 = table.Column<int>(type: "int", nullable: false),
                    ConsumeUnitId = table.Column<int>(type: "int", nullable: true),
                    SellTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade_ItemINSellPrice", x => x.ItemINId);
                    table.ForeignKey(
                        name: "FK_Trade_ItemINSellPrice_ConsumeUnit_ConsumeUnitId",
                        column: x => x.ConsumeUnitId,
                        principalTable: "ConsumeUnit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trade_ItemINSellPrice_Trade_ItemIN_ItemINId1",
                        column: x => x.ItemINId1,
                        principalTable: "Trade_ItemIN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trade_ItemINSellPrice_Trade_SellType_SellTypeId",
                        column: x => x.SellTypeId,
                        principalTable: "Trade_SellType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trade_ItemOUT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    OperationType = table.Column<int>(type: "int", nullable: false),
                    ItemINId = table.Column<int>(type: "int", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: true),
                    ConsumeUnitId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    SingleOUTValue = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade_ItemOUT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trade_ItemOUT_ConsumeUnit_ConsumeUnitId",
                        column: x => x.ConsumeUnitId,
                        principalTable: "ConsumeUnit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trade_ItemOUT_StorePlace_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "StorePlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trade_ItemOUT_Trade_ItemIN_ItemINId",
                        column: x => x.ItemINId,
                        principalTable: "Trade_ItemIN",
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
                name: "IX_ConsumeUnit_Item_Id",
                table: "ConsumeUnit",
                column: "Item_Id");

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
                columns: new[] { "CategoryID", "Index" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unique name In Category Spec's",
                table: "Materials_ItemCategorySpec",
                columns: new[] { "CategoryID", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trade_ItemIN_ConsumeUnitId",
                table: "Trade_ItemIN",
                column: "ConsumeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_ItemIN_ItemId",
                table: "Trade_ItemIN",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_ItemIN_TradeStateId",
                table: "Trade_ItemIN",
                column: "TradeStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_ItemINSellPrice_ConsumeUnitId",
                table: "Trade_ItemINSellPrice",
                column: "ConsumeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_ItemINSellPrice_ItemINId1",
                table: "Trade_ItemINSellPrice",
                column: "ItemINId1");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_ItemINSellPrice_SellTypeId",
                table: "Trade_ItemINSellPrice",
                column: "SellTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_ItemOUT_ConsumeUnitId",
                table: "Trade_ItemOUT",
                column: "ConsumeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_ItemOUT_ItemINId",
                table: "Trade_ItemOUT",
                column: "ItemINId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_ItemOUT_PlaceId",
                table: "Trade_ItemOUT",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_PurchasesBill_CurrencyId",
                table: "Trade_PurchasesBill",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_PurchasesBill_DealerId",
                table: "Trade_PurchasesBill",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_PurchasesBill_SellTypeId",
                table: "Trade_PurchasesBill",
                column: "SellTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_SalesBill_CurrencyId",
                table: "Trade_SalesBill",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_SalesBill_DealerId",
                table: "Trade_SalesBill",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_SalesBill_SellTypeId",
                table: "Trade_SalesBill",
                column: "SellTypeId");
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
                name: "Materials_ItemCategorySpec");

            migrationBuilder.DropTable(
                name: "Trade_BillAdditionalClause");

            migrationBuilder.DropTable(
                name: "Trade_ItemINSellPrice");

            migrationBuilder.DropTable(
                name: "Trade_ItemOUT");

            migrationBuilder.DropTable(
                name: "Trade_PurchasesBill");

            migrationBuilder.DropTable(
                name: "Trade_RavageOPR");

            migrationBuilder.DropTable(
                name: "Trade_SalesBill");

            migrationBuilder.DropTable(
                name: "Accounting_MoneyAccount");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "StorePlace");

            migrationBuilder.DropTable(
                name: "Trade_ItemIN");

            migrationBuilder.DropTable(
                name: "Accounting_Currency");

            migrationBuilder.DropTable(
                name: "Trade_Dealer");

            migrationBuilder.DropTable(
                name: "Trade_SellType");

            migrationBuilder.DropTable(
                name: "ConsumeUnit");

            migrationBuilder.DropTable(
                name: "Trade_TradeState");

            migrationBuilder.DropTable(
                name: "Materials_Item");

            migrationBuilder.DropTable(
                name: "Materials_ItemCategory");
        }
    }
}
