using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fraud.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cr");

            migrationBuilder.EnsureSchema(
                name: "fr");

            migrationBuilder.EnsureSchema(
                name: "cmn");

            migrationBuilder.CreateTable(
                name: "BdD1_Karbari",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    PrvNo = table.Column<int>(type: "int", nullable: false),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    BeginDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadeseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HadeseDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GovahiSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovahiSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadesePlaceDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElatHadeseId = table.Column<int>(type: "int", nullable: true),
                    ElatHadeseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovahiTypeId = table.Column<int>(type: "int", nullable: false),
                    GovahiTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoredEstefadeId = table.Column<int>(type: "int", nullable: true),
                    MoredEstefadeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhodroListId = table.Column<int>(type: "int", nullable: false),
                    KhodroKindId = table.Column<int>(type: "int", nullable: true),
                    KhodrokindName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageSodurId = table.Column<int>(type: "int", nullable: false),
                    DamageSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumHvPayAmountAsRial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KhodroArzeshAsRial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalSakhtMiladi = table.Column<int>(type: "int", nullable: true),
                    SalSakhtShamsi = table.Column<int>(type: "int", nullable: true),
                    BdHadeseKindId = table.Column<int>(type: "int", nullable: true),
                    BdHadeseKindName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdD1_Karbari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdD2_Franshiz",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrvId = table.Column<int>(type: "int", nullable: false),
                    PrvNo = table.Column<int>(type: "int", nullable: true),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    VsodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VsodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GovahiSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovahiSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tafavot = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvSodurId = table.Column<int>(type: "int", nullable: false),
                    PrvSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnUserId = table.Column<int>(type: "int", nullable: false),
                    BnUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvUserId = table.Column<int>(type: "int", nullable: false),
                    PrvUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdD2_Franshiz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdD3_GovahiCarType",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GovahiTypeId = table.Column<int>(type: "int", nullable: false),
                    GovahiTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhodroGoruhId = table.Column<int>(type: "int", nullable: false),
                    KhodroGoruhName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhodroId = table.Column<int>(type: "int", nullable: false),
                    KhodroKindCaption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SarneshinCount = table.Column<int>(type: "int", nullable: true),
                    Tonaje = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrvId = table.Column<int>(type: "int", nullable: false),
                    PrvNo = table.Column<int>(type: "int", nullable: true),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadeseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HadeseDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnUserId = table.Column<int>(type: "int", nullable: false),
                    BnUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvUserId = table.Column<int>(type: "int", nullable: false),
                    PrvUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdD3_GovahiCarType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdD4_Estehlak",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrvId = table.Column<int>(type: "int", nullable: false),
                    PrvNo = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvSodurId = table.Column<int>(type: "int", nullable: false),
                    PrvSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadeseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HadeseDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    BnUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdD4_Estehlak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdD5_CarAmount",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrvId = table.Column<int>(type: "int", nullable: false),
                    PrvNo = table.Column<int>(type: "int", nullable: true),
                    KhodroArzesh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KhodroArzeshRouz = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvSodurId = table.Column<int>(type: "int", nullable: false),
                    PrvSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnUserId = table.Column<int>(type: "int", nullable: false),
                    BnUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvUserId = table.Column<int>(type: "int", nullable: false),
                    PrvUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdD5_CarAmount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdD6_DayDamage",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    PrvId = table.Column<int>(type: "int", nullable: false),
                    PrvNo = table.Column<int>(type: "int", nullable: true),
                    BnsodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadeseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HadeseDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDifference = table.Column<int>(type: "int", nullable: true),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElatHadese = table.Column<int>(type: "int", nullable: true),
                    ElatHadeseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvSodurId = table.Column<int>(type: "int", nullable: false),
                    PrvSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnUserId = table.Column<int>(type: "int", nullable: false),
                    BnUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvUserId = table.Column<int>(type: "int", nullable: false),
                    PrvUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastBnEndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdD6_DayDamage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdD7_InstallmentWithHv",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrmSrdId = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayerCustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SrdDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SrdDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActiveId = table.Column<int>(type: "int", nullable: false),
                    TasvieType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SrdAmountAsRial = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TasvieAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Mande = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TasvieNashode = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VosulShode = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AmaliatTasvieType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadeseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HadeseDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ElamDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElamDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrvNo = table.Column<int>(type: "int", nullable: true),
                    HvAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VslStateDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VslStateDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsNaghdiId = table.Column<int>(type: "int", nullable: true),
                    DeliverDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliverDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RcvdKindId = table.Column<int>(type: "int", nullable: true),
                    RcvdKindName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VslStateId = table.Column<int>(type: "int", nullable: true),
                    VslStateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdD7_InstallmentWithHv", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdP1_206Pushesh",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    KhodroName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalSakht = table.Column<int>(type: "int", nullable: false),
                    SodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdP1_206Pushesh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdP3_NewCarDiscount",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    BnsodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnsodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PelakDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PelakDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurDataMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TafavotPelakSodurDate = table.Column<int>(type: "int", nullable: true),
                    Nerkh = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PusheshEzafiNerkh = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdP3_NewCarDiscount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdP4_TroubledCustomer",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: false),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonkindId = table.Column<int>(type: "int", nullable: false),
                    PersonKindText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeMelli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePosti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdP4_TroubledCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BdP5_TroubledKhodro",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: false),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhodroId = table.Column<int>(type: "int", nullable: false),
                    ShasiNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PelakNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotorNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BdP5_TroubledKhodro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimSabegheSalesKind",
                schema: "cr",
                columns: table => new
                {
                    SabegheSalesKindId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimSabegheSalesKind", x => x.SabegheSalesKindId);
                });

            migrationBuilder.CreateTable(
                name: "FireP01_TroubledCodePosti",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: false),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP01_TroubledCodePosti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP03_BnNoLastPolicyId",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: false),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: true),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP03_BnNoLastPolicyId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP04_TafkikList",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    Mid = table.Column<int>(type: "int", nullable: true),
                    Eid = table.Column<int>(type: "int", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KhatarEzafiId = table.Column<int>(type: "int", nullable: false),
                    EzafiRiskKind = table.Column<int>(type: "int", nullable: false),
                    KhatarEzafiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoreBimeId = table.Column<int>(type: "int", nullable: false),
                    MoreBimeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoreBimeSharh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sarmaye = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kind = table.Column<int>(type: "int", nullable: true),
                    MoredKind = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP04_TafkikList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP06_AfzayeshSarmaye",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyVerId = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: false),
                    Ro = table.Column<int>(type: "int", nullable: false),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    PolicyTypeId = table.Column<int>(type: "int", nullable: false),
                    Sarmaye = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiffRate = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP06_AfzayeshSarmaye", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP07_AnbarBazdid",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP07_AnbarBazdid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP08_AsaBazdid",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BazdidId = table.Column<int>(type: "int", nullable: false),
                    PolicyVid = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: false),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BazdidDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BazdidDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiffDate = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP08_AsaBazdid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP09_MaskanBazdid",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyVid = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    Reshte = table.Column<int>(type: "int", nullable: false),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sarmaye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP09_MaskanBazdid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP10_GheirSanatiBazdidOver10",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyVid = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    Reshte = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sarmaye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RiskTabagh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP10_GheirSanatiBazdidOver10", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP11_GheirSanatiBazdidOver80",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyVid = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<short>(type: "smallint", nullable: false),
                    Reshte = table.Column<short>(type: "smallint", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sarmaye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP11_GheirSanatiBazdidOver80", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP12_AnbarBazdidOver10",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyVid = table.Column<int>(type: "int", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    Reshte = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sarmaye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RiskTabagh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP12_AnbarBazdidOver10", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP13_SanatiBazdidOver20",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyVid = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    Reshte = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sarmaye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RiskTabagh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP13_SanatiBazdidOver20", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP14_SanatiAnbarBazdidSpecialGroup",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyVid = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: false),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    Reshte = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sarmaye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RiskTabagh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP14_SanatiAnbarBazdidSpecialGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP15_BazdidSpecialGroupOver30",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EzafiId = table.Column<int>(type: "int", nullable: true),
                    PolicyVid = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    Reshte = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sarmaye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RiskTabagh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP15_BazdidSpecialGroupOver30", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP16_SerghatBazdidOver700",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EzafiId = table.Column<int>(type: "int", nullable: false),
                    PolicyVid = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    Reshte = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sarmaye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RiskTabagh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP16_SerghatBazdidOver700", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP17_SpecialGroupBazdid",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EzafiId = table.Column<int>(type: "int", nullable: false),
                    PolicyVid = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    Eid = table.Column<int>(type: "int", nullable: true),
                    Reshte = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sarmaye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RiskTabagh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP17_SpecialGroupBazdid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP18_DamagedBazdid",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EzafiId = table.Column<int>(type: "int", nullable: false),
                    PolicyVid = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    Eid = table.Column<int>(type: "int", nullable: true),
                    EzafiRiskKind = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reshte = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sarmaye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP18_DamagedBazdid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP19_MinPrm",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyVid = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    Reshte = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sarmaye = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP19_MinPrm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP21_CashPrmBn",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrmSrdId = table.Column<int>(type: "int", nullable: false),
                    Op = table.Column<int>(type: "int", nullable: true),
                    Ebdid = table.Column<int>(type: "int", nullable: true),
                    MaliBid = table.Column<int>(type: "int", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReshteId = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VosulShode = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remain = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrmAsRial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OperationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP21_CashPrmBn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireP23_CashPrmElh",
                schema: "fr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrmSrdId = table.Column<int>(type: "int", nullable: false),
                    Op = table.Column<int>(type: "int", nullable: true),
                    Ebdid = table.Column<int>(type: "int", nullable: true),
                    MaliBid = table.Column<int>(type: "int", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReshteId = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VosulShode = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remain = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrmAsRial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OperationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireP23_CashPrmElh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportFromAllTable",
                schema: "cmn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KpiTypeId = table.Column<int>(type: "int", nullable: false),
                    KpiTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReshteId = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnt = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportFromAllTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesD1_Karbari",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    PrvNo = table.Column<int>(type: "int", nullable: false),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    BeginDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadeseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HadeseDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadeseAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElatHadeseId = table.Column<int>(type: "int", nullable: true),
                    ElatHadeseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovahiTypeId = table.Column<int>(type: "int", nullable: true),
                    GovahiTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoredEstefadeId = table.Column<int>(type: "int", nullable: false),
                    MoredEstefadeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhodroListId = table.Column<int>(type: "int", nullable: false),
                    KhodroKindId = table.Column<int>(type: "int", nullable: true),
                    KhodroKindName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageSodurId = table.Column<int>(type: "int", nullable: false),
                    DamageSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumHvPayAmountAsRial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DamageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesD1_Karbari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesD2_BazyaftNotTasvie",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvId = table.Column<int>(type: "int", nullable: true),
                    PrvNo = table.Column<int>(type: "int", nullable: true),
                    ElatHadeseId = table.Column<int>(type: "int", nullable: true),
                    ElatHadeseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HvgirandeId = table.Column<int>(type: "int", nullable: false),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadeseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HadeseDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hvdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HvdateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hvid = table.Column<int>(type: "int", nullable: false),
                    Hvno = table.Column<int>(type: "int", nullable: true),
                    HvamountAsRial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HvgusableAmountAsRial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvSodurId = table.Column<int>(type: "int", nullable: false),
                    PrvSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesD2_BazyaftNotTasvie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesD2_BazyaftTasvieStatus",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvId = table.Column<int>(type: "int", nullable: true),
                    PrvNo = table.Column<int>(type: "int", nullable: true),
                    ElatHadeseId = table.Column<int>(type: "int", nullable: true),
                    ElatHadeseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HvgirandeId = table.Column<int>(type: "int", nullable: false),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadeseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HadeseDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hvdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HvdateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hvid = table.Column<int>(type: "int", nullable: false),
                    Hvno = table.Column<int>(type: "int", nullable: true),
                    HvamountAsRial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HvgusableAmountAsRial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvSodurId = table.Column<int>(type: "int", nullable: false),
                    PrvSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesD2_BazyaftTasvieStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesD2_TakhalofHadeseSaz",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvId = table.Column<int>(type: "int", nullable: false),
                    PrvNo = table.Column<int>(type: "int", nullable: false),
                    ElatHadeseId = table.Column<int>(type: "int", nullable: true),
                    ElatHadeseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadeseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HadeseDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvSodurId = table.Column<int>(type: "int", nullable: false),
                    PrvSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesD2_TakhalofHadeseSaz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesD3_GovahiCarType",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GovahiType = table.Column<int>(type: "int", nullable: true),
                    GovahiTypeId = table.Column<int>(type: "int", nullable: false),
                    GovahiTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhodroGoruhId = table.Column<int>(type: "int", nullable: false),
                    KhodroGoruhName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhodroId = table.Column<int>(type: "int", nullable: false),
                    KhodroKindCaption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SarneshinCount = table.Column<int>(type: "int", nullable: true),
                    Tonaje = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrvId = table.Column<int>(type: "int", nullable: false),
                    PrvNo = table.Column<int>(type: "int", nullable: true),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadeseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HadeseDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesD3_GovahiCarType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesD6_DayDamage",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    PrvId = table.Column<int>(type: "int", nullable: false),
                    PrvNo = table.Column<int>(type: "int", nullable: true),
                    BnsodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadeseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HadeseDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDifference = table.Column<int>(type: "int", nullable: true),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElatHadese = table.Column<int>(type: "int", nullable: true),
                    ElatHadeseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvSodurId = table.Column<int>(type: "int", nullable: false),
                    PrvSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DamageMoredId = table.Column<int>(type: "int", nullable: true),
                    DamageMoredName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnUserId = table.Column<int>(type: "int", nullable: false),
                    BnUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvUserId = table.Column<int>(type: "int", nullable: false),
                    PrvUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastBnEndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesD6_DayDamage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesD6_DayDamageDetail",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    PrvId = table.Column<int>(type: "int", nullable: true),
                    BeginDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HvId = table.Column<int>(type: "int", nullable: true),
                    HvNo = table.Column<int>(type: "int", nullable: true),
                    ElamDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalAdamKhesaratSarneshin = table.Column<int>(type: "int", nullable: true),
                    SalAdamKhesaratJani = table.Column<int>(type: "int", nullable: true),
                    SalAdamKhesaratMali = table.Column<int>(type: "int", nullable: true),
                    PrmAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HvAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DamagedType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverId = table.Column<int>(type: "int", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverTypeId = table.Column<int>(type: "int", nullable: true),
                    DriverTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovahiTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HvGirandeId = table.Column<int>(type: "int", nullable: true),
                    HvGirandeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HvGirandeNationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HvGirandeHvAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MoredEstefadeId = table.Column<int>(type: "int", nullable: true),
                    MoredEstefadeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarGroupId = table.Column<int>(type: "int", nullable: true),
                    CarGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarKindId = table.Column<int>(type: "int", nullable: true),
                    CarKindName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarModel = table.Column<int>(type: "int", nullable: true),
                    Pelak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PelakKindId = table.Column<int>(type: "int", nullable: true),
                    PelakKindName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DmgMored = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesD6_DayDamageDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesD7_InstallmentWithHv",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrmSrdId = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    ReshteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SodurId = table.Column<int>(type: "int", nullable: false),
                    SodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayerCustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SrdDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SrdDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActiveId = table.Column<int>(type: "int", nullable: false),
                    TasvieType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SrdAmountAsRial = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TasvieAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Mande = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TasvieNashode = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VosulShode = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AmaliatTasvieType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrvDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HadeseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HadeseDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ElamDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElamDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrvNo = table.Column<int>(type: "int", nullable: true),
                    HvAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VslStateDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VslStateDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsNaghdiId = table.Column<int>(type: "int", nullable: true),
                    DeliverDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliverDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RcvdKindId = table.Column<int>(type: "int", nullable: true),
                    RcvdKindName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VslStateId = table.Column<int>(type: "int", nullable: true),
                    VslStateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesD7_InstallmentWithHv", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesP1_LessPishPardakht",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaliBid = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    SodurGid = table.Column<int>(type: "int", nullable: true),
                    PersonkindId = table.Column<int>(type: "int", nullable: false),
                    PersonkindName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhestAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrmAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesP1_LessPishPardakht", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesP2_AghsatGreater6",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaliBid = table.Column<int>(type: "int", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FvsodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaresidDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesP2_AghsatGreater6", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesP3_PelakSodurDateDiscount",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    PelakDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PelakDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VsodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnsodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnsodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDifference = table.Column<int>(type: "int", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesP3_PelakSodurDateDiscount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesP4_MalekCustomer",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: false),
                    VsodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VsodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerPerson = table.Column<int>(type: "int", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerNationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeMelli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElhNo = table.Column<int>(type: "int", nullable: false),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesP4_MalekCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesP5_TroubledCustomer",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: false),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonkindId = table.Column<int>(type: "int", nullable: false),
                    PersonKindText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeMelli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePosti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesP5_TroubledCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesP6_TroubledKhodro",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: false),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhodroId = table.Column<int>(type: "int", nullable: false),
                    ShasiNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PelakNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotorNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesP6_TroubledKhodro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesP7_SalSahkhtSanavatDiscount",
                schema: "cr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Bno = table.Column<int>(type: "int", nullable: false),
                    BnSodurDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurDateMiladi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalSakhtMiladi = table.Column<int>(type: "int", nullable: false),
                    SalSakhtShamsi = table.Column<int>(type: "int", nullable: false),
                    TafavotSal = table.Column<int>(type: "int", nullable: false),
                    SabegheId = table.Column<int>(type: "int", nullable: true),
                    SabegheTypeId = table.Column<int>(type: "int", nullable: true),
                    SabegheTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sal = table.Column<int>(type: "int", nullable: true),
                    SabeghJaniName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationalcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    AgentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnSodurId = table.Column<int>(type: "int", nullable: false),
                    BnSodurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesP7_SalSahkhtSanavatDiscount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpResultTest",
                columns: table => new
                {
                    Status = table.Column<int>(type: "int", nullable: false),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusCnt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tblPermission",
                schema: "cmn",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPermission", x => x.PermissionId);
                    table.ForeignKey(
                        name: "FK_tblPermission_tblPermission_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "cmn",
                        principalTable: "tblPermission",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPrvStatus",
                schema: "cmn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPrvStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRevenueChart",
                schema: "cmn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BnCnt = table.Column<int>(type: "int", nullable: true),
                    DmgCnt = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRevenueChart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRole",
                schema: "cmn",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRole", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                schema: "cmn",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ActiveCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserAvatar = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "tblRolePermission",
                schema: "cmn",
                columns: table => new
                {
                    RP_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRolePermission", x => x.RP_Id);
                    table.ForeignKey(
                        name: "FK_tblRolePermission_tblPermission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "cmn",
                        principalTable: "tblPermission",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblRolePermission_tblRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "cmn",
                        principalTable: "tblRole",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblUserRole",
                schema: "cmn",
                columns: table => new
                {
                    Ur_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserRole", x => x.Ur_Id);
                    table.ForeignKey(
                        name: "FK_tblUserRole_tblRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "cmn",
                        principalTable: "tblRole",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblUserRole_tblUser_UserId",
                        column: x => x.UserId,
                        principalSchema: "cmn",
                        principalTable: "tblUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPermission_ParentId",
                schema: "cmn",
                table: "tblPermission",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRolePermission_PermissionId",
                schema: "cmn",
                table: "tblRolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRolePermission_RoleId",
                schema: "cmn",
                table: "tblRolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRole_RoleId",
                schema: "cmn",
                table: "tblUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserRole_UserId",
                schema: "cmn",
                table: "tblUserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BdD1_Karbari",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "BdD2_Franshiz",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "BdD3_GovahiCarType",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "BdD4_Estehlak",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "BdD5_CarAmount",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "BdD6_DayDamage",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "BdD7_InstallmentWithHv",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "BdP1_206Pushesh",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "BdP3_NewCarDiscount",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "BdP4_TroubledCustomer",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "BdP5_TroubledKhodro",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "DimSabegheSalesKind",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "FireP01_TroubledCodePosti",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP03_BnNoLastPolicyId",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP04_TafkikList",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP06_AfzayeshSarmaye",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP07_AnbarBazdid",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP08_AsaBazdid",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP09_MaskanBazdid",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP10_GheirSanatiBazdidOver10",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP11_GheirSanatiBazdidOver80",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP12_AnbarBazdidOver10",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP13_SanatiBazdidOver20",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP14_SanatiAnbarBazdidSpecialGroup",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP15_BazdidSpecialGroupOver30",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP16_SerghatBazdidOver700",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP17_SpecialGroupBazdid",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP18_DamagedBazdid",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP19_MinPrm",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP21_CashPrmBn",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "FireP23_CashPrmElh",
                schema: "fr");

            migrationBuilder.DropTable(
                name: "ReportFromAllTable",
                schema: "cmn");

            migrationBuilder.DropTable(
                name: "SalesD1_Karbari",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesD2_BazyaftNotTasvie",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesD2_BazyaftTasvieStatus",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesD2_TakhalofHadeseSaz",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesD3_GovahiCarType",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesD6_DayDamage",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesD6_DayDamageDetail",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesD7_InstallmentWithHv",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesP1_LessPishPardakht",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesP2_AghsatGreater6",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesP3_PelakSodurDateDiscount",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesP4_MalekCustomer",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesP5_TroubledCustomer",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesP6_TroubledKhodro",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SalesP7_SalSahkhtSanavatDiscount",
                schema: "cr");

            migrationBuilder.DropTable(
                name: "SpResultTest");

            migrationBuilder.DropTable(
                name: "tblPrvStatus",
                schema: "cmn");

            migrationBuilder.DropTable(
                name: "tblRevenueChart",
                schema: "cmn");

            migrationBuilder.DropTable(
                name: "tblRolePermission",
                schema: "cmn");

            migrationBuilder.DropTable(
                name: "tblUserRole",
                schema: "cmn");

            migrationBuilder.DropTable(
                name: "tblPermission",
                schema: "cmn");

            migrationBuilder.DropTable(
                name: "tblRole",
                schema: "cmn");

            migrationBuilder.DropTable(
                name: "tblUser",
                schema: "cmn");
        }
    }
}
