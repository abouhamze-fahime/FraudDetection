using Fraud.Entities;
using Fraud.Entities.Acount;
using Fraud.Entities.Car;
using Fraud.Entities.Common;
using Fraud.Entities.Permission;
using Fraud.Entities.Test;


using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraud.Context
{
   public class AppDbContext:DbContext  //abstract Class
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) //دادن تنظیمات به کلاس پدر
        {

        }

        #region User Tables 
        public DbSet<Permission> tblPermission { get; set; }
        public DbSet<Role> tblRole { get; set; }
        public DbSet<UserRole> tblUserRole { get; set; }
        public DbSet<User> tblUser { get; set; }
        public DbSet<RolePermission> tblRolePermission { get; set; }
        public virtual DbSet<PrvStatus> tblPrvStatus { get; set; }
        #endregion

        #region car
        public virtual DbSet<BdD1Karbari> BdD1_Karbari { get; set; }
        public virtual DbSet<BdD2Franshiz> BdD2_Franshiz { get; set; }
        public virtual DbSet<BdD3GovahiCarType> BdD3_GovahiCarType { get; set; }
        public virtual DbSet<BdD4Estehlak> BdD4_Estehlak { get; set; }
        public virtual DbSet<BdD5CarAmount> BdD5_CarAmount { get; set; }
        public virtual DbSet<BdD6DayDamage> BdD6_DayDamage { get; set; }
        public virtual DbSet<BdD7InstallmentWithHv> BdD7_InstallmentWithHv { get; set; }
        public virtual DbSet<BdP1206pushesh> BdP1_206Pushesh { get; set; }
        public virtual DbSet<BdP3NewCarDiscount> BdP3_NewCarDiscount { get; set; }
        public virtual DbSet<DimSabegheSalesKind> DimSabegheSalesKind { get; set; }
        public virtual DbSet<SalesD1Karbari> SalesD1_Karbari { get; set; }
        public virtual DbSet<SalesD2BazyaftNotTasvie> SalesD2_BazyaftNotTasvie { get; set; }
        public virtual DbSet<SalesD2BazyaftTasvieStatus> SalesD2_BazyaftTasvieStatus { get; set; }
        public virtual DbSet<SalesD2TakhalofHadeseSaz> SalesD2_TakhalofHadeseSaz { get; set; }
        public virtual DbSet<SalesD3GovahiCarType> SalesD3_GovahiCarType { get; set; }
        public virtual DbSet<SalesD6DayDamage> SalesD6_DayDamage { get; set; }
        public virtual DbSet<SalesD6DayDamageDetail> SalesD6_DayDamageDetail { get; set; }
        public virtual DbSet<SalesD7InstallmentWithHv> SalesD7_InstallmentWithHv { get; set; }
        public virtual DbSet<SalesP1LessPishPardakht> SalesP1_LessPishPardakht { get; set; }
        public virtual DbSet<SalesP2AghsatGreater6> SalesP2_AghsatGreater6 { get; set; }
        public virtual DbSet<SalesP3PelakSodurDateDiscount> SalesP3_PelakSodurDateDiscount { get; set; }
        public virtual DbSet<SalesP4MalekCustomer> SalesP4_MalekCustomer { get; set; }
        public virtual DbSet<SalesP7SalSahkhtSanavatDiscount> SalesP7_SalSahkhtSanavatDiscount { get; set; }
        public virtual DbSet<BdP4TroubledCustomer> BdP4_TroubledCustomer { get; set; }
        public virtual DbSet<BdP5TroubledKhodro> BdP5_TroubledKhodro { get; set; }
        public virtual DbSet<SalesP5TroubledCustomer> SalesP5_TroubledCustomer { get; set; }
        public virtual DbSet<SalesP6TroubledKhodro> SalesP6_TroubledKhodro { get; set; }
        public virtual DbSet<ResultTest> SpResultTest { get; set; }



        public DbSet<MiniRepo> ReportFromAllTable { get; set; }
        public DbSet<RevenueChart> tblRevenueChart { get; set; }



        public virtual DbSet<FireP01TroubledCodePosti> FireP01_TroubledCodePosti { get; set; }
        public virtual DbSet<FireP03BnNoLastPolicyId> FireP03_BnNoLastPolicyId { get; set; }
        public virtual DbSet<FireP04TafkikList> FireP04_TafkikList { get; set; }
        public virtual DbSet<FireP06AfzayeshSarmaye> FireP06_AfzayeshSarmaye { get; set; }
        public virtual DbSet<FireP07AnbarBazdid> FireP07_AnbarBazdid { get; set; }
        public virtual DbSet<FireP08AsaBazdid> FireP08_AsaBazdid { get; set; }
        public virtual DbSet<FireP09MaskanBazdid> FireP09_MaskanBazdid { get; set; }
        public virtual DbSet<FireP10GheirSanatiBazdidOver10> FireP10_GheirSanatiBazdidOver10 { get; set; }
        public virtual DbSet<FireP11GheirSanatiBazdidOver80> FireP11_GheirSanatiBazdidOver80 { get; set; }
        public virtual DbSet<FireP12AnbarBazdidOver10> FireP12_AnbarBazdidOver10 { get; set; }
        public virtual DbSet<FireP13SanatiBazdidOver20> FireP13_SanatiBazdidOver20 { get; set; }
        public virtual DbSet<FireP14SanatiAnbarBazdidSpecialGroup> FireP14_SanatiAnbarBazdidSpecialGroup { get; set; }
        public virtual DbSet<FireP15BazdidSpecialGroupOver30> FireP15_BazdidSpecialGroupOver30 { get; set; }
        public virtual DbSet<FireP16SerghatBazdidOver700> FireP16_SerghatBazdidOver700 { get; set; }
        public virtual DbSet<FireP17SpecialGroupBazdid> FireP17_SpecialGroupBazdid { get; set; }
        public virtual DbSet<FireP18DamagedBazdid> FireP18_DamagedBazdid { get; set; }
        public virtual DbSet<FireP19MinPrm> FireP19_MinPrm { get; set; }
        public virtual DbSet<FireP21CashPrmBn> FireP21_CashPrmBn { get; set; }
        public virtual DbSet<FireP23CashPrmElh> FireP23_CashPrmElh { get; set; }





        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDelete);
            base.OnModelCreating(modelBuilder);
        }
    }

}
