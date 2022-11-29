using Fraud.Entities.Car;
using Fraud.Models.Car;
using Fraud.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using Fraud.Context;
using Microsoft.EntityFrameworkCore;
using Fraud.Entities.Test;
using Fraud.Models.Common;

namespace Fraud.Services
{
    public class Services : IServices
    {
        //    FruddataContext context = new FruddataContext();
        private AppDbContext _context;
        public Services(AppDbContext context)
        {
            _context = context;
        }
        //public int GetListCount()
        //{
        //    int cnt = context.CarFirst.Count();

        //    return cnt;
        //}
        //public List<Pager> GetPolicyPaging(int pageNumber, int PageSize)
        //{
        //    throw new NotImplementedException();
        //}
        #region Car

        #region Third Party 

        #region Policy

        /// <summary>
        /// شاخص یک صدور بیمه نامه ثالث: 
        /// مبلغ پیش پرداخت بیمه نامه - کل حق بیمه 
        /// </summary>
        /// <returns></returns>
        public IQueryable<SalesP1LessPishPardakhtViewModel> GetSalesP1LessPishPardakht()
        {
            var res = from a in _context.SalesP1_LessPishPardakht
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new SalesP1LessPishPardakhtViewModel
                      {
                          Id = a.Id,
                          MaliBid = a.MaliBid,
                          PolicyId = a.PolicyId,
                          SodurGid = a.SodurGid,
                          PersonkindName = a.PersonkindName,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentName = a.AgentName,
                          BnSodurName = a.BnSodurName,
                          BranchName = a.BranchName,
                          GhestAmount = a.GhestAmount,
                          PrmAmount = a.PrmAmount,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          StatusName = b.StatusName
                      };
            return res;
        }

        public SalesP1LessPishPardakhtViewModel OpenRecordSalesP1LessPishPardakht(int? id)
        {
            var obj = (from a in _context.SalesP1_LessPishPardakht
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new SalesP1LessPishPardakhtViewModel
                       {
                           Id = a.Id,
                           MaliBid = a.MaliBid,
                           PolicyId = a.PolicyId,
                           SodurGid = a.SodurGid,
                           PersonkindName = a.PersonkindName,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentName = a.AgentName,
                           BnSodurName = a.BnSodurName,
                           BranchName = a.BranchName,
                           GhestAmount = a.GhestAmount,
                           PrmAmount = a.PrmAmount,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public SalesP1LessPishPardakht UpdateSalesP1LessPishPardakht(string comment, int id, int statusId)
        {
            var obj = (from a in _context.SalesP1_LessPishPardakht
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص دو  صدور بیمه نامه ثالث: 
        /// شرایط اعلام بدهکار بیمه نامه 
        /// </summary>
        /// <returns></returns>

        public IQueryable<SalesP2AghsatGreater6ViewModel> GetSalesP2AghsatGreater6()
        {
            return from a in _context.SalesP2_AghsatGreater6
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new SalesP2AghsatGreater6ViewModel
                   {
                       Id = a.Id,
                       MaliBid = a.MaliBid,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       BnSodurDate = a.BnSodurDate,
                       BnDateMiladi = a.BnDateMiladi,
                       CustomerName = a.CustomerName,
                       Nationalcode = a.Nationalcode,
                       CompanyCode = a.CompanyCode,
                       AgentName = a.AgentName,
                       BnSodurName = a.BnSodurName,
                       BranchName = a.BranchName,
                       FvsodurDate = a.FvsodurDate,
                       SaresidDate = a.SaresidDate,
                       UserName = a.UserName,
                       Comment = a.Comment,
                       Status = a.Status,
                       StatusName = b.StatusName
                   };
        }

        public SalesP2AghsatGreater6ViewModel OpenRecordSalesP2AghsatGreater6(int? id)
        {
            var obj = (from a in _context.SalesP2_AghsatGreater6
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new SalesP2AghsatGreater6ViewModel
                       {
                           Id = a.Id,
                           MaliBid = a.MaliBid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           BnSodurDate = a.BnSodurDate,
                           BnDateMiladi = a.BnDateMiladi,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           CompanyCode = a.CompanyCode,
                           AgentName = a.AgentName,
                           BnSodurName = a.BnSodurName,
                           BranchName = a.BranchName,
                           FvsodurDate = a.FvsodurDate,
                           SaresidDate = a.SaresidDate,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public SalesP2AghsatGreater6 UpdateSalesP2AghsatGreater6(string comment, int id, int statusId)
        {
            var obj = (from a in _context.SalesP2_AghsatGreater6
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص سه  صدور بیمه نامه ثالث: 
        /// تخفیفات بیمه نامه - تاریخ شماره گذاری - تاریخ شروع بیمه نامه 
        /// </summary>
        /// <returns></returns>
        /// 

        public IQueryable<SalesP3PelakSodurDateDiscountViewModel> GetSalesP3PelakSodurDateDiscount()
        {
            return from a in _context.SalesP3_PelakSodurDateDiscount
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new SalesP3PelakSodurDateDiscountViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       ElhNo = a.ElhNo,
                       PelakDate = a.PelakDate,
                       PelakDateMiladi = a.PelakDateMiladi,
                       VsodurDate = a.VsodurDate,
                       BnsodurDate = a.BnsodurDate,
                       BnsodurDateMiladi = a.BnsodurDateMiladi,
                       DateDifference = a.DateDifference,
                       CustomerName = a.CustomerName,
                       Nationalcode = a.Nationalcode,
                       CompanyCode = a.CompanyCode,
                       AgentName = a.AgentName,
                       BnSodurName = a.BnSodurName,
                       BranchName = a.BranchName,
                       UserName = a.UserName,
                       Comment = a.Comment,
                       Status = a.Status,
                       StatusName = b.StatusName
                   };
        }

        public SalesP3PelakSodurDateDiscountViewModel OpenRecordSalesP3PelakSodurDateDiscount(int? id)
        {

            var obj = (from a in _context.SalesP3_PelakSodurDateDiscount
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new SalesP3PelakSodurDateDiscountViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           PelakDate = a.PelakDate,
                           PelakDateMiladi = a.PelakDateMiladi,
                           VsodurDate = a.VsodurDate,
                           BnsodurDate = a.BnsodurDate,
                           BnsodurDateMiladi = a.BnsodurDateMiladi,
                           DateDifference = a.DateDifference,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           CompanyCode = a.CompanyCode,
                           AgentName = a.AgentName,
                           BnSodurName = a.BnSodurName,
                           BranchName = a.BranchName,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public SalesP3PelakSodurDateDiscount UpdateSalesP3PelakSodurDateDiscount(string comment, int id, int statusId)
        {
            var obj = (from a in _context.SalesP3_PelakSodurDateDiscount
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص 4  صدور بیمه نامه ثالث: 
        /// تخفیفات بیمه نامه - تاریخ شماره گذاری - تاریخ شروع بیمه نامه 
        /// </summary>
        /// <returns></returns>
        /// 

        public IQueryable<SalesP4MalekCustomerViewModel> GetSalesP4MalekCustomer()
        {
            return from a in _context.SalesP4_MalekCustomer
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new SalesP4MalekCustomerViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       VsodurDate = a.VsodurDate,
                       VsodurDateMiladi = a.VsodurDateMiladi,
                       OwnerPerson = a.OwnerPerson,
                       OwnerName = a.OwnerName,
                       OwnerNationalCode = a.OwnerNationalCode,
                       CustomerId = a.CustomerId,
                       CustomerName = a.CustomerName,
                       CodeMelli = a.CodeMelli,
                       ElhNo = a.ElhNo,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       BnSodurId = a.BnSodurId,
                       BnSodurName = a.BnSodurName,
                       BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       UserId = a.UserId,
                       UserName = a.UserName,
                       Status = a.Status,
                       StatusName = b.StatusName,
                       Comment = a.Comment

                   };
        }

        public SalesP4MalekCustomerViewModel OpenRecordSalesP4MalekCustomer(int? id)
        {

            var obj = (from a in _context.SalesP4_MalekCustomer
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new SalesP4MalekCustomerViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           VsodurDate = a.VsodurDate,
                           VsodurDateMiladi = a.VsodurDateMiladi,
                           OwnerPerson = a.OwnerPerson,
                           OwnerName = a.OwnerName,
                           OwnerNationalCode = a.OwnerNationalCode,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           CodeMelli = a.CodeMelli,
                           ElhNo = a.ElhNo,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Status = a.Status,
                           StatusName = b.StatusName,
                           Comment = a.Comment
                       }).FirstOrDefault();

            return obj;
        }

        public SalesP4MalekCustomer UpdateSalesP4MalekCustomer(string comment, int id, int statusId)
        {
            var obj = (from a in _context.SalesP4_MalekCustomer
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }
        /// <summary>
        /// شاخص 5 ثالث  : اشخاص با اطلاعات ناقص   
        /// </summary>
        /// <returns></returns>
        public IQueryable<SalesP5TroubledCustomerViewModel> GetSalesP5TroubledCustomer()
        {
            var res = from a in _context.SalesP5_TroubledCustomer
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new SalesP5TroubledCustomerViewModel
                      {
                          Id = a.Id,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          AgentCode = a.AgentCode,
                          AgentName = a.AgentName,
                          BnSodurId = a.BnSodurId,
                          BnSodurName = a.BnSodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          PersonkindId = a.PersonkindId,
                          PersonKindText = a.PersonKindText,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          CodeMelli = a.CodeMelli,
                          CodePosti = a.CodePosti,
                          Address = a.Address,
                          Mobile = a.Mobile,
                          Comment = a.Comment,
                          Status = a.Status,
                          StatusName = b.StatusName
                      };
            return res;
        }

        public SalesP5TroubledCustomerViewModel OpenRecordSalesP5TroubledCustomer(int? id)
        {
            var obj = (from a in _context.SalesP5_TroubledCustomer
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new SalesP5TroubledCustomerViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           PersonkindId = a.PersonkindId,
                           PersonKindText = a.PersonKindText,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           CodeMelli = a.CodeMelli,
                           CodePosti = a.CodePosti,
                           Address = a.Address,
                           Mobile = a.Mobile,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public SalesP5TroubledCustomer UpdateSalesP5TroubledCustomer(string comment, int id, int statusId)
        {
            var obj = (from a in _context.SalesP5_TroubledCustomer
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص 6 ثالث : خودرو با اطلاعات ناقص   
        /// </summary>
        /// <returns></returns>

        public IQueryable<SalesP6TroubledKhodroViewModel> GetSalesP6TroubledKhodro()
        {
            return from a in _context.SalesP6_TroubledKhodro
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new SalesP6TroubledKhodroViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       BnSodurId = a.BnSodurId,
                       BnSodurName = a.BnSodurName,
                       BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       KhodroId = a.KhodroId,
                       ShasiNo = a.ShasiNo,
                       PelakNo = a.PelakNo,
                       Vin = a.Vin,
                       MotorNo = a.MotorNo,
                       UserId = a.UserId,
                       UserName = a.UserName,
                       Comment = a.Comment,
                       Status = a.Status,
                       StatusName = b.StatusName
                   };
        }

        public SalesP6TroubledKhodroViewModel OpenRecordSalesP6TroubledKhodro(int? id)
        {
            var obj = (from a in _context.SalesP6_TroubledKhodro
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new SalesP6TroubledKhodroViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           KhodroId = a.KhodroId,
                           ShasiNo = a.ShasiNo,
                           PelakNo = a.PelakNo,
                           Vin = a.Vin,
                           MotorNo = a.MotorNo,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public SalesP6TroubledKhodro UpdateSalesP6TroubledKhodro(string comment, int id, int statusId)
        {
            var obj = (from a in _context.SalesP6_TroubledKhodro
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص هفت  صدور بیمه نامه ثالث: 
        /// سال ساخت خودرو - سال تخفیف سنواتی اعمال شده
        /// </summary>
        /// <returns></returns>
        /// 
        public IQueryable<SalesP7SalSahkhtSanavatDiscountViewModel> GetSalesP7SalSahkhtSanavatDiscount()
        {
            return from a in _context.SalesP7_SalSahkhtSanavatDiscount
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new SalesP7SalSahkhtSanavatDiscountViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       BnSodurDate = a.BnSodurDate,
                       BnSodurDateMiladi = a.BnSodurDateMiladi,
                       SalSakhtMiladi = a.SalSakhtMiladi,
                       SalSakhtShamsi = a.SalSakhtShamsi,
                       TafavotSal = a.TafavotSal,
                       SabegheId = a.SabegheId,
                       SabegheTypeId = a.SabegheTypeId,
                       SabegheTypeName = a.SabegheTypeName,
                       Sal = a.Sal,
                       SabeghJaniName = a.SabeghJaniName,
                       CustomerId = a.CustomerId,
                       CustomerName = a.CustomerName,
                       Nationalcode = a.Nationalcode,
                       CompanyCode = a.CompanyCode,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       BnSodurId = a.BnSodurId,
                       BnSodurName = a.BnSodurName,
                       BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       UserId = a.UserId,
                       UserName = a.UserName,
                       Comment = a.Comment,
                       Status = a.Status,
                       StatusName = b.StatusName
                   };
        }

        public SalesP7SalSahkhtSanavatDiscountViewModel OpenRecordSalesP7SalSahkhtSanavatDiscount(int? id)
        {
            var obj = (from a in _context.SalesP7_SalSahkhtSanavatDiscount
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new SalesP7SalSahkhtSanavatDiscountViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           SalSakhtMiladi = a.SalSakhtMiladi,
                           SalSakhtShamsi = a.SalSakhtShamsi,
                           TafavotSal = a.TafavotSal,
                           SabegheId = a.SabegheId,
                           SabegheTypeId = a.SabegheTypeId,
                           SabegheTypeName = a.SabegheTypeName,
                           Sal = a.Sal,
                           SabeghJaniName = a.SabeghJaniName,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           CompanyCode = a.CompanyCode,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public SalesP7SalSahkhtSanavatDiscount UpdateSalesP7SalSahkhtSanavatDiscount(string comment, int id, int statusId)
        {
            var obj = (from a in _context.SalesP7_SalSahkhtSanavatDiscount
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        #endregion

        #region Damage

        /// <summary>
        /// شاخص یک : کاربری وسیله نقلیه 
        /// </summary>
        /// <returns></returns>

        public IQueryable<SalesD1KarbariViewModel> GetSalesD1Karbari()
        {
            return from a in _context.SalesD1_Karbari
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new SalesD1KarbariViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       PrvNo = a.PrvNo,
                       PrvDate = a.PrvDate,
                       Bno = a.Bno,
                       BeginDate = a.BeginDate,
                       BeginDateMiladi = a.BeginDateMiladi,
                       EndDate = a.EndDate,
                       EndDateMiladi = a.EndDateMiladi,
                       HadeseDate = a.HadeseDate,
                       HadeseDateMiladi = a.HadeseDateMiladi,
                       HadeseAddress = a.HadeseAddress,
                       ElatHadeseName = a.ElatHadeseName,
                       GovahiTypeName = a.GovahiTypeName,
                       MoredEstefadeName = a.MoredEstefadeName,
                       KhodroListId = a.KhodroListId,
                       KhodroKindName = a.KhodroKindName,
                       DamageSodurName = a.DamageSodurName,
                       BranchName = a.BranchName,
                       UserName = a.UserName,
                       SumHvPayAmountAsRial = a.SumHvPayAmountAsRial,
                       DamageType = a.DamageType,
                       Status = a.Status,
                       StatusName = b.StatusName,
                       Comment = a.Comment
                   };
        }
        public SalesD1KarbariViewModel OpenRecordSalesD1Karbari(int? id)
        {
            var obj = (from a in _context.SalesD1_Karbari
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new SalesD1KarbariViewModel
                       {
                           PolicyId = a.PolicyId,
                           PrvNo = a.PrvNo,
                           PrvDate = a.PrvDate,
                           Bno = a.Bno,
                           BeginDate = a.BeginDate,
                           BeginDateMiladi = a.BeginDateMiladi,
                           EndDate = a.EndDate,
                           EndDateMiladi = a.EndDateMiladi,
                           HadeseDate = a.HadeseDate,
                           HadeseDateMiladi = a.HadeseDateMiladi,
                           HadeseAddress = a.HadeseAddress,
                           ElatHadeseName = a.ElatHadeseName,
                           GovahiTypeName = a.GovahiTypeName,
                           MoredEstefadeName = a.MoredEstefadeName,
                           KhodroListId = a.KhodroListId,
                           KhodroKindName = a.KhodroKindName,
                           DamageSodurName = a.DamageSodurName,
                           BranchName = a.BranchName,
                           UserName = a.UserName,
                           SumHvPayAmountAsRial = a.SumHvPayAmountAsRial,
                           DamageType = a.DamageType,
                           Status = a.Status,
                           StatusName = b.StatusName,
                           Comment = a.Comment
                       }).FirstOrDefault();

            return obj;

        }
        public SalesD1Karbari UpdateSalesD1Karbari(string comment, int id, int statusId)
        {
            var obj = (from a in _context.SalesD1_Karbari
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;

        }

        /// <summary>
        /// شاخص دو:
        /// نوع حادثه - تخلف ساز 
        /// </summary>
        /// <returns></returns>
        /// 

        public IQueryable<SalesD2TakhalofHadeseSazViewModel> GetSalesD2TakhalofHadeseSaz()
        {
            return from a in _context.SalesD2_TakhalofHadeseSaz
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new SalesD2TakhalofHadeseSazViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       BnSodurDate = a.BnSodurDate,
                       BnSodurDateMiladi = a.BnSodurDateMiladi,
                       CustomerName = a.CustomerName,
                       Nationalcode = a.Nationalcode,
                       CompanyCode = a.CompanyCode,
                       PrvId = a.PrvId,
                       PrvNo = a.PrvNo,
                       //     ElatHadeseId = a.ElatHadeseId,
                       ElatHadeseName = a.ElatHadeseName,
                       PrvDate = a.PrvDate,
                       PrvDateMiladi = a.PrvDateMiladi,
                       HadeseDate = a.HadeseDate,
                       HadeseDateMiladi = a.HadeseDateMiladi,
                       //      AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       //      BnSodurId = a.BnSodurId,
                       BnSodurName = a.BnSodurName,
                       //   PrvSodurId = a.PrvSodurId,
                       PrvSodurName = a.PrvSodurName,
                       //      BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       Status = a.Status,
                       StatusName = b.StatusName,
                       Comment = a.Comment
                   };
        }

        public SalesD2TakhalofHadeseSazViewModel OpenRecordSalesD2TakhalofHadeseSaz(int? id)
        {
            var obj = (from a in _context.SalesD2_TakhalofHadeseSaz
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new SalesD2TakhalofHadeseSazViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           CompanyCode = a.CompanyCode,
                           PrvId = a.PrvId,
                           PrvNo = a.PrvNo,
                           ElatHadeseId = a.ElatHadeseId,
                           ElatHadeseName = a.ElatHadeseName,
                           PrvDate = a.PrvDate,
                           PrvDateMiladi = a.PrvDateMiladi,
                           HadeseDate = a.HadeseDate,
                           HadeseDateMiladi = a.HadeseDateMiladi,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           PrvSodurId = a.PrvSodurId,
                           PrvSodurName = a.PrvSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           StatusName = b.StatusName,
                           Comment = a.Comment


                       }).FirstOrDefault();

            return obj;
        }

        public SalesD2TakhalofHadeseSaz UpdateSalesD2TakhalofHadeseSaz(string comment, int id, int statusId)
        {
            var obj = (from a in _context.SalesD2_TakhalofHadeseSaz
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص دو:
        /// تخلف حادث ساز که تسویه نشده اند  
        /// </summary>
        /// <returns></returns>
        /// 



        public IQueryable<SalesD2BazyaftNotTasvieViewModel> GetSalesD2BazyaftNotTasvie()
        {
            return from a in _context.SalesD2_BazyaftNotTasvie
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new SalesD2BazyaftNotTasvieViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       BnSodurDate = a.BnSodurDate,
                       BnSodurDateMiladi = a.BnSodurDateMiladi,
                       CustomerName = a.CustomerName,
                       Nationalcode = a.Nationalcode,
                       CompanyCode = a.CompanyCode,
                       PrvId = a.PrvId,
                       PrvNo = a.PrvNo,
                       ElatHadeseId = a.ElatHadeseId,
                       ElatHadeseName = a.ElatHadeseName,
                       HvgirandeId = a.HvgirandeId,
                       PrvDate = a.PrvDate,
                       PrvDateMiladi = a.PrvDateMiladi,
                       HadeseDate = a.HadeseDate,
                       HadeseDateMiladi = a.HadeseDateMiladi,
                       Hvdate = a.Hvdate,
                       HvdateMiladi = a.HvdateMiladi,
                       Hvid = a.Hvid,
                       Hvno = a.Hvno,
                       HvamountAsRial = a.HvamountAsRial,
                       HvgusableAmountAsRial = a.HvgusableAmountAsRial,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       BnSodurId = a.BnSodurId,
                       BnSodurName = a.BnSodurName,
                       PrvSodurId = a.PrvSodurId,
                       PrvSodurName = a.PrvSodurName,
                       BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       Status = a.Status,
                       StatusName = b.StatusName,
                       Comment = a.Comment
                   };
        }

        public SalesD2BazyaftNotTasvieViewModel OpenRecordSalesD2BazyaftNotTasvie(int? id)
        {
            var obj = (from a in _context.SalesD2_BazyaftNotTasvie
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new SalesD2BazyaftNotTasvieViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           CompanyCode = a.CompanyCode,
                           PrvId = a.PrvId,
                           PrvNo = a.PrvNo,
                           ElatHadeseId = a.ElatHadeseId,
                           ElatHadeseName = a.ElatHadeseName,
                           HvgirandeId = a.HvgirandeId,
                           PrvDate = a.PrvDate,
                           PrvDateMiladi = a.PrvDateMiladi,
                           HadeseDate = a.HadeseDate,
                           HadeseDateMiladi = a.HadeseDateMiladi,
                           Hvdate = a.Hvdate,
                           HvdateMiladi = a.HvdateMiladi,
                           Hvid = a.Hvid,
                           Hvno = a.Hvno,
                           HvamountAsRial = a.HvamountAsRial,
                           HvgusableAmountAsRial = a.HvgusableAmountAsRial,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           PrvSodurId = a.PrvSodurId,
                           PrvSodurName = a.PrvSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           StatusName = b.StatusName,
                           Comment = a.Comment,
                           CreateDate = a.CreateDate,
                       }).FirstOrDefault();

            return obj;
        }

        public SalesD2BazyaftNotTasvie UpdateSalesD2BazyaftNotTasvie(string comment, int id, int statusId)
        {
            var obj = (from a in _context.SalesD2_BazyaftNotTasvie
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص سه:
        /// نوع خودرو - نوع گواهی نامه  
        /// </summary>
        /// <returns></returns>
        /// 


        public IQueryable<SalesD3GovahiCarTypeViewModel> GetSalesD3GovahiCarType()
        {
            return from a in _context.SalesD3_GovahiCarType
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new SalesD3GovahiCarTypeViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       BnSodurDate = a.BnSodurDate,
                       BnSodurDateMiladi = a.BnSodurDateMiladi,
                       GovahiType = a.GovahiType,
                       GovahiTypeId = a.GovahiTypeId,
                       GovahiTypeName = a.GovahiTypeName,
                       KhodroGoruhId = a.KhodroGoruhId,
                       KhodroGoruhName = a.KhodroGoruhName,
                       KhodroId = a.KhodroId,
                       KhodroKindCaption = a.KhodroKindCaption,
                       SarneshinCount = a.SarneshinCount,
                       Tonaje = a.Tonaje,
                       PrvId = a.PrvId,
                       PrvNo = a.PrvNo,
                       PrvDate = a.PrvDate,
                       PrvDateMiladi = a.PrvDateMiladi,
                       HadeseDate = a.HadeseDate,
                       HadeseDateMiladi = a.HadeseDateMiladi,
                       CustomerId = a.CustomerId,
                       CustomerName = a.CustomerName,
                       Nationalcode = a.Nationalcode,
                       CompanyCode = a.CompanyCode,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       BnSodurId = a.BnSodurId,
                       BnSodurName = a.BnSodurName,
                       BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       UserId = a.UserId,
                       UserName = a.UserName,
                       Comment = a.Comment,
                       StatusName = b.StatusName,
                       Status = a.Status

                   };
        }

        public SalesD3GovahiCarTypeViewModel OpenRecordSalesD3GovahiCarType(int? id)
        {
            var obj = (from a in _context.SalesD3_GovahiCarType
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new SalesD3GovahiCarTypeViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           GovahiType = a.GovahiType,
                           GovahiTypeId = a.GovahiTypeId,
                           GovahiTypeName = a.GovahiTypeName,
                           KhodroGoruhId = a.KhodroGoruhId,
                           KhodroGoruhName = a.KhodroGoruhName,
                           KhodroId = a.KhodroId,
                           KhodroKindCaption = a.KhodroKindCaption,
                           SarneshinCount = a.SarneshinCount,
                           Tonaje = a.Tonaje,
                           PrvId = a.PrvId,
                           PrvNo = a.PrvNo,
                           PrvDate = a.PrvDate,
                           PrvDateMiladi = a.PrvDateMiladi,
                           HadeseDate = a.HadeseDate,
                           HadeseDateMiladi = a.HadeseDateMiladi,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           CompanyCode = a.CompanyCode,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public SalesD3GovahiCarType UpdateSalesD3GovahiCarType(string comment, int id, int statusId)
        {
            var obj = (from a in _context.SalesD3_GovahiCarType
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص شش:
        ///تاریخ صدور بیمه نامه - تاریخ وقوع حادثه
        /// </summary>
        /// <returns></returns>
        /// 
        public IQueryable<SalesD6DayDamageViewModel> GetSalesD6DayDamage()
        {
            return from a in _context.SalesD6_DayDamage
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new SalesD6DayDamageViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       PrvId = a.PrvId,
                       PrvNo = a.PrvNo,
                       BnSodurDate = a.BnsodurDate,
                       SodurDateMiladi = a.SodurDateMiladi,
                       HadeseDate = a.HadeseDate,
                       HadeseDateMiladi = a.HadeseDateMiladi,
                       PrvDate = a.PrvDate,
                       PrvDateMiladi = a.PrvDateMiladi,
                       DateDifference = a.DateDifference,
                       CustomerName = a.CustomerName,
                       AgentName = a.AgentName,
                       SodurName = a.SodurName,
                       BranchName = a.BranchName,
                       BnUserName = a.BnUserName,
                       PrvUserName = a.PrvUserName,
                       DamageMoredName = a.DamageMoredName,
                       PrvSodurName = a.PrvSodurName,
                       ElatHadeseName = a.ElatHadeseName,
                       LastBnEndDate = a.LastBnEndDate,
                       Comment = a.Comment,
                       Status = a.Status,
                       StatusName = b.StatusName
                   };


        }
        public SalesD6DayDamageViewModel OpenRecordSalesD6DayDamage(int? id)
        {
            var obj = (from a in _context.SalesD6_DayDamage
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new SalesD6DayDamageViewModel
                       {
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           PrvId = a.PrvId,
                           PrvNo = a.PrvNo,
                           BnSodurDate = a.BnsodurDate,
                           SodurDateMiladi = a.SodurDateMiladi,
                           HadeseDate = a.HadeseDate,
                           HadeseDateMiladi = a.HadeseDateMiladi,
                           PrvDate = a.PrvDate,
                           PrvDateMiladi = a.PrvDateMiladi,
                           DateDifference = a.DateDifference,
                           CustomerName = a.CustomerName,
                           AgentName = a.AgentName,
                           SodurName = a.SodurName,
                           BranchName = a.BranchName,
                           BnUserName = a.BnUserName,
                           PrvUserName = a.PrvUserName,
                           DamageMoredId = a.DamageMoredId,
                           DamageMoredName = a.DamageMoredName,
                           PrvSodurName = a.PrvSodurName,
                           ElatHadeseName = a.ElatHadeseName,
                           LastBnEndDate = a.LastBnEndDate,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }
        public SalesD6DayDamage UpdateSalesD6DayDamage(string comment, int id, int statusId)
        {
            var obj = (from a in _context.SalesD6_DayDamage
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        public IQueryable<SalesD6DayDamageDetailViewModel> GetSalesD6DayDamageDetail(int policyId)
        {
            return from a in _context.SalesD6_DayDamageDetail
                   where a.PolicyId == policyId
                   select new SalesD6DayDamageDetailViewModel
                   {
                       PolicyId = a.PolicyId,
                       BeginDate = a.BeginDate,
                       EndDate = a.EndDate,
                       HvId = a.HvId,
                       HvNo = a.HvNo,
                       ElamDate = a.ElamDate,
                       HvDate = a.HvDate,
                       SalAdamKhesaratSarneshin = a.SalAdamKhesaratSarneshin,
                       SalAdamKhesaratJani = a.SalAdamKhesaratJani,
                       SalAdamKhesaratMali = a.SalAdamKhesaratMali,
                       PrmAmount = a.PrmAmount,
                       HvAmount = a.HvAmount,
                       DamagedType = a.DamagedType,
                       CustomerName = a.CustomerName,
                       DriverName = a.DriverName,
                       DriverTypeName = a.DriverTypeName,
                       GovahiTypeName = a.GovahiTypeName,
                       HvGirandeName = a.HvGirandeName,
                       HvGirandeNationalcode = a.HvGirandeNationalcode,
                       HvGirandeHvAmount = a.HvGirandeHvAmount,
                       MoredEstefadeName = a.MoredEstefadeName,
                       CarGroupName = a.CarGroupName,
                       CarKindName = a.CarKindName,
                       CarModel = a.CarModel,
                       Pelak = a.Pelak,
                       PelakKindName = a.PelakKindName
                   };
        }
        //public SalesD6DayDamage UpdateKPI2(SalesD6DayDamageViewModel sales)
        //{
        //    var obj = new SalesD6DayDamage();
        //    obj.Comment = sales.Comment;
        //    _context.SalesD6DayDamage.Update(obj);
        //    return obj;
        //}

        //public Sales15ViewModel OpenRecordSalesD6DayDamage(int? id)
        //{
        //    throw new NotImplementedException();
        //}

        //public SalesD6DayDamage UpdateSalesD6DayDamage(string comment, int id)
        //{
        //    throw new NotImplementedException();
        //}


        /// <summary>
        /// شاخص هفت:
        ///تاریخ اقساط - تاریخ واریزیها - تاریخ وقوع حادثه 
        /// </summary>
        /// <returns></returns>
        /// 

        public IQueryable<SalesD7InstallmentWithHvViewModel> GetSalesD7InstallmentWithHv()
        {
            return from a in _context.SalesD7_InstallmentWithHv
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new SalesD7InstallmentWithHvViewModel
                   {
                       Id = a.Id,
                       PrmSrdId = a.PrmSrdId,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       ElhNo = a.ElhNo,
                       ReshteName = a.ReshteName,
                       AgentName = a.AgentName,
                       SodurName = a.SodurName,
                       BranchName = a.BranchName,
                       CustomerName = a.CustomerName,
                       BeginDate = a.BeginDate,
                       BeginDateMiladi = a.BeginDateMiladi,
                       EndDate = a.EndDate,
                       EndDateMiladi = a.EndDateMiladi,
                       BnSodurDate = a.BnSodurDate,
                       BnSodurDateMiladi = a.BnSodurDateMiladi,
                       SrdDate = a.SrdDate,
                       SrdDateMiladi = a.SrdDateMiladi,
                       OpDate = a.OpDate,
                       OpDateMiladi = a.OpDateMiladi,
                       TasvieType = a.TasvieType,
                       SrdAmountAsRial = a.SrdAmountAsRial,
                       TasvieAmount = a.TasvieAmount,
                       AmaliatTasvieType = a.AmaliatTasvieType,
                       CreditType = a.CreditType,
                       PrvDate = a.PrvDate,
                       PrvDateMiladi = a.PrvDateMiladi,
                       HadeseDate = a.HadeseDate,
                       HadeseDateMiladi = a.HadeseDateMiladi,
                       ElamDate = a.ElamDate,
                       ElamDateMiladi = a.ElamDateMiladi,
                       PrvNo = a.PrvNo,
                       HvAmount = a.HvAmount,
                       VslStateDate = a.VslStateDate,
                       VslStateDateMiladi = a.VslStateDateMiladi,
                       IsNaghdiId = a.IsNaghdiId,
                       DeliverDate = a.DeliverDate,
                       DeliverDateMiladi = a.DeliverDateMiladi,
                       RcvdKindId = a.RcvdKindId,
                       RcvdKindName = a.RcvdKindName,
                       VslStateId = a.VslStateId,
                       VslStateName = a.VslStateName,
                       Comment = a.Comment,
                       Status = a.Status,
                       StatusName = b.StatusName

                   };
        }

        public SalesD7InstallmentWithHvViewModel OpenRecordSalesD7InstallmentWithHv(int? id)
        {
            var obj = (from a in _context.SalesD7_InstallmentWithHv
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       select new SalesD7InstallmentWithHvViewModel
                       {
                           Id = a.Id,
                           PrmSrdId = a.PrmSrdId,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           ReshteName = a.ReshteName,
                           AgentName = a.AgentName,
                           SodurName = a.SodurName,
                           BranchName = a.BranchName,
                           CustomerName = a.CustomerName,
                           BeginDate = a.BeginDate,
                           BeginDateMiladi = a.BeginDateMiladi,
                           EndDate = a.EndDate,
                           EndDateMiladi = a.EndDateMiladi,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           SrdDate = a.SrdDate,
                           SrdDateMiladi = a.SrdDateMiladi,
                           OpDate = a.OpDate,
                           OpDateMiladi = a.OpDateMiladi,
                           TasvieType = a.TasvieType,
                           SrdAmountAsRial = a.SrdAmountAsRial,
                           TasvieAmount = a.TasvieAmount,
                           AmaliatTasvieType = a.AmaliatTasvieType,
                           CreditType = a.CreditType,
                           PrvDate = a.PrvDate,
                           PrvDateMiladi = a.PrvDateMiladi,
                           HadeseDate = a.HadeseDate,
                           HadeseDateMiladi = a.HadeseDateMiladi,
                           ElamDate = a.ElamDate,
                           ElamDateMiladi = a.ElamDateMiladi,
                           PrvNo = a.PrvNo,
                           HvAmount = a.HvAmount,
                           VslStateDate = a.VslStateDate,
                           VslStateDateMiladi = a.VslStateDateMiladi,
                           IsNaghdiId = a.IsNaghdiId,
                           DeliverDate = a.DeliverDate,
                           DeliverDateMiladi = a.DeliverDateMiladi,
                           RcvdKindId = a.RcvdKindId,
                           RcvdKindName = a.RcvdKindName,
                           VslStateId = a.VslStateId,
                           VslStateName = a.VslStateName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public SalesD7InstallmentWithHv UpdateSalesD7InstallmentWithHv(string comment, int id, int statusId)
        {
            var obj = (from a in _context.SalesD7_InstallmentWithHv
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        #endregion

        #endregion

        #region Car Body 
        #region Policy
        /// <summary>
        /// شاخص شماره یک بدنه : نوع خودرو - سال ساخت خودرو  
        /// </summary>
        /// <returns></returns>
        public IQueryable<BdP1206pusheshViewModel> GetBdP1206pushesh()
        {
            try
            {
                var res = from a in _context.BdP1_206Pushesh
                          join b in _context.tblPrvStatus on a.Status equals b.Id
                          select new BdP1206pusheshViewModel
                          {
                              Id = a.Id,
                              PolicyId = a.PolicyId,
                              Bno = a.Bno,
                              KhodroName = a.KhodroName,
                              SalSakht = a.SalSakht,
                              SodurDate = a.SodurDate,
                              SodurDateMiladi = a.SodurDateMiladi,
                              ElhNo = a.ElhNo,
                              CustomerId = a.CustomerId,
                              CustomerName = a.CustomerName,
                              Nationalcode = a.Nationalcode,
                              CompanyCode = a.CompanyCode,
                              AgentCode = a.AgentCode,
                              AgentName = a.AgentName,
                              BnSodurId = a.BnSodurId,
                              BnSodurName = a.BnSodurName,
                              BranchId = a.BranchId,
                              BranchName = a.BranchName,
                              UserId = a.UserId,
                              UserName = a.UserName,
                              Comment = a.Comment,
                              StatusName = b.StatusName,
                              Status = a.Status
                          };

                return res;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public BdP1206pusheshViewModel OpenRecordBdP1206pushesh(int? id)
        {
            var obj = (from a in _context.BdP1_206Pushesh
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new BdP1206pusheshViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           KhodroName = a.KhodroName,
                           SalSakht = a.SalSakht,
                           SodurDate = a.SodurDate,
                           SodurDateMiladi = a.SodurDateMiladi,
                           ElhNo = a.ElhNo,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           CompanyCode = a.CompanyCode,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName,
                       }).FirstOrDefault();

            return obj;
        }

        public BdP1206pushesh UpdateBdP1206pushesh(string comment, int id, int statusId)
        {
            var obj = (from a in _context.BdP1_206Pushesh
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص شماره سه بدنه : تاریخ شماره گذاری - تاریخ آغاز بیمه نامه - تخفیف اعطا شده  
        /// </summary>
        /// <returns></returns>

        public IQueryable<BdP3NewCarDiscountViewModel> GetBdP3NewCarDiscount()
        {
            return from a in _context.BdP3_NewCarDiscount
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new BdP3NewCarDiscountViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       ElhNo = a.ElhNo,
                       BnsodurDate = a.BnsodurDate,
                       BnsodurDateMiladi = a.BnsodurDateMiladi,
                       PelakDate = a.PelakDate,
                       PelakDateMiladi = a.PelakDateMiladi,
                       SodurDate = a.SodurDate,
                       SodurDataMiladi = a.SodurDataMiladi,
                       TafavotPelakSodurDate = a.TafavotPelakSodurDate,
                       Nerkh = a.Nerkh,
                       PusheshEzafiNerkh = a.PusheshEzafiNerkh,
                       CustomerId = a.CustomerId,
                       CustomerName = a.CustomerName,
                       Nationalcode = a.Nationalcode,
                       CompanyCode = a.CompanyCode,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       BnSodurId = a.BnSodurId,
                       BnSodurName = a.BnSodurName,
                       BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       UserId = a.UserId,
                       UserName = a.UserName,
                       Comment = a.Comment,
                       StatusName = b.StatusName,
                       Status = a.Status
                   };
        }

        public BdP3NewCarDiscountViewModel OpenRecordBdP3NewCarDiscount(int? id)
        {
            var obj = (from a in _context.BdP3_NewCarDiscount
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new BdP3NewCarDiscountViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           BnsodurDate = a.BnsodurDate,
                           BnsodurDateMiladi = a.BnsodurDateMiladi,
                           PelakDate = a.PelakDate,
                           PelakDateMiladi = a.PelakDateMiladi,
                           SodurDate = a.SodurDate,
                           SodurDataMiladi = a.SodurDataMiladi,
                           TafavotPelakSodurDate = a.TafavotPelakSodurDate,
                           Nerkh = a.Nerkh,
                           PusheshEzafiNerkh = a.PusheshEzafiNerkh,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           CompanyCode = a.CompanyCode,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           StatusName = b.StatusName,
                           Status = a.Status
                       }).FirstOrDefault();

            return obj;
        }

        public BdP3NewCarDiscount UpdateBdP3NewCarDiscount(string comment, int id, int statusId)
        {
            var obj = (from a in _context.BdP3_NewCarDiscount
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص 4 بدنه  : اشخاص با اطلاعات ناقص   
        /// </summary>
        /// <returns></returns>
        public IQueryable<BdP4TroubledCustomerViewModel> GetBdP4TroubledCustomer()
        {
            return from a in _context.BdP4_TroubledCustomer
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new BdP4TroubledCustomerViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       BnSodurId = a.BnSodurId,
                       BnSodurName = a.BnSodurName,
                       BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       PersonkindId = a.PersonkindId,
                       PersonKindText = a.PersonKindText,
                       CustomerId = a.CustomerId,
                       CustomerName = a.CustomerName,
                       CodeMelli = a.CodeMelli,
                       CodePosti = a.CodePosti,
                       Address = a.Address,
                       Mobile = a.Mobile,
                       Comment = a.Comment,
                       Status = a.Status,
                       StatusName = b.StatusName
                   };
        }

        public BdP4TroubledCustomerViewModel OpenRecordBdP4TroubledCustomer(int? id)
        {
            var obj = (from a in _context.BdP4_TroubledCustomer
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new BdP4TroubledCustomerViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           PersonkindId = a.PersonkindId,
                           PersonKindText = a.PersonKindText,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           CodeMelli = a.CodeMelli,
                           CodePosti = a.CodePosti,
                           Address = a.Address,
                           Mobile = a.Mobile,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public BdP4TroubledCustomer UpdateBdP4TroubledCustomer(string comment, int id, int statusId)
        {
            var obj = (from a in _context.BdP4_TroubledCustomer
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص 5 بدنه : خودرو با اطلاعات ناقص   
        /// </summary>
        /// <returns></returns>

        public IQueryable<BdP5TroubledKhodroViewModel> GetBdP5TroubledKhodro()
        {
            return from a in _context.BdP5_TroubledKhodro
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new BdP5TroubledKhodroViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       BnSodurId = a.BnSodurId,
                       BnSodurName = a.BnSodurName,
                       BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       KhodroId = a.KhodroId,
                       ShasiNo = a.ShasiNo,
                       PelakNo = a.PelakNo,
                       Vin = a.Vin,
                       MotorNo = a.MotorNo,
                       UserId = a.UserId,
                       UserName = a.UserName,
                       Comment = a.Comment,
                       Status = a.Status,
                       StatusName = b.StatusName
                   };
        }

        public BdP5TroubledKhodroViewModel OpenRecordBdP5TroubledKhodro(int? id)
        {
            var obj = (from a in _context.BdP5_TroubledKhodro
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new BdP5TroubledKhodroViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           KhodroId = a.KhodroId,
                           ShasiNo = a.ShasiNo,
                           PelakNo = a.PelakNo,
                           Vin = a.Vin,
                           MotorNo = a.MotorNo,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public BdP5TroubledKhodro UpdateBdP5TroubledKhodro(string comment, int id, int statusId)
        {
            var obj = (from a in _context.BdP5_TroubledKhodro
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        #endregion
        #region Damage
        /// <summary>
        /// شاخص شماره یک بدنه : کاربری وسیله نقلیه 
        /// </summary>
        /// <returns></returns>
        public IQueryable<BdD1KarbariViewModel> GetBdD1Karbari()
        {
            return from a in _context.BdD1_Karbari
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new BdD1KarbariViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       PrvNo = a.PrvNo,
                       PrvDate = a.PrvDate,
                       Bno = a.Bno,
                       BeginDate = a.BeginDate,
                       BeginDateMiladi = a.BeginDateMiladi,
                       EndDate = a.EndDate,
                       EndDateMiladi = a.EndDateMiladi,
                       BnSodurDate = a.BnSodurDate,
                       SodurDateMiladi = a.SodurDateMiladi,
                       HadeseDate = a.HadeseDate,
                       HadeseDateMiladi = a.HadeseDateMiladi,
                       GovahiSodurDate = a.GovahiSodurDate,
                       GovahiSodurDateMiladi = a.GovahiSodurDateMiladi,
                       HadesePlaceDesc = a.HadesePlaceDesc,
                       ElatHadeseName = a.ElatHadeseName,
                       GovahiTypeName = a.GovahiTypeName,
                       MoredEstefadeName = a.MoredEstefadeName,
                       KhodroListId = a.KhodroListId,
                       KhodrokindName = a.KhodrokindName,
                       DamageSodurName = a.DamageSodurName,
                       BranchName = a.BranchName,
                       UserName = a.UserName,
                       SumHvPayAmountAsRial = a.SumHvPayAmountAsRial,
                       KhodroArzeshAsRial = a.KhodroArzeshAsRial,
                       SalSakhtMiladi = a.SalSakhtMiladi,
                       SalSakhtShamsi = a.SalSakhtShamsi,
                       BdHadeseKindName = a.BdHadeseKindName,
                       Status = a.Status,
                       StatusName = b.StatusName,
                       Comment = a.Comment
                   };
        }
        public BdD1KarbariViewModel OpenRecordBdD1Karbari(int? id)
        {
            var obj = (from a in _context.BdD1_Karbari
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new BdD1KarbariViewModel
                       {
                           PolicyId = a.PolicyId,
                           PrvNo = a.PrvNo,
                           PrvDate = a.PrvDate,
                           Bno = a.Bno,
                           BeginDate = a.BeginDate,
                           BeginDateMiladi = a.BeginDateMiladi,
                           EndDate = a.EndDate,
                           EndDateMiladi = a.EndDateMiladi,
                           BnSodurDate = a.BnSodurDate,
                           SodurDateMiladi = a.SodurDateMiladi,
                           HadeseDate = a.HadeseDate,
                           HadeseDateMiladi = a.HadeseDateMiladi,
                           GovahiSodurDate = a.GovahiSodurDate,
                           GovahiSodurDateMiladi = a.GovahiSodurDateMiladi,
                           HadesePlaceDesc = a.HadesePlaceDesc,
                           ElatHadeseName = a.ElatHadeseName,
                           GovahiTypeName = a.GovahiTypeName,
                           MoredEstefadeName = a.MoredEstefadeName,
                           KhodroListId = a.KhodroListId,
                           KhodrokindName = a.KhodrokindName,
                           DamageSodurName = a.DamageSodurName,
                           BranchName = a.BranchName,
                           UserName = a.UserName,
                           SumHvPayAmountAsRial = a.SumHvPayAmountAsRial,
                           KhodroArzeshAsRial = a.KhodroArzeshAsRial,
                           SalSakhtMiladi = a.SalSakhtMiladi,
                           SalSakhtShamsi = a.SalSakhtShamsi,
                           BdHadeseKindName = a.BdHadeseKindName,
                           Status = a.Status,
                           StatusName = b.StatusName,
                           Comment = a.Comment
                       }).FirstOrDefault();

            return obj;

        }
        public BdD1Karbari UpdateBdD1Karbari(string comment, int id, int statusId)
        {
            var obj = (from a in _context.BdD1_Karbari
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;

        }

        //public BdDamageKPI1ViewModel OpenRecordBdD1Karbari(int? id)
        //{
        //    throw new NotImplementedException();
        //}

        //public BdD1Karbari UpdateBdD1Karbari(string comment, int id)
        //{
        //    throw new NotImplementedException();
        //}


        /// <summary>
        /// شاخص دو بدنه :
        /// تاریخ صدور گواهینامه -فرانشیز مندرج در فرم محاسبه
        /// </summary>
        /// <returns></returns>

        public IQueryable<BdD2FranshizViewModel> GetBdD2Franshiz()
        {
            return from a in _context.BdD2_Franshiz
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new BdD2FranshizViewModel
                   {
                       Id = a.Id,
                       PrvId = a.PrvId,
                       PrvNo = a.PrvNo,
                       PrvDate = a.PrvDate,
                       PrvDateMiladi = a.PrvDateMiladi,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       ElhNo = a.ElhNo,
                       VsodurDate = a.VsodurDate,
                       VsodurDateMiladi = a.VsodurDateMiladi,
                       GovahiSodurDate = a.GovahiSodurDate,
                       GovahiSodurDateMiladi = a.GovahiSodurDateMiladi,
                       Tafavot = a.Tafavot,
                       CustomerId = a.CustomerId,
                       CustomerName = a.CustomerName,
                       Nationalcode = a.Nationalcode,
                       CompanyCode = a.CompanyCode,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       BnSodurId = a.BnSodurId,
                       BnSodurName = a.BnSodurName,
                       BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       PrvSodurId = a.PrvSodurId,
                       PrvSodurName = a.PrvSodurName,
                       BnUserId = a.BnUserId,
                       BnUserName = a.BnUserName,
                       PrvUserId = a.PrvUserId,
                       PrvUserName = a.PrvUserName,
                       Comment = a.Comment,
                       StatusName = b.StatusName,
                       Status = a.Status
                   };
        }

        public BdD2FranshizViewModel OpenRecordBdD2Franshiz(int? id)
        {
            var obj = (from a in _context.BdD2_Franshiz
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new BdD2FranshizViewModel
                       {
                           Id = a.Id,
                           PrvId = a.PrvId,
                           PrvNo = a.PrvNo,
                           PrvDate = a.PrvDate,
                           PrvDateMiladi = a.PrvDateMiladi,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           VsodurDate = a.VsodurDate,
                           VsodurDateMiladi = a.VsodurDateMiladi,
                           GovahiSodurDate = a.GovahiSodurDate,
                           GovahiSodurDateMiladi = a.GovahiSodurDateMiladi,
                           Tafavot = a.Tafavot,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           CompanyCode = a.CompanyCode,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           PrvSodurId = a.PrvSodurId,
                           PrvSodurName = a.PrvSodurName,
                           BnUserId = a.BnUserId,
                           BnUserName = a.BnUserName,
                           PrvUserId = a.PrvUserId,
                           PrvUserName = a.PrvUserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public BdD2Franshiz UpdateBdD2Franshiz(string comment, int id, int statusId)
        {
            var obj = (from a in _context.BdD2_Franshiz
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص سه بدنه :
        /// نوع خودرو در بیمه نامه - نوع گواهینامه
        /// </summary>
        /// <returns></returns>

        public IQueryable<BdD3GovahiCarTypeViewModel> GetBdD3GovahiCarType()
        {
            return from a in _context.BdD3_GovahiCarType
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new BdD3GovahiCarTypeViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       BnSodurDate = a.BnSodurDate,
                       BnSodurDateMiladi = a.BnSodurDateMiladi,

                       GovahiTypeId = a.GovahiTypeId,
                       GovahiTypeName = a.GovahiTypeName,
                       KhodroGoruhId = a.KhodroGoruhId,
                       KhodroGoruhName = a.KhodroGoruhName,
                       KhodroId = a.KhodroId,
                       KhodroKindCaption = a.KhodroKindCaption,
                       SarneshinCount = a.SarneshinCount,
                       Tonaje = a.Tonaje,
                       PrvId = a.PrvId,
                       PrvNo = a.PrvNo,
                       PrvDate = a.PrvDate,
                       PrvDateMiladi = a.PrvDateMiladi,
                       HadeseDate = a.HadeseDate,
                       HadeseDateMiladi = a.HadeseDateMiladi,
                       CustomerId = a.CustomerId,
                       CustomerName = a.CustomerName,
                       Nationalcode = a.Nationalcode,
                       CompanyCode = a.CompanyCode,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       BnSodurId = a.BnSodurId,
                       BnSodurName = a.BnSodurName,
                       BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       BnUserId = a.BnUserId,
                       BnUserName = a.BnUserName,
                       PrvUserId = a.PrvUserId,
                       PrvUserName = a.PrvUserName,
                       Comment = a.Comment,
                       Status = a.Status,
                       StatusName = b.StatusName
                   };
        }

        public BdD3GovahiCarTypeViewModel OpenRecordBdD3GovahiCarType(int? id)
        {
            var obj = (from a in _context.BdD3_GovahiCarType
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new BdD3GovahiCarTypeViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,

                           GovahiTypeId = a.GovahiTypeId,
                           GovahiTypeName = a.GovahiTypeName,
                           KhodroGoruhId = a.KhodroGoruhId,
                           KhodroGoruhName = a.KhodroGoruhName,
                           KhodroId = a.KhodroId,
                           KhodroKindCaption = a.KhodroKindCaption,
                           SarneshinCount = a.SarneshinCount,
                           Tonaje = a.Tonaje,
                           PrvId = a.PrvId,
                           PrvNo = a.PrvNo,
                           PrvDate = a.PrvDate,
                           PrvDateMiladi = a.PrvDateMiladi,
                           HadeseDate = a.HadeseDate,
                           HadeseDateMiladi = a.HadeseDateMiladi,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           CompanyCode = a.CompanyCode,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           BnUserId = a.BnUserId,
                           BnUserName = a.BnUserName,
                           PrvUserId = a.PrvUserId,
                           PrvUserName = a.PrvUserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public BdD3GovahiCarType UpdateBdD3GovahiCarType(string comment, int id, int statusId)
        {
            var obj = (from a in _context.BdD3_GovahiCarType
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص چهار بدنه :
        /// سال ساخت خودرو - سال وقوع حادثه
        /// </summary>
        /// <returns></returns>

        public IQueryable<BdD4EstehlakViewModel> GetBdD4Estehlak()
        {
            return from a in _context.BdD4_Estehlak
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new BdD4EstehlakViewModel
                   {
                       Id = a.Id,
                       PrvId = a.PrvId,
                       PrvNo = a.PrvNo,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       BnSodurDate = a.BnSodurDate,
                       BnSodurDateMiladi = a.BnSodurDateMiladi,
                       CustomerId = a.CustomerId,
                       CustomerName = a.CustomerName,
                       Nationalcode = a.Nationalcode,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       BnSodurId = a.BnSodurId,
                       BnSodurName = a.BnSodurName,
                       BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       PrvSodurId = a.PrvSodurId,
                       PrvSodurName = a.PrvSodurName,
                       PrvDate = a.PrvDate,
                       PrvDateMiladi = a.PrvDateMiladi,
                       HadeseDate = a.HadeseDate,
                       HadeseDateMiladi = a.HadeseDateMiladi,
                       UserId = a.UserId,
                       BnUserName = a.BnUserName,
                       Comment = a.Comment,
                       Status = a.Status,
                       StatusName = b.StatusName

                   };
        }

        public BdD4EstehlakViewModel OpenRecordBdD4Estehlak(int? id)
        {
            var obj = (from a in _context.BdD4_Estehlak
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new BdD4EstehlakViewModel
                       {
                           Id = a.Id,
                           PrvId = a.PrvId,
                           PrvNo = a.PrvNo,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           PrvSodurId = a.PrvSodurId,
                           PrvSodurName = a.PrvSodurName,
                           PrvDate = a.PrvDate,
                           PrvDateMiladi = a.PrvDateMiladi,
                           HadeseDate = a.HadeseDate,
                           HadeseDateMiladi = a.HadeseDateMiladi,
                           UserId = a.UserId,
                           BnUserName = a.BnUserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public BdD4Estehlak UpdateBdD4Estehlak(string comment, int id, int statusId)
        {
            var obj = (from a in _context.BdD4_Estehlak
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص پنج بدنه :
        /// ارزش خودرو مندرج در بیمه نامه - ارزش کارشناسی خودرو در زمان وقوع حادثه 
        /// </summary>
        /// <returns></returns>
        public IQueryable<BdD5CarAmountViewModel> GetBdD5CarAmount()
        {
            return from a in _context.BdD5_CarAmount
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new BdD5CarAmountViewModel
                   {
                       Id = a.Id,
                       PrvId = a.PrvId,
                       PrvNo = a.PrvNo,
                       KhodroArzesh = a.KhodroArzesh,
                       KhodroArzeshRouz = a.KhodroArzeshRouz,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       BnSodurDate = a.BnSodurDate,
                       BnSodurDateMiladi = a.BnSodurDateMiladi,
                       PrvDate = a.PrvDate,
                       PrvDateMiladi = a.PrvDateMiladi,
                       CustomerId = a.CustomerId,
                       CustomerName = a.CustomerName,
                       Nationalcode = a.Nationalcode,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       BnSodurId = a.BnSodurId,
                       BnSodurName = a.BnSodurName,
                       BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       PrvSodurId = a.PrvSodurId,
                       PrvSodurName = a.PrvSodurName,
                       BnUserId = a.BnUserId,
                       BnUserName = a.BnUserName,
                       PrvUserId = a.PrvUserId,
                       PrvUserName = a.PrvUserName,
                       Comment = a.Comment,
                       Status = a.Status,
                       StatusName = b.StatusName
                   };
        }

        public BdD5CarAmountViewModel OpenRecordBdD5CarAmount(int? id)
        {
            var obj = (from a in _context.BdD5_CarAmount
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new BdD5CarAmountViewModel
                       {
                           Id = a.Id,
                           PrvId = a.PrvId,
                           PrvNo = a.PrvNo,
                           KhodroArzesh = a.KhodroArzesh,
                           KhodroArzeshRouz = a.KhodroArzeshRouz,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           PrvDate = a.PrvDate,
                           PrvDateMiladi = a.PrvDateMiladi,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           BnSodurId = a.BnSodurId,
                           BnSodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           PrvSodurId = a.PrvSodurId,
                           PrvSodurName = a.PrvSodurName,
                           BnUserId = a.BnUserId,
                           BnUserName = a.BnUserName,
                           PrvUserId = a.PrvUserId,
                           PrvUserName = a.PrvUserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public BdD5CarAmount UpdateBdD5CarAmount(string comment, int id, int statusId)
        {
            var obj = (from a in _context.BdD5_CarAmount
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// شاخص شش بدنه :
        /// تاریخ صدور - تاریخ وقوع حادثه
        /// </summary>
        /// <returns></returns>


        public IQueryable<BdD6DayDamageViewModel> GetBdD6DayDamage()
        {
            return from a in _context.BdD6_DayDamage
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new BdD6DayDamageViewModel
                   {
                       Id = a.Id,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       PrvId = a.PrvId,
                       PrvNo = a.PrvNo,
                       BnsodurDate = a.BnsodurDate,
                       SodurDateMiladi = a.SodurDateMiladi,
                       HadeseDate = a.HadeseDate,
                       HadeseDateMiladi = a.HadeseDateMiladi,
                       DateDifference = a.DateDifference,
                       PrvDate = a.PrvDate,
                       PrvDateMiladi = a.PrvDateMiladi,
                       CustomerId = a.CustomerId,
                       CustomerName = a.CustomerName,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       SodurId = a.SodurId,
                       SodurName = a.SodurName,
                       BranchId = a.BranchId,
                       BranchName = a.BranchName,
                       ElatHadese = a.ElatHadese,
                       ElatHadeseName = a.ElatHadeseName,
                       PrvSodurId = a.PrvSodurId,
                       PrvSodurName = a.PrvSodurName,
                       BnUserId = a.BnUserId,
                       BnUserName = a.BnUserName,
                       PrvUserId = a.PrvUserId,
                       PrvUserName = a.PrvUserName,
                       LastBnEndDate = a.LastBnEndDate,
                       Comment = a.Comment,
                       Status = a.Status,
                       StatusName = b.StatusName
                   };
        }

        public BdD6DayDamageViewModel OpenRecordBdD6DayDamage(int? id)
        {
            var obj = (from a in _context.BdD6_DayDamage
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new BdD6DayDamageViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           PrvId = a.PrvId,
                           PrvNo = a.PrvNo,
                           BnsodurDate = a.BnsodurDate,
                           SodurDateMiladi = a.SodurDateMiladi,
                           HadeseDate = a.HadeseDate,
                           HadeseDateMiladi = a.HadeseDateMiladi,
                           DateDifference = a.DateDifference,
                           PrvDate = a.PrvDate,
                           PrvDateMiladi = a.PrvDateMiladi,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           ElatHadese = a.ElatHadese,
                           ElatHadeseName = a.ElatHadeseName,
                           PrvSodurId = a.PrvSodurId,
                           PrvSodurName = a.PrvSodurName,
                           BnUserId = a.BnUserId,
                           BnUserName = a.BnUserName,
                           PrvUserId = a.PrvUserId,
                           PrvUserName = a.PrvUserName,
                           LastBnEndDate = a.LastBnEndDate,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public BdD6DayDamage UpdateBdD6DayDamage(string comment, int id, int statusId)
        {
            var obj = (from a in _context.BdD6_DayDamage
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }


        /// <summary>
        /// شاخص هفت بدنه :
        /// تاریخ اقساط - تاریخ واریزیها - تاریخ وقوع حادثه 
        /// </summary>
        /// <returns></returns>

        public IQueryable<BdD7InstallmentWithHvViewModel> GetBdD7InstallmentWithHv()
        {
            return from a in _context.BdD7_InstallmentWithHv
                   join b in _context.tblPrvStatus on a.Status equals b.Id
                   select new BdD7InstallmentWithHvViewModel
                   {
                       Id = a.Id,
                       PrmSrdId = a.PrmSrdId,
                       PolicyId = a.PolicyId,
                       Bno = a.Bno,
                       ElhNo = a.ElhNo,
                       ReshteName = a.ReshteName,
                       AgentCode = a.AgentCode,
                       AgentName = a.AgentName,
                       SodurId = a.SodurId,
                       SodurName = a.SodurName,
                       PayerCustomerId = a.PayerCustomerId,
                       CustomerId = a.CustomerId,
                       CustomerName = a.CustomerName,
                       BeginDate = a.BeginDate,
                       BeginDateMiladi = a.BeginDateMiladi,
                       EndDate = a.EndDate,
                       EndDateMiladi = a.EndDateMiladi,
                       BnSodurDate = a.BnSodurDate,
                       BnSodurDateMiladi = a.BnSodurDateMiladi,
                       SrdDate = a.SrdDate,
                       SrdDateMiladi = a.SrdDateMiladi,
                       OpDate = a.OpDate,
                       OpDateMiladi = a.OpDateMiladi,
                       IsActiveId = a.IsActiveId,
                       TasvieType = a.TasvieType,
                       SrdAmountAsRial = a.SrdAmountAsRial,
                       TasvieAmount = a.TasvieAmount,
                       Mande = a.Mande,
                       TasvieNashode = a.TasvieNashode,
                       VosulShode = a.VosulShode,
                       AmaliatTasvieType = a.AmaliatTasvieType,
                       CreditType = a.CreditType,
                       PrvDate = a.PrvDate,
                       PrvDateMiladi = a.PrvDateMiladi,
                       HadeseDate = a.HadeseDate,
                       HadeseDateMiladi = a.HadeseDateMiladi,
                       ElamDate = a.ElamDate,
                       ElamDateMiladi = a.ElamDateMiladi,
                       PrvNo = a.PrvNo,
                       HvAmount = a.HvAmount,
                       VslStateDate = a.VslStateDate,
                       VslStateDateMiladi = a.VslStateDateMiladi,
                       IsNaghdiId = a.IsNaghdiId,
                       DeliverDate = a.DeliverDate,
                       DeliverDateMiladi = a.DeliverDateMiladi,
                       RcvdKindId = a.RcvdKindId,
                       RcvdKindName = a.RcvdKindName,
                       VslStateId = a.VslStateId,
                       VslStateName = a.VslStateName,
                       Comment = a.Comment,
                       Status = a.Status,
                       StatusName = b.StatusName
                   };
        }

        public BdD7InstallmentWithHvViewModel OpenRecordBdD7InstallmentWithHv(int? id)
        {
            var obj = (from a in _context.BdD7_InstallmentWithHv
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new BdD7InstallmentWithHvViewModel
                       {
                           Id = a.Id,
                           PrmSrdId = a.PrmSrdId,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           ReshteName = a.ReshteName,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           PayerCustomerId = a.PayerCustomerId,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           BeginDate = a.BeginDate,
                           BeginDateMiladi = a.BeginDateMiladi,
                           EndDate = a.EndDate,
                           EndDateMiladi = a.EndDateMiladi,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           SrdDate = a.SrdDate,
                           SrdDateMiladi = a.SrdDateMiladi,
                           OpDate = a.OpDate,
                           OpDateMiladi = a.OpDateMiladi,
                           IsActiveId = a.IsActiveId,
                           TasvieType = a.TasvieType,
                           SrdAmountAsRial = a.SrdAmountAsRial,
                           TasvieAmount = a.TasvieAmount,
                           Mande = a.Mande,
                           TasvieNashode = a.TasvieNashode,
                           VosulShode = a.VosulShode,
                           AmaliatTasvieType = a.AmaliatTasvieType,
                           CreditType = a.CreditType,
                           PrvDate = a.PrvDate,
                           PrvDateMiladi = a.PrvDateMiladi,
                           HadeseDate = a.HadeseDate,
                           HadeseDateMiladi = a.HadeseDateMiladi,
                           ElamDate = a.ElamDate,
                           ElamDateMiladi = a.ElamDateMiladi,
                           PrvNo = a.PrvNo,
                           HvAmount = a.HvAmount,
                           VslStateDate = a.VslStateDate,
                           VslStateDateMiladi = a.VslStateDateMiladi,
                           IsNaghdiId = a.IsNaghdiId,
                           DeliverDate = a.DeliverDate,
                           DeliverDateMiladi = a.DeliverDateMiladi,
                           RcvdKindId = a.RcvdKindId,
                           RcvdKindName = a.RcvdKindName,
                           VslStateId = a.VslStateId,
                           VslStateName = a.VslStateName,
                           Comment = a.Comment,
                           Status = a.Status,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }

        public BdD7InstallmentWithHv UpdateBdD7InstallmentWithHv(string comment, int id, int statusId)
        {
            var obj = (from a in _context.BdD7_InstallmentWithHv
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        #endregion
        #endregion
        #endregion



        public List<MiniRepoByBranchViewModel> GetBnFileByBranch()
        {
            var res = (from a in _context.ReportFromAllTable
                           // where a.KpiTypeId == 1
                       group a by new { a.BranchName, a.KpiTypeName } into grouped
                       select new MiniRepoByBranchViewModel
                       {
                           KpiTypeName = grouped.Key.KpiTypeName,
                           BranchName = grouped.Key.BranchName,
                           Cnt = grouped.Sum(t => t.Cnt)
                       }).OrderByDescending(a => a.Cnt).ToList();
            //select new
            //{
            //    BranchId = grouped.Key.BranchId,
            //    BranchName = grouped.Key.BranchName,
            //    Cnt = grouped.Sum(t => t.Cnt)
            //};

            //var data = _context.ReportFromAllTable
            //    .Where(o => o.KpiTypeId == 1)
            //    .GroupBy(x => new { x.BranchId, x.BranchName })
            //    .Select(x => new { x.Key.BranchId, x.Key.BranchName, Total = x.Sum(y => y.Cnt) }).ToList();

            //var res2 = (from a in data
            //           select a).OrderByDescending(a => a.Total).ToList();
            return res;
        }


        public List<RevenueChartViewModel> GetChartInfo()
        {
           var res = _context.tblRevenueChart
               .Select(x => new RevenueChartViewModel { BranchName= x.BranchName ,BnCnt= x.BnCnt , DmgCnt= x.DmgCnt }).ToList();
            return res; 
        }

        public List<ResultTest> GetResultTestData(int id)
        {
            var data = _context.SpResultTest.FromSqlInterpolated($"SP_StatusCnt {id}").ToList();
            return data;
        }


    }
}
