using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FADMS.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArmTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    ArmTypeName = table.Column<string>(type: "NVARCHAR(150)", nullable: true),
                    ArmTypeNameBn = table.Column<string>(type: "NVARCHAR(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    actionType = table.Column<string>(maxLength: 250, nullable: true),
                    actionTypeId = table.Column<int>(nullable: true),
                    title = table.Column<string>(maxLength: 250, nullable: true),
                    comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    countryCode = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    countryName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    countryNameBn = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    shortName = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    isActive = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    latitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    longitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    formalName = table.Column<string>(nullable: true),
                    symbolText = table.Column<string>(nullable: true),
                    symbolSign = table.Column<string>(nullable: true),
                    decimalAllow = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dealerAddressCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dealerAddressCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dealerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    dealerTypeName = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dealerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAMSModules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    moduleName = table.Column<string>(nullable: true),
                    moduleNameBN = table.Column<string>(nullable: true),
                    shortOrder = table.Column<int>(nullable: true),
                    isTeam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAMSModules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LicenseSourseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    name = table.Column<string>(type: "NVARCHAR(160)", nullable: true),
                    nameBn = table.Column<string>(type: "NVARCHAR(160)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseSourseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LicenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    name = table.Column<string>(type: "NVARCHAR(160)", nullable: true),
                    nameBn = table.Column<string>(type: "NVARCHAR(160)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    occupationName = table.Column<string>(type: "NVARCHAR(180)", nullable: false),
                    occupationShortName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    shortOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccupationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    name = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    nameBn = table.Column<string>(type: "NVARCHAR(260)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "organizationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    name = table.Column<string>(type: "NVARCHAR(250)", nullable: true),
                    nameBn = table.Column<string>(type: "NVARCHAR(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    paymentTypeName = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    paymentTypeNameBN = table.Column<string>(type: "nvarchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoliticalParties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    name = table.Column<string>(type: "NVARCHAR(260)", nullable: false),
                    nameBn = table.Column<string>(type: "NVARCHAR(260)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticalParties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    productionTypeName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    shortOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "purchaseVatTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    name = table.Column<string>(nullable: true),
                    nameBn = table.Column<string>(nullable: true),
                    isActive = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseVatTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangeMetros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    rangeMetroName = table.Column<string>(type: "NVARCHAR(350)", nullable: true),
                    rangeMetroNameBn = table.Column<string>(type: "NVARCHAR(350)", nullable: true),
                    isActive = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    latitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    longitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangeMetros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    name = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    shortName = table.Column<string>(type: "NVARCHAR(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "salesVatTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    name = table.Column<string>(nullable: true),
                    nameBn = table.Column<string>(nullable: true),
                    isActive = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesVatTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "specificationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    specificationCategoryName = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specificationCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "supplierAddressCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplierAddressCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "supplierTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    supplierTypeName = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplierTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "taxYears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    taxYearName = table.Column<string>(nullable: true),
                    aliasName = table.Column<string>(nullable: true),
                    startDate = table.Column<DateTime>(type: "Date", nullable: true),
                    endDate = table.Column<DateTime>(type: "Date", nullable: true),
                    taxLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    allowablePerquisit = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    unitName = table.Column<string>(maxLength: 250, nullable: true),
                    description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    userTypeNameBn = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    userTypeName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    shortOrder = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vatCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    vatCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vatCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vATSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    vatScheduleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vATSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vatTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    tableName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vatTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    countryId = table.Column<int>(nullable: true),
                    divisionCode = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    divisionName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    divisionNameBn = table.Column<string>(nullable: true),
                    shortName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    isActive = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    latitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    longitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divisions_Countries_countryId",
                        column: x => x.countryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModuleAccessPages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    eRPModuleId = table.Column<int>(nullable: true),
                    applicationRoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleAccessPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleAccessPages_AspNetRoles_applicationRoleId",
                        column: x => x.applicationRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModuleAccessPages_FAMSModules_eRPModuleId",
                        column: x => x.eRPModuleId,
                        principalTable: "FAMSModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Navbars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    nameOptionBangla = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    nameOption = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    controller = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    action = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    area = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    imageClass = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    activeLi = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    status = table.Column<bool>(nullable: false),
                    parentID = table.Column<int>(nullable: false),
                    isParent = table.Column<int>(nullable: true),
                    displayOrder = table.Column<int>(nullable: true),
                    moduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navbars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Navbars_FAMSModules_moduleId",
                        column: x => x.moduleId,
                        principalTable: "FAMSModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DivisionDistricts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    rangeMetroId = table.Column<int>(nullable: true),
                    divisionDistrictName = table.Column<string>(type: "NVARCHAR(350)", nullable: true),
                    divisionDistrictNameBn = table.Column<string>(type: "NVARCHAR(350)", nullable: true),
                    isActive = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    latitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    longitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionDistricts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DivisionDistricts_RangeMetros_rangeMetroId",
                        column: x => x.rangeMetroId,
                        principalTable: "RangeMetros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "itemHsCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    hsCode = table.Column<string>(maxLength: 10, nullable: true),
                    hsDescription = table.Column<string>(maxLength: 450, nullable: true),
                    validFrom = table.Column<DateTime>(nullable: true),
                    taxYearId = table.Column<int>(nullable: true),
                    CD = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    SD = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    VAT = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    AIT = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    AT = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    RD = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    EXD = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TTI = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    vatCategoryId = table.Column<int>(nullable: true),
                    vatTableId = table.Column<int>(nullable: true),
                    vATScheduleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemHsCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_itemHsCodes_taxYears_taxYearId",
                        column: x => x.taxYearId,
                        principalTable: "taxYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_itemHsCodes_vATSchedules_vATScheduleId",
                        column: x => x.vATScheduleId,
                        principalTable: "vATSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_itemHsCodes_vatCategories_vatCategoryId",
                        column: x => x.vatCategoryId,
                        principalTable: "vatCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_itemHsCodes_vatTables_vatTableId",
                        column: x => x.vatTableId,
                        principalTable: "vatTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    divisionId = table.Column<int>(nullable: false),
                    districtCode = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    districtName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    districtNameBn = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    shortName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    isActive = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    latitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    longitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Divisions_divisionId",
                        column: x => x.divisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Thanas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    districtId = table.Column<int>(nullable: true),
                    rangeMetroId = table.Column<int>(nullable: true),
                    thanaCode = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    thanaName = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    thanaNameBn = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    shortName = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    isActive = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                    latitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true),
                    longitude = table.Column<string>(type: "NVARCHAR(120)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thanas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thanas_Districts_districtId",
                        column: x => x.districtId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Thanas_RangeMetros_rangeMetroId",
                        column: x => x.rangeMetroId,
                        principalTable: "RangeMetros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    userTypeId = table.Column<int>(nullable: true),
                    isActive = table.Column<int>(nullable: true),
                    thanaId = table.Column<int>(nullable: true),
                    districtId = table.Column<int>(nullable: true),
                    divisionId = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 120, nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    updatedBy = table.Column<string>(maxLength: 120, nullable: true),
                    bpNumbers = table.Column<string>(nullable: true),
                    ranks = table.Column<string>(nullable: true),
                    PersonName = table.Column<string>(nullable: true),
                    isPassChanges = table.Column<int>(nullable: false),
                    passChangesDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Districts_districtId",
                        column: x => x.districtId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Divisions_divisionId",
                        column: x => x.divisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Thanas_thanaId",
                        column: x => x.thanaId,
                        principalTable: "Thanas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserTypes_userTypeId",
                        column: x => x.userTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "dealers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    dealerName = table.Column<string>(maxLength: 250, nullable: true),
                    dealerNameBn = table.Column<string>(maxLength: 250, nullable: true),
                    LicenseNumber = table.Column<string>(nullable: true),
                    registeredAddress = table.Column<string>(nullable: true),
                    eTinNumber = table.Column<string>(nullable: true),
                    binNumber = table.Column<string>(nullable: true),
                    VATNumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    alternativeEmail = table.Column<string>(nullable: true),
                    mobile = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    dealerTypeId = table.Column<int>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    isAuthorized = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dealers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dealers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dealers_dealerTypes_dealerTypeId",
                        column: x => x.dealerTypeId,
                        principalTable: "dealerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "organizationInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    licenseTypeId = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    OrgCode = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    orgCategory = table.Column<string>(nullable: true),
                    establishDate = table.Column<DateTime>(nullable: true),
                    noOfEmployee = table.Column<int>(nullable: true),
                    noOfVehicle = table.Column<int>(nullable: true),
                    ownerName = table.Column<string>(nullable: true),
                    tid = table.Column<string>(nullable: true),
                    branchName = table.Column<string>(nullable: true),
                    branchManager = table.Column<string>(nullable: true),
                    isBBPermit = table.Column<int>(nullable: true),
                    bbAttachment = table.Column<string>(nullable: true),
                    isHomeRentalAgreement = table.Column<int>(nullable: true),
                    homeRentalAgreementAttachment = table.Column<string>(nullable: true),
                    securityProtected = table.Column<string>(nullable: true),
                    reasonOfFireArms = table.Column<string>(nullable: true),
                    numberOfFireArms = table.Column<int>(nullable: true),
                    beforeArms = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: true),
                    LicenseNo = table.Column<string>(nullable: true),
                    armTypeId = table.Column<int>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizationInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_organizationInfos_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_organizationInfos_ArmTypes_armTypeId",
                        column: x => x.armTypeId,
                        principalTable: "ArmTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dealerAddresss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    addressCategoryId = table.Column<int>(nullable: true),
                    dealerId = table.Column<int>(nullable: true),
                    countryId = table.Column<int>(nullable: true),
                    divisionId = table.Column<int>(nullable: true),
                    districtId = table.Column<int>(nullable: true),
                    thanaId = table.Column<int>(nullable: true),
                    union = table.Column<string>(nullable: true),
                    postOffice = table.Column<string>(nullable: true),
                    postCode = table.Column<string>(nullable: true),
                    blockSector = table.Column<string>(nullable: true),
                    houseVillage = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dealerAddresss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dealerAddresss_dealerAddressCategories_addressCategoryId",
                        column: x => x.addressCategoryId,
                        principalTable: "dealerAddressCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dealerAddresss_Countries_countryId",
                        column: x => x.countryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dealerAddresss_dealers_dealerId",
                        column: x => x.dealerId,
                        principalTable: "dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dealerAddresss_Districts_districtId",
                        column: x => x.districtId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dealerAddresss_Divisions_divisionId",
                        column: x => x.divisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dealerAddresss_Thanas_thanaId",
                        column: x => x.thanaId,
                        principalTable: "Thanas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    parentId = table.Column<int>(nullable: true),
                    isParent = table.Column<int>(nullable: true),
                    unitId = table.Column<int>(nullable: true),
                    itemHsCodeId = table.Column<int>(nullable: true),
                    itemName = table.Column<string>(maxLength: 250, nullable: true),
                    itemCode = table.Column<string>(maxLength: 20, nullable: true),
                    itemDescription = table.Column<string>(nullable: true),
                    accountLedgerId = table.Column<int>(nullable: true),
                    reOrderLevel = table.Column<int>(nullable: true),
                    productionTypeId = table.Column<int>(nullable: true),
                    costingMethod = table.Column<string>(maxLength: 250, nullable: true),
                    reorderQty = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    imageUrl = table.Column<string>(nullable: true),
                    ArmTypeId = table.Column<int>(nullable: true),
                    DealerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_items_ArmTypes_ArmTypeId",
                        column: x => x.ArmTypeId,
                        principalTable: "ArmTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_items_dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_items_itemHsCodes_itemHsCodeId",
                        column: x => x.itemHsCodeId,
                        principalTable: "itemHsCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_items_productionTypes_productionTypeId",
                        column: x => x.productionTypeId,
                        principalTable: "productionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_items_units_unitId",
                        column: x => x.unitId,
                        principalTable: "units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    supplierName = table.Column<string>(maxLength: 250, nullable: true),
                    supplierNameBn = table.Column<string>(maxLength: 250, nullable: true),
                    LicenseNumber = table.Column<string>(nullable: true),
                    registeredAddress = table.Column<string>(nullable: true),
                    eTinNumber = table.Column<string>(nullable: true),
                    binNumber = table.Column<string>(nullable: true),
                    VATNumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    alternativeEmail = table.Column<string>(nullable: true),
                    mobile = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    isAuthorized = table.Column<int>(nullable: true),
                    supplierTypeId = table.Column<int>(nullable: true),
                    DealerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_suppliers_dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_suppliers_supplierTypes_supplierTypeId",
                        column: x => x.supplierTypeId,
                        principalTable: "supplierTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "organizationAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    fileUrl = table.Column<string>(nullable: true),
                    fileName = table.Column<string>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: true),
                    organizationInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizationAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_organizationAttachments_organizationInfos_organizationInfoId",
                        column: x => x.organizationInfoId,
                        principalTable: "organizationInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    politicalPartyId = table.Column<int>(nullable: true),
                    occupationId = table.Column<int>(nullable: true),
                    occupationStatusId = table.Column<int>(nullable: true),
                    religionId = table.Column<int>(nullable: true),
                    organizationInfoId = table.Column<int>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    personalInfoCode = table.Column<string>(maxLength: 50, nullable: true),
                    nationalID = table.Column<string>(maxLength: 100, nullable: true),
                    birthIdentificationNo = table.Column<string>(maxLength: 100, nullable: true),
                    govtID = table.Column<string>(maxLength: 250, nullable: true),
                    gpfNomineeName = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    gpfAcNo = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    nameEnglish = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    nameBangla = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    motherNameBangla = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    motherNameEn = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    fatherNameBangla = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    fatherNameEN = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    nationality = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    disability = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    dateOfBirth = table.Column<DateTime>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    birthPlace = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    maritalStatus = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    tin = table.Column<string>(type: "NVARCHAR(60)", nullable: true),
                    batch = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    bloodGroup = table.Column<string>(type: "NVARCHAR(60)", nullable: true),
                    freedomFighter = table.Column<bool>(nullable: false),
                    freedomFighterNo = table.Column<string>(type: "NVARCHAR(160)", nullable: true),
                    telephoneOffice = table.Column<string>(type: "NVARCHAR(60)", nullable: true),
                    telephoneResidence = table.Column<string>(type: "NVARCHAR(60)", nullable: true),
                    pabx = table.Column<string>(type: "NVARCHAR(60)", nullable: true),
                    emailAddress = table.Column<string>(type: "NVARCHAR(160)", nullable: true),
                    mobileNumberOffice = table.Column<string>(type: "NVARCHAR(60)", nullable: true),
                    mobileNumberPersonal = table.Column<string>(type: "NVARCHAR(60)", nullable: true),
                    education = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    designation = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    nameofservice = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    organization = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    anualincome = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    passportNo = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    spouseName = table.Column<string>(nullable: true),
                    spouseNameBangla = table.Column<string>(nullable: true),
                    ispolitical = table.Column<int>(nullable: true),
                    isfreedomfighter = table.Column<int>(nullable: true),
                    party = table.Column<string>(nullable: true),
                    partydesignaion = table.Column<string>(nullable: true),
                    ocupation = table.Column<string>(nullable: true),
                    motherOccupation = table.Column<string>(nullable: true),
                    fatherOccupation = table.Column<string>(nullable: true),
                    spouseOccupation = table.Column<string>(nullable: true),
                    isgovtjob = table.Column<int>(nullable: true),
                    licenseTypeId = table.Column<int>(nullable: true),
                    age = table.Column<string>(nullable: true),
                    isforeignGun = table.Column<string>(nullable: true),
                    armTypeId = table.Column<int>(nullable: true),
                    abortedarmTypeId = table.Column<int>(nullable: true),
                    islicenseaborted = table.Column<string>(nullable: true),
                    causeofabortion = table.Column<string>(nullable: true),
                    reason = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    isstamp = table.Column<string>(nullable: true),
                    isnotari = table.Column<string>(nullable: true),
                    polPosition = table.Column<string>(nullable: true),
                    LicenseNo = table.Column<string>(nullable: true),
                    jobType = table.Column<string>(nullable: true),
                    jobIdentificationNo = table.Column<string>(nullable: true),
                    jobStatus = table.Column<string>(nullable: true),
                    personType = table.Column<int>(nullable: false),
                    dualCitizenship = table.Column<string>(nullable: true),
                    previousLicenseNo = table.Column<string>(nullable: true),
                    previousArmsCode = table.Column<string>(nullable: true),
                    othersArms = table.Column<string>(nullable: true),
                    endArms = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalInfos_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalInfos_Occupations_occupationId",
                        column: x => x.occupationId,
                        principalTable: "Occupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalInfos_OccupationStatuses_occupationStatusId",
                        column: x => x.occupationStatusId,
                        principalTable: "OccupationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalInfos_organizationInfos_organizationInfoId",
                        column: x => x.organizationInfoId,
                        principalTable: "organizationInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalInfos_PoliticalParties_politicalPartyId",
                        column: x => x.politicalPartyId,
                        principalTable: "PoliticalParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalInfos_Religions_religionId",
                        column: x => x.religionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dealerItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    status = table.Column<int>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    DealerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dealerItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dealerItems_dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_dealerItems_items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "itemSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    itemId = table.Column<int>(nullable: true),
                    specificationName = table.Column<string>(maxLength: 250, nullable: true),
                    unitId = table.Column<int>(nullable: true),
                    itemCode = table.Column<string>(maxLength: 20, nullable: true),
                    itemDescription = table.Column<string>(nullable: true),
                    costingMethod = table.Column<string>(maxLength: 250, nullable: true),
                    reorderQty = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    imageUrl = table.Column<string>(nullable: true),
                    ArmTypeId = table.Column<int>(nullable: true),
                    DealerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_itemSpecifications_ArmTypes_ArmTypeId",
                        column: x => x.ArmTypeId,
                        principalTable: "ArmTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_itemSpecifications_dealers_DealerId",
                        column: x => x.DealerId,
                        principalTable: "dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_itemSpecifications_items_itemId",
                        column: x => x.itemId,
                        principalTable: "items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_itemSpecifications_units_unitId",
                        column: x => x.unitId,
                        principalTable: "units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    supplierId = table.Column<int>(nullable: true),
                    dealerId = table.Column<int>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    personName = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    mobileNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_dealers_dealerId",
                        column: x => x.dealerId,
                        principalTable: "dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contacts_suppliers_supplierId",
                        column: x => x.supplierId,
                        principalTable: "suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "purchaseOrderMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    poNo = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    billOfEntryNo = table.Column<string>(nullable: true),
                    chalanNo = table.Column<string>(nullable: true),
                    poDate = table.Column<DateTime>(nullable: true),
                    paymentDate = table.Column<DateTime>(nullable: true),
                    supplierId = table.Column<int>(nullable: true),
                    paymentTypeId = table.Column<int>(nullable: true),
                    rfqRef = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    billToLocation = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    companyId = table.Column<int>(nullable: true),
                    taxPercent = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    vatPercent = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    totalAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    taxAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    vatAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    sdAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    cdAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    atAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    rdAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    netTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    vds = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    lcNo = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    lcDate = table.Column<DateTime>(nullable: true),
                    countryId = table.Column<int>(nullable: true),
                    purchaseType = table.Column<int>(nullable: true),
                    isClose = table.Column<int>(nullable: true),
                    isStockClose = table.Column<int>(nullable: true),
                    purchaseVatTypeId = table.Column<int>(nullable: true),
                    dealerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseOrderMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purchaseOrderMasters_Countries_countryId",
                        column: x => x.countryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchaseOrderMasters_dealers_dealerId",
                        column: x => x.dealerId,
                        principalTable: "dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchaseOrderMasters_paymentTypes_paymentTypeId",
                        column: x => x.paymentTypeId,
                        principalTable: "paymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchaseOrderMasters_purchaseVatTypes_purchaseVatTypeId",
                        column: x => x.purchaseVatTypeId,
                        principalTable: "purchaseVatTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchaseOrderMasters_suppliers_supplierId",
                        column: x => x.supplierId,
                        principalTable: "suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "supplierAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    addressCategoryId = table.Column<int>(nullable: true),
                    supplierId = table.Column<int>(nullable: true),
                    countryId = table.Column<int>(nullable: true),
                    divisionId = table.Column<int>(nullable: true),
                    districtId = table.Column<int>(nullable: true),
                    thanaId = table.Column<int>(nullable: true),
                    union = table.Column<string>(nullable: true),
                    postOffice = table.Column<string>(nullable: true),
                    postCode = table.Column<string>(nullable: true),
                    blockSector = table.Column<string>(nullable: true),
                    houseVillage = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplierAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_supplierAddress_supplierAddressCategories_addressCategoryId",
                        column: x => x.addressCategoryId,
                        principalTable: "supplierAddressCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_supplierAddress_Countries_countryId",
                        column: x => x.countryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_supplierAddress_Districts_districtId",
                        column: x => x.districtId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_supplierAddress_Divisions_divisionId",
                        column: x => x.divisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_supplierAddress_suppliers_supplierId",
                        column: x => x.supplierId,
                        principalTable: "suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_supplierAddress_Thanas_thanaId",
                        column: x => x.thanaId,
                        principalTable: "Thanas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    personalInfoId = table.Column<int>(nullable: true),
                    organizationInfoId = table.Column<int>(nullable: true),
                    countryId = table.Column<int>(nullable: true),
                    divisionId = table.Column<int>(nullable: true),
                    districtId = table.Column<int>(nullable: true),
                    thanaId = table.Column<int>(nullable: true),
                    union = table.Column<string>(nullable: true),
                    roadNo = table.Column<string>(nullable: true),
                    postOffice = table.Column<string>(nullable: true),
                    postCode = table.Column<string>(nullable: true),
                    blockSector = table.Column<string>(nullable: true),
                    houseVillage = table.Column<string>(nullable: true),
                    area = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addresses_Countries_countryId",
                        column: x => x.countryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_addresses_Districts_districtId",
                        column: x => x.districtId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_addresses_Divisions_divisionId",
                        column: x => x.divisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_addresses_organizationInfos_organizationInfoId",
                        column: x => x.organizationInfoId,
                        principalTable: "organizationInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_addresses_PersonalInfos_personalInfoId",
                        column: x => x.personalInfoId,
                        principalTable: "PersonalInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_addresses_Thanas_thanaId",
                        column: x => x.thanaId,
                        principalTable: "Thanas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "applicationRoutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    status = table.Column<int>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    applicationNo = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: true),
                    divisionId = table.Column<int>(nullable: true),
                    districtId = table.Column<int>(nullable: true),
                    thanaId = table.Column<int>(nullable: true),
                    armTypeId = table.Column<int>(nullable: true),
                    personalInfoId = table.Column<int>(nullable: true),
                    organizationInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicationRoutes_ArmTypes_armTypeId",
                        column: x => x.armTypeId,
                        principalTable: "ArmTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_applicationRoutes_Districts_districtId",
                        column: x => x.districtId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_applicationRoutes_Divisions_divisionId",
                        column: x => x.divisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_applicationRoutes_organizationInfos_organizationInfoId",
                        column: x => x.organizationInfoId,
                        principalTable: "organizationInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_applicationRoutes_PersonalInfos_personalInfoId",
                        column: x => x.personalInfoId,
                        principalTable: "PersonalInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_applicationRoutes_Thanas_thanaId",
                        column: x => x.thanaId,
                        principalTable: "Thanas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "gunRepairs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    referenceNO = table.Column<string>(nullable: true),
                    reason = table.Column<string>(nullable: true),
                    licenseNumber = table.Column<string>(nullable: true),
                    Attachment = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: true),
                    GdNumber = table.Column<string>(nullable: true),
                    GDdate = table.Column<DateTime>(nullable: true),
                    dealerId = table.Column<int>(nullable: true),
                    personalInfoId = table.Column<int>(nullable: true),
                    organizationInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gunRepairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gunRepairs_dealers_dealerId",
                        column: x => x.dealerId,
                        principalTable: "dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_gunRepairs_organizationInfos_organizationInfoId",
                        column: x => x.organizationInfoId,
                        principalTable: "organizationInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_gunRepairs_PersonalInfos_personalInfoId",
                        column: x => x.personalInfoId,
                        principalTable: "PersonalInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LicenseInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    licenseTypeId = table.Column<int>(nullable: true),
                    armTypeId = table.Column<int>(nullable: true),
                    licenseSourseTypeId = table.Column<int>(nullable: true),
                    licenseNumber = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    thanaId = table.Column<int>(nullable: true),
                    DistrictId = table.Column<int>(nullable: true),
                    divisionId = table.Column<int>(nullable: true),
                    place = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    reason = table.Column<string>(type: "NVARCHAR(260)", nullable: true),
                    source = table.Column<string>(type: "NVARCHAR(60)", nullable: true),
                    dateOfIssue = table.Column<DateTime>(nullable: true),
                    dateOfExpair = table.Column<DateTime>(nullable: true),
                    remarks = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    personalInfoId = table.Column<int>(nullable: true),
                    organizationInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseInfos_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseInfos_ArmTypes_armTypeId",
                        column: x => x.armTypeId,
                        principalTable: "ArmTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseInfos_Divisions_divisionId",
                        column: x => x.divisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseInfos_LicenseSourseTypes_licenseSourseTypeId",
                        column: x => x.licenseSourseTypeId,
                        principalTable: "LicenseSourseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseInfos_LicenseTypes_licenseTypeId",
                        column: x => x.licenseTypeId,
                        principalTable: "LicenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseInfos_organizationInfos_organizationInfoId",
                        column: x => x.organizationInfoId,
                        principalTable: "organizationInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseInfos_PersonalInfos_personalInfoId",
                        column: x => x.personalInfoId,
                        principalTable: "PersonalInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LicenseInfos_Thanas_thanaId",
                        column: x => x.thanaId,
                        principalTable: "Thanas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personalAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    fileUrl = table.Column<string>(nullable: true),
                    fileName = table.Column<string>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: true),
                    personalInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personalAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personalAttachments_PersonalInfos_personalInfoId",
                        column: x => x.personalInfoId,
                        principalTable: "PersonalInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photographs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    personalInfoId = table.Column<int>(nullable: true),
                    organizationInfoId = table.Column<int>(nullable: true),
                    url = table.Column<string>(nullable: false),
                    remarks = table.Column<string>(type: "NVARCHAR(300)", nullable: true),
                    type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photographs_organizationInfos_organizationInfoId",
                        column: x => x.organizationInfoId,
                        principalTable: "organizationInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photographs_PersonalInfos_personalInfoId",
                        column: x => x.personalInfoId,
                        principalTable: "PersonalInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "specificationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    specificationCategoryId = table.Column<int>(nullable: true),
                    value = table.Column<string>(maxLength: 250, nullable: true),
                    itemSpecificationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specificationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_specificationDetails_itemSpecifications_itemSpecificationId",
                        column: x => x.itemSpecificationId,
                        principalTable: "itemSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_specificationDetails_specificationCategories_specificationCategoryId",
                        column: x => x.specificationCategoryId,
                        principalTable: "specificationCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "purchaseOrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    purchaseId = table.Column<int>(nullable: true),
                    itemSpecificationId = table.Column<int>(nullable: true),
                    description = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    rate = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    currencyId = table.Column<int>(nullable: true),
                    vatPercent = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    taxPercent = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    cdPercent = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    sdPercent = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    atPercent = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    rdPercent = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    vatAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    taxAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    cdAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    sdAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    atAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    rdAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purchaseOrderDetails_currencies_currencyId",
                        column: x => x.currencyId,
                        principalTable: "currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchaseOrderDetails_itemSpecifications_itemSpecificationId",
                        column: x => x.itemSpecificationId,
                        principalTable: "itemSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchaseOrderDetails_purchaseOrderMasters_purchaseId",
                        column: x => x.purchaseId,
                        principalTable: "purchaseOrderMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "purchaseReturnMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    purchaseOrderMasterId = table.Column<int>(nullable: true),
                    invoiceDate = table.Column<DateTime>(nullable: true),
                    paymentDate = table.Column<DateTime>(nullable: true),
                    invoiceNumber = table.Column<string>(nullable: true),
                    totalAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    VATOnTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    DiscountOnTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    NetTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    SDOnTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    isClose = table.Column<int>(nullable: true),
                    isStockClose = table.Column<int>(nullable: true),
                    isPayClose = table.Column<int>(nullable: true),
                    remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseReturnMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purchaseReturnMasters_purchaseOrderMasters_purchaseOrderMasterId",
                        column: x => x.purchaseOrderMasterId,
                        principalTable: "purchaseOrderMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "applicationAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    fileName = table.Column<string>(nullable: true),
                    fileUrl = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: true),
                    applicationRouteId = table.Column<int>(nullable: true),
                    applicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicationAttachments_applicationRoutes_applicationRouteId",
                        column: x => x.applicationRouteId,
                        principalTable: "applicationRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_applicationAttachments_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "applicationEnquireInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    socialPeaceBreakingStatus = table.Column<int>(nullable: true),
                    armsManagementKnoledgeStatus = table.Column<int>(nullable: true),
                    lifeThreatArmsNeedStatus = table.Column<int>(nullable: true),
                    allCertificateVarifyStatus = table.Column<int>(nullable: true),
                    voilenceInfo = table.Column<string>(nullable: true),
                    isAppropriate = table.Column<int>(nullable: true),
                    status = table.Column<int>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: true),
                    applicationRouteId = table.Column<int>(nullable: true),
                    applicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationEnquireInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicationEnquireInfos_applicationRoutes_applicationRouteId",
                        column: x => x.applicationRouteId,
                        principalTable: "applicationRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_applicationEnquireInfos_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "appllicationRouteLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    status = table.Column<int>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    comments = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: true),
                    applicationRouteId = table.Column<int>(nullable: true),
                    applicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appllicationRouteLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appllicationRouteLogs_applicationRoutes_applicationRouteId",
                        column: x => x.applicationRouteId,
                        principalTable: "applicationRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appllicationRouteLogs_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "gunRepairAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    fileUrl = table.Column<string>(nullable: true),
                    fileName = table.Column<string>(nullable: true),
                    remarks = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: true),
                    gunRepairId = table.Column<int>(nullable: true),
                    personalInfoId = table.Column<int>(nullable: true),
                    organizationInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gunRepairAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gunRepairAttachments_gunRepairs_gunRepairId",
                        column: x => x.gunRepairId,
                        principalTable: "gunRepairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_gunRepairAttachments_organizationInfos_organizationInfoId",
                        column: x => x.organizationInfoId,
                        principalTable: "organizationInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_gunRepairAttachments_PersonalInfos_personalInfoId",
                        column: x => x.personalInfoId,
                        principalTable: "PersonalInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "salesInvoiceMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    licenseInfoId = table.Column<int>(nullable: true),
                    dealerId = table.Column<int>(nullable: true),
                    invoiceDate = table.Column<DateTime>(nullable: true),
                    paymentDate = table.Column<DateTime>(nullable: true),
                    invoiceNumber = table.Column<string>(nullable: true),
                    totalAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    VATOnTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    DiscountOnTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    TAXOnTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    SDOnTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    CDOnTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    ATOnTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    RDOnTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    NetTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    isClose = table.Column<int>(nullable: true),
                    isStockClose = table.Column<int>(nullable: true),
                    lcNo = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    shiftTo = table.Column<string>(nullable: true),
                    lcDate = table.Column<DateTime>(nullable: true),
                    countryId = table.Column<int>(nullable: true),
                    salesType = table.Column<int>(nullable: true),
                    exportType = table.Column<int>(nullable: true),
                    vds = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    salesVatTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesInvoiceMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_salesInvoiceMasters_Countries_countryId",
                        column: x => x.countryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_salesInvoiceMasters_dealers_dealerId",
                        column: x => x.dealerId,
                        principalTable: "dealers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_salesInvoiceMasters_LicenseInfos_licenseInfoId",
                        column: x => x.licenseInfoId,
                        principalTable: "LicenseInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_salesInvoiceMasters_salesVatTypes_salesVatTypeId",
                        column: x => x.salesVatTypeId,
                        principalTable: "salesVatTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "salesReturnInvoiceMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    licenseInfoId = table.Column<int>(nullable: true),
                    invoiceDate = table.Column<DateTime>(nullable: true),
                    paymentDate = table.Column<DateTime>(nullable: true),
                    invoiceNumber = table.Column<string>(nullable: true),
                    totalAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    VATOnTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    DiscountOnTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    NetTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    SDOnTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    isClose = table.Column<int>(nullable: true),
                    isStockClose = table.Column<int>(nullable: true),
                    isPayClose = table.Column<int>(nullable: true),
                    remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesReturnInvoiceMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_salesReturnInvoiceMasters_LicenseInfos_licenseInfoId",
                        column: x => x.licenseInfoId,
                        principalTable: "LicenseInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "purchaseReturnDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    purchaseReturnMasterId = table.Column<int>(nullable: true),
                    purchaseOrderDetailId = table.Column<int>(nullable: true),
                    quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseReturnDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purchaseReturnDetails_purchaseOrderDetails_purchaseOrderDetailId",
                        column: x => x.purchaseOrderDetailId,
                        principalTable: "purchaseOrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchaseReturnDetails_purchaseReturnMasters_purchaseReturnMasterId",
                        column: x => x.purchaseReturnMasterId,
                        principalTable: "purchaseReturnMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "salesInvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    itemSpecificationId = table.Column<int>(nullable: true),
                    salesInvoiceMasterId = table.Column<int>(nullable: true),
                    quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    rate = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    vatAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    taxAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    sdAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    cdAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    atAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    rdAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    lineTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    vatPercentage = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    taxPercentage = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    sdPercentage = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    cdPercentage = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    atPercentage = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    rdPercentage = table.Column<decimal>(type: "decimal(18,6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesInvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_salesInvoiceDetails_itemSpecifications_itemSpecificationId",
                        column: x => x.itemSpecificationId,
                        principalTable: "itemSpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_salesInvoiceDetails_salesInvoiceMasters_salesInvoiceMasterId",
                        column: x => x.salesInvoiceMasterId,
                        principalTable: "salesInvoiceMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "salesReturnInvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    salesReturnInvoiceMasterId = table.Column<int>(nullable: true),
                    salesInvoiceDetailId = table.Column<int>(nullable: true),
                    quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesReturnInvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_salesReturnInvoiceDetails_salesInvoiceDetails_salesInvoiceDetailId",
                        column: x => x.salesInvoiceDetailId,
                        principalTable: "salesInvoiceDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_salesReturnInvoiceDetails_salesReturnInvoiceMasters_salesReturnInvoiceMasterId",
                        column: x => x.salesReturnInvoiceMasterId,
                        principalTable: "salesReturnInvoiceMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_countryId",
                table: "addresses",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_districtId",
                table: "addresses",
                column: "districtId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_divisionId",
                table: "addresses",
                column: "divisionId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_organizationInfoId",
                table: "addresses",
                column: "organizationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_personalInfoId",
                table: "addresses",
                column: "personalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_addresses_thanaId",
                table: "addresses",
                column: "thanaId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationAttachments_applicationRouteId",
                table: "applicationAttachments",
                column: "applicationRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationAttachments_applicationUserId",
                table: "applicationAttachments",
                column: "applicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationEnquireInfos_applicationRouteId",
                table: "applicationEnquireInfos",
                column: "applicationRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationEnquireInfos_applicationUserId",
                table: "applicationEnquireInfos",
                column: "applicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationRoutes_armTypeId",
                table: "applicationRoutes",
                column: "armTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationRoutes_districtId",
                table: "applicationRoutes",
                column: "districtId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationRoutes_divisionId",
                table: "applicationRoutes",
                column: "divisionId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationRoutes_organizationInfoId",
                table: "applicationRoutes",
                column: "organizationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationRoutes_personalInfoId",
                table: "applicationRoutes",
                column: "personalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationRoutes_thanaId",
                table: "applicationRoutes",
                column: "thanaId");

            migrationBuilder.CreateIndex(
                name: "IX_appllicationRouteLogs_applicationRouteId",
                table: "appllicationRouteLogs",
                column: "applicationRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_appllicationRouteLogs_applicationUserId",
                table: "appllicationRouteLogs",
                column: "applicationUserId");

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
                name: "IX_AspNetUsers_districtId",
                table: "AspNetUsers",
                column: "districtId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_divisionId",
                table: "AspNetUsers",
                column: "divisionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_thanaId",
                table: "AspNetUsers",
                column: "thanaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_userTypeId",
                table: "AspNetUsers",
                column: "userTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_dealerId",
                table: "contacts",
                column: "dealerId");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_supplierId",
                table: "contacts",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_dealerAddresss_addressCategoryId",
                table: "dealerAddresss",
                column: "addressCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_dealerAddresss_countryId",
                table: "dealerAddresss",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_dealerAddresss_dealerId",
                table: "dealerAddresss",
                column: "dealerId");

            migrationBuilder.CreateIndex(
                name: "IX_dealerAddresss_districtId",
                table: "dealerAddresss",
                column: "districtId");

            migrationBuilder.CreateIndex(
                name: "IX_dealerAddresss_divisionId",
                table: "dealerAddresss",
                column: "divisionId");

            migrationBuilder.CreateIndex(
                name: "IX_dealerAddresss_thanaId",
                table: "dealerAddresss",
                column: "thanaId");

            migrationBuilder.CreateIndex(
                name: "IX_dealerItems_DealerId",
                table: "dealerItems",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_dealerItems_ItemId",
                table: "dealerItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_dealers_ApplicationUserId",
                table: "dealers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_dealers_dealerTypeId",
                table: "dealers",
                column: "dealerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_divisionId",
                table: "Districts",
                column: "divisionId");

            migrationBuilder.CreateIndex(
                name: "IX_DivisionDistricts_rangeMetroId",
                table: "DivisionDistricts",
                column: "rangeMetroId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_countryId",
                table: "Divisions",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_gunRepairAttachments_gunRepairId",
                table: "gunRepairAttachments",
                column: "gunRepairId");

            migrationBuilder.CreateIndex(
                name: "IX_gunRepairAttachments_organizationInfoId",
                table: "gunRepairAttachments",
                column: "organizationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_gunRepairAttachments_personalInfoId",
                table: "gunRepairAttachments",
                column: "personalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_gunRepairs_dealerId",
                table: "gunRepairs",
                column: "dealerId");

            migrationBuilder.CreateIndex(
                name: "IX_gunRepairs_organizationInfoId",
                table: "gunRepairs",
                column: "organizationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_gunRepairs_personalInfoId",
                table: "gunRepairs",
                column: "personalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_itemHsCodes_taxYearId",
                table: "itemHsCodes",
                column: "taxYearId");

            migrationBuilder.CreateIndex(
                name: "IX_itemHsCodes_vATScheduleId",
                table: "itemHsCodes",
                column: "vATScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_itemHsCodes_vatCategoryId",
                table: "itemHsCodes",
                column: "vatCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_itemHsCodes_vatTableId",
                table: "itemHsCodes",
                column: "vatTableId");

            migrationBuilder.CreateIndex(
                name: "IX_items_ArmTypeId",
                table: "items",
                column: "ArmTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_items_DealerId",
                table: "items",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_items_itemHsCodeId",
                table: "items",
                column: "itemHsCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_items_productionTypeId",
                table: "items",
                column: "productionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_items_unitId",
                table: "items",
                column: "unitId");

            migrationBuilder.CreateIndex(
                name: "IX_itemSpecifications_ArmTypeId",
                table: "itemSpecifications",
                column: "ArmTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_itemSpecifications_DealerId",
                table: "itemSpecifications",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_itemSpecifications_itemId",
                table: "itemSpecifications",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_itemSpecifications_unitId",
                table: "itemSpecifications",
                column: "unitId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseInfos_DistrictId",
                table: "LicenseInfos",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseInfos_armTypeId",
                table: "LicenseInfos",
                column: "armTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseInfos_divisionId",
                table: "LicenseInfos",
                column: "divisionId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseInfos_licenseSourseTypeId",
                table: "LicenseInfos",
                column: "licenseSourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseInfos_licenseTypeId",
                table: "LicenseInfos",
                column: "licenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseInfos_organizationInfoId",
                table: "LicenseInfos",
                column: "organizationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseInfos_personalInfoId",
                table: "LicenseInfos",
                column: "personalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseInfos_thanaId",
                table: "LicenseInfos",
                column: "thanaId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleAccessPages_applicationRoleId",
                table: "ModuleAccessPages",
                column: "applicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleAccessPages_eRPModuleId",
                table: "ModuleAccessPages",
                column: "eRPModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Navbars_moduleId",
                table: "Navbars",
                column: "moduleId");

            migrationBuilder.CreateIndex(
                name: "IX_organizationAttachments_organizationInfoId",
                table: "organizationAttachments",
                column: "organizationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_organizationInfos_ApplicationUserId",
                table: "organizationInfos",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_organizationInfos_armTypeId",
                table: "organizationInfos",
                column: "armTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_personalAttachments_personalInfoId",
                table: "personalAttachments",
                column: "personalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfos_ApplicationUserId",
                table: "PersonalInfos",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfos_occupationId",
                table: "PersonalInfos",
                column: "occupationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfos_occupationStatusId",
                table: "PersonalInfos",
                column: "occupationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfos_organizationInfoId",
                table: "PersonalInfos",
                column: "organizationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfos_politicalPartyId",
                table: "PersonalInfos",
                column: "politicalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfos_religionId",
                table: "PersonalInfos",
                column: "religionId");

            migrationBuilder.CreateIndex(
                name: "IX_Photographs_organizationInfoId",
                table: "Photographs",
                column: "organizationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Photographs_personalInfoId",
                table: "Photographs",
                column: "personalInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseOrderDetails_currencyId",
                table: "purchaseOrderDetails",
                column: "currencyId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseOrderDetails_itemSpecificationId",
                table: "purchaseOrderDetails",
                column: "itemSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseOrderDetails_purchaseId",
                table: "purchaseOrderDetails",
                column: "purchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseOrderMasters_countryId",
                table: "purchaseOrderMasters",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseOrderMasters_dealerId",
                table: "purchaseOrderMasters",
                column: "dealerId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseOrderMasters_paymentTypeId",
                table: "purchaseOrderMasters",
                column: "paymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseOrderMasters_purchaseVatTypeId",
                table: "purchaseOrderMasters",
                column: "purchaseVatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseOrderMasters_supplierId",
                table: "purchaseOrderMasters",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseReturnDetails_purchaseOrderDetailId",
                table: "purchaseReturnDetails",
                column: "purchaseOrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseReturnDetails_purchaseReturnMasterId",
                table: "purchaseReturnDetails",
                column: "purchaseReturnMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseReturnMasters_purchaseOrderMasterId",
                table: "purchaseReturnMasters",
                column: "purchaseOrderMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_salesInvoiceDetails_itemSpecificationId",
                table: "salesInvoiceDetails",
                column: "itemSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_salesInvoiceDetails_salesInvoiceMasterId",
                table: "salesInvoiceDetails",
                column: "salesInvoiceMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_salesInvoiceMasters_countryId",
                table: "salesInvoiceMasters",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_salesInvoiceMasters_dealerId",
                table: "salesInvoiceMasters",
                column: "dealerId");

            migrationBuilder.CreateIndex(
                name: "IX_salesInvoiceMasters_licenseInfoId",
                table: "salesInvoiceMasters",
                column: "licenseInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_salesInvoiceMasters_salesVatTypeId",
                table: "salesInvoiceMasters",
                column: "salesVatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_salesReturnInvoiceDetails_salesInvoiceDetailId",
                table: "salesReturnInvoiceDetails",
                column: "salesInvoiceDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_salesReturnInvoiceDetails_salesReturnInvoiceMasterId",
                table: "salesReturnInvoiceDetails",
                column: "salesReturnInvoiceMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_salesReturnInvoiceMasters_licenseInfoId",
                table: "salesReturnInvoiceMasters",
                column: "licenseInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_specificationDetails_itemSpecificationId",
                table: "specificationDetails",
                column: "itemSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_specificationDetails_specificationCategoryId",
                table: "specificationDetails",
                column: "specificationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_supplierAddress_addressCategoryId",
                table: "supplierAddress",
                column: "addressCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_supplierAddress_countryId",
                table: "supplierAddress",
                column: "countryId");

            migrationBuilder.CreateIndex(
                name: "IX_supplierAddress_districtId",
                table: "supplierAddress",
                column: "districtId");

            migrationBuilder.CreateIndex(
                name: "IX_supplierAddress_divisionId",
                table: "supplierAddress",
                column: "divisionId");

            migrationBuilder.CreateIndex(
                name: "IX_supplierAddress_supplierId",
                table: "supplierAddress",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_supplierAddress_thanaId",
                table: "supplierAddress",
                column: "thanaId");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_DealerId",
                table: "suppliers",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_supplierTypeId",
                table: "suppliers",
                column: "supplierTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Thanas_districtId",
                table: "Thanas",
                column: "districtId");

            migrationBuilder.CreateIndex(
                name: "IX_Thanas_rangeMetroId",
                table: "Thanas",
                column: "rangeMetroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "applicationAttachments");

            migrationBuilder.DropTable(
                name: "applicationEnquireInfos");

            migrationBuilder.DropTable(
                name: "appllicationRouteLogs");

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
                name: "comments");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "dealerAddresss");

            migrationBuilder.DropTable(
                name: "dealerItems");

            migrationBuilder.DropTable(
                name: "DivisionDistricts");

            migrationBuilder.DropTable(
                name: "gunRepairAttachments");

            migrationBuilder.DropTable(
                name: "ModuleAccessPages");

            migrationBuilder.DropTable(
                name: "Navbars");

            migrationBuilder.DropTable(
                name: "organizationAttachments");

            migrationBuilder.DropTable(
                name: "organizationTypes");

            migrationBuilder.DropTable(
                name: "personalAttachments");

            migrationBuilder.DropTable(
                name: "Photographs");

            migrationBuilder.DropTable(
                name: "purchaseReturnDetails");

            migrationBuilder.DropTable(
                name: "salesReturnInvoiceDetails");

            migrationBuilder.DropTable(
                name: "specificationDetails");

            migrationBuilder.DropTable(
                name: "supplierAddress");

            migrationBuilder.DropTable(
                name: "applicationRoutes");

            migrationBuilder.DropTable(
                name: "dealerAddressCategories");

            migrationBuilder.DropTable(
                name: "gunRepairs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FAMSModules");

            migrationBuilder.DropTable(
                name: "purchaseOrderDetails");

            migrationBuilder.DropTable(
                name: "purchaseReturnMasters");

            migrationBuilder.DropTable(
                name: "salesInvoiceDetails");

            migrationBuilder.DropTable(
                name: "salesReturnInvoiceMasters");

            migrationBuilder.DropTable(
                name: "specificationCategories");

            migrationBuilder.DropTable(
                name: "supplierAddressCategories");

            migrationBuilder.DropTable(
                name: "currencies");

            migrationBuilder.DropTable(
                name: "purchaseOrderMasters");

            migrationBuilder.DropTable(
                name: "itemSpecifications");

            migrationBuilder.DropTable(
                name: "salesInvoiceMasters");

            migrationBuilder.DropTable(
                name: "paymentTypes");

            migrationBuilder.DropTable(
                name: "purchaseVatTypes");

            migrationBuilder.DropTable(
                name: "suppliers");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "LicenseInfos");

            migrationBuilder.DropTable(
                name: "salesVatTypes");

            migrationBuilder.DropTable(
                name: "supplierTypes");

            migrationBuilder.DropTable(
                name: "dealers");

            migrationBuilder.DropTable(
                name: "itemHsCodes");

            migrationBuilder.DropTable(
                name: "productionTypes");

            migrationBuilder.DropTable(
                name: "units");

            migrationBuilder.DropTable(
                name: "LicenseSourseTypes");

            migrationBuilder.DropTable(
                name: "LicenseTypes");

            migrationBuilder.DropTable(
                name: "PersonalInfos");

            migrationBuilder.DropTable(
                name: "dealerTypes");

            migrationBuilder.DropTable(
                name: "taxYears");

            migrationBuilder.DropTable(
                name: "vATSchedules");

            migrationBuilder.DropTable(
                name: "vatCategories");

            migrationBuilder.DropTable(
                name: "vatTables");

            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropTable(
                name: "OccupationStatuses");

            migrationBuilder.DropTable(
                name: "organizationInfos");

            migrationBuilder.DropTable(
                name: "PoliticalParties");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ArmTypes");

            migrationBuilder.DropTable(
                name: "Thanas");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "RangeMetros");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
