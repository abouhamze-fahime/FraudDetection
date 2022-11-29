using Fraud.Context;
using Fraud.Entities;
using Fraud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud.Services
{
    public class FireServices:IFireServices
    {
        private AppDbContext _context;
        public FireServices(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// درج کامل آدرس مورد بیمه و یکسان بودن آن با کد پستی در فناوران
        /// </summary>
        /// <returns></returns>
        public IQueryable<FireP01TroubledCodePostiViewModel> GetFireP01TroubledCodePosti()
        {
            var res = from a in _context.FireP01_TroubledCodePosti
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP01TroubledCodePostiViewModel
                      {
                          Id = a.Id,
                          PolicyId = a.PolicyId,
                          ElhNo = a.ElhNo,
                          Bno = a.Bno,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          PostalCode = a.PostalCode,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP01TroubledCodePostiViewModel OpenRecordFireP01TroubledCodePosti(int? id)
        {
            var obj = (from a in _context.FireP01_TroubledCodePosti
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP01TroubledCodePostiViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           ElhNo = a.ElhNo,
                           Bno = a.Bno,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           PostalCode = a.PostalCode,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName
                       }).FirstOrDefault();

            return obj;
        }
        public FireP01TroubledCodePosti UpdateFireP01TroubledCodePosti(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP01_TroubledCodePosti
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        /// کنترل ثبت کد رایانه بیمه نامه قبلی در فناوران در خصوص صدور بیمه نامه های تمدیدی
        /// </summary>
        /// <returns></returns>

        public IQueryable<FireP03BnNoLastPolicyIdViewModel> GetFireP03BnNoLastPolicyId()
        {
            var res = from a in _context.FireP03_BnNoLastPolicyId
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP03BnNoLastPolicyIdViewModel
                      {
                          Id = a.Id,
                          PolicyId = a.PolicyId,
                          ElhNo = a.ElhNo,
                          Bno = a.Bno,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP03BnNoLastPolicyIdViewModel OpenRecordFireP03BnNoLastPolicyId(int? id)
        {
            var obj = (from a in _context.FireP03_BnNoLastPolicyId
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP03BnNoLastPolicyIdViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           ElhNo = a.ElhNo,
                           Bno = a.Bno,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP03BnNoLastPolicyId UpdateFireP03BnNoLastPolicyId(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP03_BnNoLastPolicyId
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        /// کنترل درج لیست تفکیکی
        /// </summary>
        /// <returns></returns>


        public IQueryable<FireP04TafkikListViewModel> GetFireP04TafkikList()
        {
            var res = from a in _context.FireP04_TafkikList
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP04TafkikListViewModel
                      {
                          Id = a.Id,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          Mid = a.Mid,
                          Eid = a.Eid,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          KhatarEzafiId = a.KhatarEzafiId,
                          EzafiRiskKind = a.EzafiRiskKind,
                          KhatarEzafiName = a.KhatarEzafiName,
                          MoreBimeId = a.MoreBimeId,
                          MoreBimeName = a.MoreBimeName,
                          MoreBimeSharh = a.MoreBimeSharh,
                          Sarmaye = a.Sarmaye,
                          Kind = a.Kind,
                          MoredKind = a.MoredKind,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP04TafkikListViewModel OpenRecordFireP04TafkikList(int? id)
        {
            var obj = (from a in _context.FireP04_TafkikList
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP04TafkikListViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           Mid = a.Mid,
                           Eid = a.Eid,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           KhatarEzafiId = a.KhatarEzafiId,
                           EzafiRiskKind = a.EzafiRiskKind,
                           KhatarEzafiName = a.KhatarEzafiName,
                           MoreBimeId = a.MoreBimeId,
                           MoreBimeName = a.MoreBimeName,
                           MoreBimeSharh = a.MoreBimeSharh,
                           Sarmaye = a.Sarmaye,
                           Kind = a.Kind,
                           MoredKind = a.MoredKind,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP04TafkikList UpdateFireP04TafkikList(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP04_TafkikList
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }

        /// <summary>
        /// الزام بازدید از موارد بیمه صنعتی، غیرصنعتی و انبارها با درخواست افزایش
        /// </summary>
        /// <returns></returns>


        public IQueryable<FireP06AfzayeshSarmayeViewModel> GetFireP06AfzayeshSarmaye()
        {
            var res = from a in _context.FireP06_AfzayeshSarmaye
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP06AfzayeshSarmayeViewModel
                      {
                          Id = a.Id,
                          PolicyVerId = a.PolicyVerId,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          Ro = a.Ro,
                          ElhNo = a.ElhNo,
                          PolicyTypeId = a.PolicyTypeId,
                          Sarmaye = a.Sarmaye,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentCode = a.AgentCode,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          DiffRate = a.DiffRate,
                          Status = a.Status,
                          Comment = a.Comment,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP06AfzayeshSarmayeViewModel OpenRecordFireP06AfzayeshSarmaye(int? id)
        {
            var obj = (from a in _context.FireP06_AfzayeshSarmaye
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP06AfzayeshSarmayeViewModel
                       {
                           Id = a.Id,
                           PolicyVerId = a.PolicyVerId,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           Ro = a.Ro,
                           ElhNo = a.ElhNo,
                           PolicyTypeId = a.PolicyTypeId,
                           Sarmaye = a.Sarmaye,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           DiffRate = a.DiffRate,
                           Status = a.Status,
                           Comment = a.Comment,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP06AfzayeshSarmaye UpdateFireP06AfzayeshSarmaye(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP06_AfzayeshSarmaye
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        /// الزام به بازدید از انبارهای عمومی بدون در نظر گرفتن ارزش سرمایه مورد بیمه
        /// </summary>
        /// <returns></returns>
        /// 

        public IQueryable<FireP07AnbarBazdidViewModel> GetFireP07AnbarBazdid()
        {
            var res = from a in _context.FireP07_AnbarBazdid
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP07AnbarBazdidViewModel
                      {
                          Id = a.Id,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentCode = a.AgentCode,
                          AgentName = a.AgentName,
                          SodurId = a.BnSodurId,
                          SodurName = a.BnSodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP07AnbarBazdidViewModel OpenRecordFireP07AnbarBazdid(int? id)
        {
            var obj = (from a in _context.FireP07_AnbarBazdid
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP07AnbarBazdidViewModel
                       {
                           Id = a.Id,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentCode = a.AgentCode,
                           AgentName = a.AgentName,
                           SodurId = a.BnSodurId,
                           SodurName = a.BnSodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP07AnbarBazdid UpdateFireP07AnbarBazdid(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP07_AnbarBazdid
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        /// کنترل اعتبار زمان بازدید اولیه تا صدور بیمه نامه برای خطر آصا و سایر خطراتی که بازدید برای آنها الزامی است
        /// </summary>
        /// <returns></returns>
        /// 


        public IQueryable<FireP08AsaBazdidViewModel> GetFireP08AsaBazdid()
        {
            var res = from a in _context.FireP08_AsaBazdid
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP08AsaBazdidViewModel
                      {

                          Id = a.Id,
                          BazdidId = a.BazdidId,
                          PolicyVid = a.PolicyVid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          BazdidDate = a.BazdidDate,
                          BazdidDateMiladi = a.BazdidDateMiladi,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          DiffDate = a.DiffDate,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP08AsaBazdidViewModel OpenRecordFireP08AsaBazdid(int? id)
        {
            var obj = (from a in _context.FireP08_AsaBazdid
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP08AsaBazdidViewModel
                       {

                           Id = a.Id,
                           BazdidId = a.BazdidId,
                           PolicyVid = a.PolicyVid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           BazdidDate = a.BazdidDate,
                           BazdidDateMiladi = a.BazdidDateMiladi,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           DiffDate = a.DiffDate,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP08AsaBazdid UpdateFireP08AsaBazdid(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP08_AsaBazdid
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        /// کنترل بازدید آتش سوزی مسکونی بیش از 400 میلیارد ریال
        /// </summary>
        /// <returns></returns>
        /// 


        public IQueryable<FireP09MaskanBazdidViewModel> GetFireP09MaskanBazdid()
        {
            var res = from a in _context.FireP09_MaskanBazdid
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP09MaskanBazdidViewModel
                      {
                          Id = a.Id,
                          PolicyVid = a.PolicyVid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          Reshte = a.Reshte,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          Sarmaye = a.Sarmaye,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP09MaskanBazdidViewModel OpenRecordFireP09MaskanBazdid(int? id)
        {
            var obj = (from a in _context.FireP09_MaskanBazdid
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP09MaskanBazdidViewModel
                       {

                           Id = a.Id,
                           PolicyVid = a.PolicyVid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           Reshte = a.Reshte,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           Sarmaye = a.Sarmaye,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP09MaskanBazdid UpdateFireP09MaskanBazdid(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP09_MaskanBazdid
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        ///کنترل بازدید آتش سوزی غیر صنعتی بیش از 10 میلیارد ریال
        /// </summary>
        /// <returns></returns>


        public IQueryable<FireP10GheirSanatiBazdidOver10ViewModel> GetFireP10GheirSanatiBazdidOver10()
        {
            var res = from a in _context.FireP10_GheirSanatiBazdidOver10
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP10GheirSanatiBazdidOver10ViewModel
                      {
                          Id = a.Id,
                          PolicyVid = a.PolicyVid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          Reshte = a.Reshte,
                          ReshteName = a.ReshteName,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          Sarmaye = a.Sarmaye,
                          RiskTabagh = a.RiskTabagh,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP10GheirSanatiBazdidOver10ViewModel OpenRecordFireP10GheirSanatiBazdidOver10(int? id)
        {
            var obj = (from a in _context.FireP10_GheirSanatiBazdidOver10
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP10GheirSanatiBazdidOver10ViewModel
                       {

                           Id = a.Id,
                           PolicyVid = a.PolicyVid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           Reshte = a.Reshte,
                           ReshteName = a.ReshteName,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           Sarmaye = a.Sarmaye,
                           RiskTabagh = a.RiskTabagh,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP10GheirSanatiBazdidOver10 UpdateFireP10GheirSanatiBazdidOver10(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP10_GheirSanatiBazdidOver10
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        ///کنترل بازدید آتش سوزی غیرصنعتی بیش از 80 میلیارد ریال
        /// </summary>
        /// <returns></returns>

        public IQueryable<FireP11GheirSanatiBazdidOver80ViewModel> GetFireP11GheirSanatiBazdidOver80()
        {
            var res = from a in _context.FireP11_GheirSanatiBazdidOver80
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP11GheirSanatiBazdidOver80ViewModel
                      {
                          Id = a.Id,
                          PolicyVid = a.PolicyVid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          Reshte = a.Reshte,
                          ReshteName = a.ReshteName,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          Sarmaye = a.Sarmaye,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP11GheirSanatiBazdidOver80ViewModel OpenRecordFireP11GheirSanatiBazdidOver80(int? id)
        {
            var obj = (from a in _context.FireP11_GheirSanatiBazdidOver80
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP11GheirSanatiBazdidOver80ViewModel
                       {

                           Id = a.Id,
                           PolicyVid = a.PolicyVid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           Reshte = a.Reshte,
                           ReshteName = a.ReshteName,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           Sarmaye = a.Sarmaye,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP11GheirSanatiBazdidOver80 UpdateFireP11GheirSanatiBazdidOver80(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP11_GheirSanatiBazdidOver80
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        ///کنترل بازدید آتش سوزی انبار بیش از 10 میلیارد ریال
        /// </summary>
        /// <returns></returns>
        /// 

        public IQueryable<FireP12AnbarBazdidOver10ViewModel> GetFireP12AnbarBazdidOver10()
        {
            var res = from a in _context.FireP12_AnbarBazdidOver10
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP12AnbarBazdidOver10ViewModel
                      {
                          Id = a.Id,
                          PolicyVid = a.PolicyVid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          Reshte = a.Reshte,
                          ReshteName = a.ReshteName,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          Sarmaye = a.Sarmaye,
                          RiskTabagh = a.RiskTabagh,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP12AnbarBazdidOver10ViewModel OpenRecordFireP12AnbarBazdidOver10(int? id)
        {
            var obj = (from a in _context.FireP12_AnbarBazdidOver10
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP12AnbarBazdidOver10ViewModel
                       {

                           Id = a.Id,
                           PolicyVid = a.PolicyVid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           Reshte = a.Reshte,
                           ReshteName = a.ReshteName,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           Sarmaye = a.Sarmaye,
                           RiskTabagh = a.RiskTabagh,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP12AnbarBazdidOver10 UpdateFireP12AnbarBazdidOver10(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP12_AnbarBazdidOver10
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        ///کنترل بازدید آتش سوزی صنعتی بیش از 20 میلیارد ریال
        /// </summary>
        /// <returns></returns>


        public IQueryable<FireP13SanatiBazdidOver20ViewModel> GetFireP13SanatiBazdidOver20()
        {
            var res = from a in _context.FireP13_SanatiBazdidOver20
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP13SanatiBazdidOver20ViewModel
                      {
                          Id = a.Id,
                          PolicyVid = a.PolicyVid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          Reshte = a.Reshte,
                          ReshteName = a.ReshteName,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          Sarmaye = a.Sarmaye,
                          RiskTabagh = a.RiskTabagh,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP13SanatiBazdidOver20ViewModel OpenRecordFireP13SanatiBazdidOver20(int? id)
        {
            var obj = (from a in _context.FireP13_SanatiBazdidOver20
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP13SanatiBazdidOver20ViewModel
                       {

                           Id = a.Id,
                           PolicyVid = a.PolicyVid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           Reshte = a.Reshte,
                           ReshteName = a.ReshteName,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           Sarmaye = a.Sarmaye,
                           RiskTabagh = a.RiskTabagh,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP13SanatiBazdidOver20 UpdateFireP13SanatiBazdidOver20(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP13_SanatiBazdidOver20
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        ///کنترل بازدید آتش سوزی صنعتی و انبارهای عمومی تمامی فعالیتهای گروه 9-10-11-12 
        /// </summary>
        /// <returns></returns>


        public IQueryable<FireP14SanatiAnbarBazdidSpecialGroupViewModel> GetFireP14SanatiAnbarBazdidSpecialGroup()
        {
            var res = from a in _context.FireP14_SanatiAnbarBazdidSpecialGroup
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP14SanatiAnbarBazdidSpecialGroupViewModel
                      {
                          Id = a.Id,
                          PolicyVid = a.PolicyVid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          Reshte = a.Reshte,
                          ReshteName = a.ReshteName,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          Sarmaye = a.Sarmaye,
                          RiskTabagh = a.RiskTabagh,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP14SanatiAnbarBazdidSpecialGroupViewModel OpenRecordFireP14SanatiAnbarBazdidSpecialGroup(int? id)
        {
            var obj = (from a in _context.FireP14_SanatiAnbarBazdidSpecialGroup
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP14SanatiAnbarBazdidSpecialGroupViewModel
                       {
                           Id = a.Id,
                           PolicyVid = a.PolicyVid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           Reshte = a.Reshte,
                           ReshteName = a.ReshteName,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           Sarmaye = a.Sarmaye,
                           RiskTabagh = a.RiskTabagh,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP14SanatiAnbarBazdidSpecialGroup UpdateFireP14SanatiAnbarBazdidSpecialGroup(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP14_SanatiAnbarBazdidSpecialGroup
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        ///کنترل بازدید ترکیدگی لوله آب ، ضایعات ناشی از آب باران و ذوب برف بیش از30 میلیون ریال
        /// </summary>
        /// <returns></returns>

        public IQueryable<FireP15BazdidSpecialGroupOver30ViewModel> GetFireP15BazdidSpecialGroupOver30()
        {
            var res = from a in _context.FireP15_BazdidSpecialGroupOver30
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP15BazdidSpecialGroupOver30ViewModel
                      {
                          Id = a.Id,
                          EzafiId = a.EzafiId,
                          PolicyVid = a.PolicyVid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          Reshte = a.Reshte,
                          ReshteName = a.ReshteName,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          Sarmaye = a.Sarmaye,
                          RiskTabagh = a.RiskTabagh,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP15BazdidSpecialGroupOver30ViewModel OpenRecordFireP15BazdidSpecialGroupOver30(int? id)
        {
            var obj = (from a in _context.FireP15_BazdidSpecialGroupOver30
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP15BazdidSpecialGroupOver30ViewModel
                       {
                           Id = a.Id,
                           EzafiId = a.EzafiId,
                           PolicyVid = a.PolicyVid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           Reshte = a.Reshte,
                           ReshteName = a.ReshteName,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           Sarmaye = a.Sarmaye,
                           RiskTabagh = a.RiskTabagh,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP15BazdidSpecialGroupOver30 UpdateFireP15BazdidSpecialGroupOver30(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP15_BazdidSpecialGroupOver30
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        ///کنترل بازدید ترکیدگی لوله آب ، ضایعات ناشی از آب باران و ذوب برف بیش از30 میلیون ریال
        /// </summary>
        /// <returns></returns>
        /// 

        public IQueryable<FireP16SerghatBazdidOver700ViewModel> GetFireP16SerghatBazdidOver700()
        {
            var res = from a in _context.FireP16_SerghatBazdidOver700
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP16SerghatBazdidOver700ViewModel
                      {
                          Id = a.Id,
                          EzafiId = a.EzafiId,
                          PolicyVid = a.PolicyVid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          Reshte = a.Reshte,
                          ReshteName = a.ReshteName,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          Sarmaye = a.Sarmaye,
                          RiskTabagh = a.RiskTabagh,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP16SerghatBazdidOver700ViewModel OpenRecordFireP16SerghatBazdidOver700(int? id)
        {
            var obj = (from a in _context.FireP16_SerghatBazdidOver700
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP16SerghatBazdidOver700ViewModel
                       {
                           Id = a.Id,
                           EzafiId = a.EzafiId,
                           PolicyVid = a.PolicyVid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           Reshte = a.Reshte,
                           ReshteName = a.ReshteName,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           Sarmaye = a.Sarmaye,
                           RiskTabagh = a.RiskTabagh,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP16SerghatBazdidOver700 UpdateFireP16SerghatBazdidOver700(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP16_SerghatBazdidOver700
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        ///کنترل بازدید رانش زمین ، شرایط جایگزینی یا بازسازی 
        ///، حوادث ، تعریق ، سنگینی برف ، خود سوزی ، نوسانات برق ، فساد کالا درسردخانه
        ///، نشت گاز آمونیاک ، فروکش چاه آب و فاضلاب ، دفرمگی ظروف تحت فشار صنعتی
        ///، ریزش پودر مواد خام داغ ، تگرگ ، ریزش کوه و بهمن ، برخورد وسایل نقلیه داخل
        ///سایت مورد بیمه ، سقوط قطعات منفصله از ماشین آلات ، تمام خطر اموال و شکست ماشین آلاتل
        /// </summary>
        /// <returns></returns>
        /// 

        public IQueryable<FireP17SpecialGroupBazdidViewModel> GetFireP17SpecialGroupBazdid()
        {
            var res = from a in _context.FireP17_SpecialGroupBazdid
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP17SpecialGroupBazdidViewModel
                      {
                          Id = a.Id,
                          EzafiId = a.EzafiId,
                          PolicyVid = a.PolicyVid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          Eid = a.Eid,
                          Reshte = a.Reshte,
                          ReshteName = a.ReshteName,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          Sarmaye = a.Sarmaye,
                          RiskTabagh = a.RiskTabagh,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP17SpecialGroupBazdidViewModel OpenRecordFireP17SpecialGroupBazdid(int? id)
        {
            var obj = (from a in _context.FireP17_SpecialGroupBazdid
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP17SpecialGroupBazdidViewModel
                       {
                           Id = a.Id,
                           EzafiId = a.EzafiId,
                           PolicyVid = a.PolicyVid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           Reshte = a.Reshte,
                           ReshteName = a.ReshteName,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           Sarmaye = a.Sarmaye,
                           RiskTabagh = a.RiskTabagh,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP17SpecialGroupBazdid UpdateFireP17SpecialGroupBazdid(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP17_SpecialGroupBazdid
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        ///الزام بازدید از مورد بیمه ای که دارای سابقه خسارت بوده اند بدون در نظر گرفتن سرمایه بیمه نامه
        /// </summary>
        /// <returns></returns>
        public IQueryable<FireP18DamagedBazdidViewModel> GetFireP18DamagedBazdid()
        {
            var res = from a in _context.FireP18_DamagedBazdid
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP18DamagedBazdidViewModel
                      {
                          Id = a.Id,
                          EzafiId = a.EzafiId,
                          PolicyVid = a.PolicyVid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          Eid = a.Eid,
                          EzafiRiskKind = a.EzafiRiskKind,
                          Reshte = a.Reshte,
                          ReshteName = a.ReshteName,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          Sarmaye = a.Sarmaye,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP18DamagedBazdidViewModel OpenRecordFireP18DamagedBazdid(int? id)
        {
            var obj = (from a in _context.FireP18_DamagedBazdid
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP18DamagedBazdidViewModel
                       {
                           Id = a.Id,
                           EzafiId = a.EzafiId,
                           PolicyVid = a.PolicyVid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           Eid = a.Eid,
                           EzafiRiskKind = a.EzafiRiskKind,
                           Reshte = a.Reshte,
                           ReshteName = a.ReshteName,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           Sarmaye = a.Sarmaye,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP18DamagedBazdid UpdateFireP18DamagedBazdid(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP18_DamagedBazdid
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        ///حداقل حق بیمه دریافتی برای صدور تمام بیمه نامه های آتش سوزی )به جز طرح جامع منازل مسکونی(218,000) ریال می باشد
        /// </summary>
        /// <returns></returns>
        /// 

        public IQueryable<FireP19MinPrmViewModel> GetFireP19MinPrm()
        {
            var res = from a in _context.FireP19_MinPrm
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP19MinPrmViewModel
                      {
                          Id = a.Id,
                          PolicyVid = a.PolicyVid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          Reshte = a.Reshte,
                          ReshteName = a.ReshteName,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
               
                          Sarmaye = a.Sarmaye,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          Nationalcode = a.Nationalcode,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          Prm = a.Prm,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP19MinPrmViewModel OpenRecordFireP19MinPrm(int? id)
        {
            var obj = (from a in _context.FireP19_MinPrm
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP19MinPrmViewModel
                       {
                           Id = a.Id,
                           PolicyVid = a.PolicyVid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           Reshte = a.Reshte,
                           ReshteName = a.ReshteName,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                 
                           Sarmaye = a.Sarmaye,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           Nationalcode = a.Nationalcode,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           Prm = a.Prm,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP19MinPrm UpdateFireP19MinPrm(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP19_MinPrm
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }



        /// <summary>
        ///درصورتیکه حق بیمه کمتر از 2.000.000 ریال در رشته آتش سوزی مسکونی و کمتر از 2.000.000 ریال در رشته غیرصنعتی 
        ///و کمتر از 5.000.000 ریال در رشته صنعتی و انبارها باشد . حق بیمه باید همزمان با صدور بیمه نامه به حساب شرکت واریز شود.
        /// </summary>
        /// <returns></returns>
        /// 

        public IQueryable<FireP21CashPrmBnViewModel> GetFireP21CashPrmBn()
        {
            var res = from a in _context.FireP21_CashPrmBn
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP21CashPrmBnViewModel
                      {
                          Id = a.Id,
                          PrmSrdId = a.PrmSrdId,
                          Op = a.Op,
                          Ebdid = a.Ebdid,
                          MaliBid = a.MaliBid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          ReshteId = a.ReshteId,
                          ReshteName = a.ReshteName,
                          BeginDate = a.BeginDate,
                          BeginDateMiladi = a.BeginDateMiladi,
                          EndDate = a.EndDate,
                          EndDateMiladi = a.EndDateMiladi,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          VosulShode = a.VosulShode,
                          Remain = a.Remain,
                          PrmAsRial = a.PrmAsRial,
                          OperationType = a.OperationType,
                          CreditType = a.CreditType,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP21CashPrmBnViewModel OpenRecordFireP21CashPrmBn(int? id)
        {
            var obj = (from a in _context.FireP21_CashPrmBn
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP21CashPrmBnViewModel
                       {
                           Id = a.Id,
                           PrmSrdId = a.PrmSrdId,
                           Op = a.Op,
                           Ebdid = a.Ebdid,
                           MaliBid = a.MaliBid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           ReshteId = a.ReshteId,
                           ReshteName = a.ReshteName,
                           BeginDate = a.BeginDate,
                           BeginDateMiladi = a.BeginDateMiladi,
                           EndDate = a.EndDate,
                           EndDateMiladi = a.EndDateMiladi,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           VosulShode = a.VosulShode,
                           Remain = a.Remain,
                           PrmAsRial = a.PrmAsRial,
                           OperationType = a.OperationType,
                           CreditType = a.CreditType,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP21CashPrmBn UpdateFireP21CashPrmBn(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP21_CashPrmBn
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }


        /// <summary>
        ///حق بیمه الحاقیه های که منجر به افزایش تعهد مالی برای بیمه گذار می شود در تمامی رشته ها به صورت نقد می باشد.
        ///خارج از موارد فوق با تأیید و نظر کتبی مدیر فنی مربوطه حداکثر تا زمان اعتبار بیمه نامه امکان پذیر است
        /// </summary>
        /// <returns></returns>


        public IQueryable<FireP23CashPrmElhViewModel> GetFireP23CashPrmElh()
        {
            var res = from a in _context.FireP23_CashPrmElh
                      join b in _context.tblPrvStatus on a.Status equals b.Id
                      select new FireP23CashPrmElhViewModel
                      {

                          Id = a.Id,
                          PrmSrdId = a.PrmSrdId,
                          Op = a.Op,
                          Ebdid = a.Ebdid,
                          MaliBid = a.MaliBid,
                          PolicyId = a.PolicyId,
                          Bno = a.Bno,
                          ElhNo = a.ElhNo,
                          BnSodurDate = a.BnSodurDate,
                          BnSodurDateMiladi = a.BnSodurDateMiladi,
                          ReshteId = a.ReshteId,
                          ReshteName = a.ReshteName,
                          BeginDate = a.BeginDate,
                          BeginDateMiladi = a.BeginDateMiladi,
                          EndDate = a.EndDate,
                          EndDateMiladi = a.EndDateMiladi,
                          AgentId = a.AgentId,
                          AgentName = a.AgentName,
                          SodurId = a.SodurId,
                          SodurName = a.SodurName,
                          BranchId = a.BranchId,
                          BranchName = a.BranchName,
                          CustomerId = a.CustomerId,
                          CustomerName = a.CustomerName,
                          UserId = a.UserId,
                          UserName = a.UserName,
                          VosulShode = a.VosulShode,
                          Remain = a.Remain,
                          PrmAsRial = a.PrmAsRial,
                          OperationType = a.OperationType,
                          CreditType = a.CreditType,
                          Comment = a.Comment,
                          Status = a.Status,
                          CreateDate = a.CreateDate,
                          StatusName = b.StatusName
                      };
            return res;
        }
        public FireP23CashPrmElhViewModel OpenRecordFireP23CashPrmElh(int? id)
        {
            var obj = (from a in _context.FireP23_CashPrmElh
                       join b in _context.tblPrvStatus on a.Status equals b.Id
                       where a.Id == id
                       select new FireP23CashPrmElhViewModel
                       {

                           Id = a.Id,
                           PrmSrdId = a.PrmSrdId,
                           Op = a.Op,
                           Ebdid = a.Ebdid,
                           MaliBid = a.MaliBid,
                           PolicyId = a.PolicyId,
                           Bno = a.Bno,
                           ElhNo = a.ElhNo,
                           BnSodurDate = a.BnSodurDate,
                           BnSodurDateMiladi = a.BnSodurDateMiladi,
                           ReshteId = a.ReshteId,
                           ReshteName = a.ReshteName,
                           BeginDate = a.BeginDate,
                           BeginDateMiladi = a.BeginDateMiladi,
                           EndDate = a.EndDate,
                           EndDateMiladi = a.EndDateMiladi,
                           AgentId = a.AgentId,
                           AgentName = a.AgentName,
                           SodurId = a.SodurId,
                           SodurName = a.SodurName,
                           BranchId = a.BranchId,
                           BranchName = a.BranchName,
                           CustomerId = a.CustomerId,
                           CustomerName = a.CustomerName,
                           UserId = a.UserId,
                           UserName = a.UserName,
                           VosulShode = a.VosulShode,
                           Remain = a.Remain,
                           PrmAsRial = a.PrmAsRial,
                           OperationType = a.OperationType,
                           CreditType = a.CreditType,
                           Comment = a.Comment,
                           Status = a.Status,
                           CreateDate = a.CreateDate,
                           StatusName = b.StatusName

                       }).FirstOrDefault();

            return obj;
        }
        public FireP23CashPrmElh UpdateFireP23CashPrmElh(string comment, int id, int statusId)
        {
            var obj = (from a in _context.FireP23_CashPrmElh
                       where a.Id == id
                       select a).FirstOrDefault();
            obj.Comment = comment;
            obj.Status = statusId;
            _context.SaveChanges();
            return obj;
        }


    }
}
