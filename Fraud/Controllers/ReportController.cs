using ClosedXML.Excel;
using Fraud.Convertor;
using Fraud.Services;
using Fraud.Models.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Session;
using X.PagedList;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Fraud.Infrastructure.Cache;
using Fraud.Security;

namespace Fraud.Controllers
{
    //api/
    [Route("/[controller]/[action]")]
    [ApiController]
   // [PermissionChecker(9)]
    [Authorize]
    public class ReportController : Controller
    {

        private readonly IServices _sv;
        readonly ICacheProvider _cache;
        public ReportController(IServices sv, ICacheProvider cache)
        {
            _cache = cache;
            _sv = sv;
        }
        //  GET
        //public IActionResult Index(int pg =1)
        //{
        //    List<Sales15ViewModel> Ply = _sv.GetSales15();
        //    const int pageSize = 10;
        //    if (pg<1)
        //    {
        //        pg = 1;
        //    }
        //    int recsCount = Ply.Count();
        //    var pager = new Pager(recsCount , pg , pageSize);
        //    int resSkip = (pg - 1) * pageSize;
        //    var data = Ply.Skip(resSkip).Take((int)pager.PageSize).ToList();
        //    this.ViewBag.Pager = pager;
        //    return View(data);
        //   // return View(Ply);
        //}

        #region Car

        #region Third Party Policy 
        #region شاخص یک  صدور ثالث مبلغ پیش پرداخت بیمه نامه
        /// <summary>
        /// شاخص یک صدور ثالث : مبلغ پیش پرداخت بیمه نامه- کل حق بیمه 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult SalesP1LessPishPardakhtGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalesP1LessPishPardakhtPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesP1LessPishPardakhtViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetSalesP1LessPishPardakht());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult SalesP1LessPishPardakhtAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordSalesP1LessPishPardakht(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("SalesP1LessPishPardakhtAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult SalesP1LessPishPardakhtAddcmtPost(SalesP1LessPishPardakhtViewModel sales)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateSalesP1LessPishPardakht(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }


        [HttpPost]
        public IActionResult SalesP1LessPishPardakhtToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(SalesP1LessPishPardakhtGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportSalesP1LessPishPardakhtToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[15] {new DataColumn("کد مالی بیمه نامه"),
                                                    new DataColumn("کد بیمه نامه "),
                                                    new DataColumn("کد قرارداد"),
                                                    new DataColumn("نوع مشتری"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام واحد معرف"),
                                                    new DataColumn("نام واحد صدور"),
                                                    new DataColumn("نام شعبه واحد صدور"),
                                                    new DataColumn("مبلغ قسط"),
                                                    new DataColumn("مبلغ بیمه نامه"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(SalesP1LessPishPardakhtGet)));
            var parser = new Parser<SalesP1LessPishPardakhtViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetSalesP1LessPishPardakht());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.MaliBid, item.PolicyId, item.SodurGid, item.PersonkindName, item.BnSodurDate,
                             item.CustomerName, item.Nationalcode, item.AgentName, item.BnSodurName,
                             item.BranchName, item.GhestAmount, item.PrmAmount, item.UserName,
                             item.Comment, item.Status
                             );
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }

        #endregion

        #region شاخص دو صدور ثالث شرایط اعلام بدهکار بیمه نامه 
        /// <summary>
        /// شاخص دو صدور ثالث : شرایط اعلام بدهکار بیمه نامه 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult SalesP2AghsatGreater6Get()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalesP2AghsatGreater6Post()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesP2AghsatGreater6ViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetSalesP2AghsatGreater6());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult SalesP2AghsatGreater6AddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordSalesP2AghsatGreater6(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("SalesP2AghsatGreater6AddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult SalesP2AghsatGreater6AddcmtPost(SalesP2AghsatGreater6ViewModel sales)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateSalesP2AghsatGreater6(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult SalesP2AghsatGreater6ToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(SalesP2AghsatGreater6Get)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportSalesP2AghsatGreater6ToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[15] {new DataColumn("کد مالی بیمه نامه"),
                                                    new DataColumn("کد بیمه نامه "),
                                                    new DataColumn("شماره بیمه نامه "),
                                                    new DataColumn("تاریخ  صدور بیمه نامه"),
                                                    new DataColumn("نام بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("شناسه ملی"),
                                                    new DataColumn("نام واحد نمایندگی"),
                                                    new DataColumn("نام واحد صدور"),
                                                    new DataColumn("نام شعبه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("تاریخ سررسید"),
                                                    new DataColumn("نام کاربر") ,
                                                    new DataColumn("وضعیت پرونده"),
                                                    new DataColumn("توضیحات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(SalesP2AghsatGreater6Get)));
            var parser = new Parser<SalesP2AghsatGreater6ViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetSalesP2AghsatGreater6());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.MaliBid, item.PolicyId, item.Bno, item.BnSodurDate, item.CustomerName,
                             item.Nationalcode, item.CompanyCode, item.AgentName, item.BnSodurName,
                             item.BranchName, item.FvsodurDate, item.SaresidDate, item.UserName, item.Status, item.Comment);

            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }

        #endregion

        #region شاخص سه صدور ثالث : تخفیفات بیمه نامه
        /// <summary>
        /// شاخص سه صدور ثالث : تخفیفات بیمه نامه - تاریخ شماره گذاری - تاریخ شروع بیمه نامه   
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpGet]
        public IActionResult SalesP3PelakSodurDateDiscountGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalesP3PelakSodurDateDiscountPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesP3PelakSodurDateDiscountViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetSalesP3PelakSodurDateDiscount());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult SalesP3PelakSodurDateDiscountAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordSalesP3PelakSodurDateDiscount(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("SalesP3PelakSodurDateDiscountAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult SalesP3PelakSodurDateDiscountAddcmtPost(SalesP3PelakSodurDateDiscountViewModel sales)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateSalesP3PelakSodurDateDiscount(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult SalesP3PelakSodurDateDiscountToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(SalesP3PelakSodurDateDiscountGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportSalesP3PelakSodurDateDiscountToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[16] {new DataColumn("کد  بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه "),
                                                    new DataColumn("شماره الحاقیه"),
                                                    new DataColumn("تاریخ صدور  بیمه نامه"),
                                                    new DataColumn("تاریخ صدور الحاقیه"),
                                                    new DataColumn("تاریخ پلاک"),
                                                    new DataColumn("تفاوت تاریخ "),
                                                    new DataColumn("نام بیمه گذار"),
                                                    new DataColumn("کد ملی "),
                                                    new DataColumn("شناسه ملی"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه صدور"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت پرونده"),
                                                    new DataColumn("توضیحات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(SalesP3PelakSodurDateDiscountGet)));
            var parser = new Parser<SalesP3PelakSodurDateDiscountViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetSalesP3PelakSodurDateDiscount());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.ElhNo, item.VsodurDate, item.BnsodurDate, item.PelakDate,
                            item.DateDifference, item.CustomerName, item.Nationalcode, item.CompanyCode,
                            item.AgentName, item.BnSodurName, item.BranchName, item.UserName, item.Status, item.Comment);

            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }
        #endregion

        #region شاخص سه صدور ثالث : تخفیفات بیمه نامه
        /// <summary>
        /// شاخص سه صدور ثالث : تخفیفات بیمه نامه - تاریخ شماره گذاری - تاریخ شروع بیمه نامه   
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpGet]
        public IActionResult SalesP4MalekCustomerGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalesP4MalekCustomerPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesP4MalekCustomerViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetSalesP4MalekCustomer());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult SalesP4MalekCustomerAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordSalesP4MalekCustomer(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("SalesP4MalekCustomerAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult SalesP4MalekCustomerAddcmtPost(SalesP4MalekCustomerViewModel sales)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateSalesP4MalekCustomer(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };
            }
            return Json(result);
        }


        [HttpPost]
        public IActionResult SalesP4MalekCustomerToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(SalesP4MalekCustomerGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportSalesP4MalekCustomerToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[15] {new DataColumn("کد  بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه "),
                                                    new DataColumn("شماره الحاقیه"),
                                                    new DataColumn("تاریخ صدور الحاقیه"),
                                                    new DataColumn("مالک"),
                                                    new DataColumn("کد ملی مالک"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("شناسه ملی"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه صدور"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت پرونده"),
                                                    new DataColumn("توضیحات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(SalesP4MalekCustomerGet)));
            var parser = new Parser<SalesP4MalekCustomerViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetSalesP4MalekCustomer());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.ElhNo, item.VsodurDate, item.OwnerName, item.OwnerNationalCode,
                            item.CustomerName, item.CodeMelli, item.AgentName, item.BnSodurName,
                            item.BranchName, item.UserName, item.StatusName, item.Comment);

            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }
        #endregion


        /// <summary>
        /// شاخص شماره 5 ثالث : اشخاص ها با اطلاعات ناقص 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SalesP5TroubledCustomerGet()
        {
            return View("SalesP5TroubledCustomerGet");
        }
        [HttpPost]
        public IActionResult SalesP5TroubledCustomerPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesP5TroubledCustomerViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetSalesP5TroubledCustomer());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult SalesP5TroubledCustomerAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordSalesP5TroubledCustomer(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("SalesP5TroubledCustomerAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult SalesP5TroubledCustomerAddcmtPost(SalesP5TroubledCustomerViewModel sales)
        {


            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateSalesP5TroubledCustomer(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult SalesP5TroubledCustomerToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(SalesP5TroubledCustomerGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportSalesP5TroubledCustomerToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[14] {
                                                    new DataColumn("کد رایانه بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه"),
                                                    new DataColumn("کد بیمه گذار"),
                                                    new DataColumn("نوع شخص"),
                                                    new DataColumn("نوع شخص "),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("کد پستی"),
                                                    new DataColumn("آدرس"),
                                                    new DataColumn("موبایل"),
                                                    new DataColumn("وضعیت بررسی"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(SalesP5TroubledCustomerGet)));
            var parser = new Parser<SalesP5TroubledCustomerViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetSalesP5TroubledCustomer());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.AgentName, item.BnSodurName, item.BranchName, item.CustomerId, item.PersonKindText, item.CodeMelli, item.CodePosti,
                             item.Address, item.Mobile, item.StatusName, item.Comment);



            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }




        /// <summary>
        /// شاخص شماره 6 ثالث : خودرو ها با اطلاعات ناقص 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SalesP6TroubledKhodroGet()
        {
            return View("SalesP6TroubledKhodroGet");
        }
        [HttpPost]
        public IActionResult SalesP6TroubledKhodroPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesP6TroubledKhodroViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetSalesP6TroubledKhodro());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult SalesP6TroubledKhodroAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordSalesP6TroubledKhodro(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("SalesP6TroubledKhodroAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult SalesP6TroubledKhodroAddcmtPost(SalesP6TroubledKhodroViewModel sales)
        {


            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateSalesP6TroubledKhodro(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult SalesP6TroubledKhodroToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(SalesP6TroubledKhodroGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportSalesP6TroubledKhodroToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[13] {
                                                    new DataColumn("کد رایانه بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه"),
                                                    new DataColumn("کد خودرو"),
                                                    new DataColumn("شماره شاسی"),
                                                    new DataColumn("شماره پلاک "),
                                                    new DataColumn("vin "),
                                                    new DataColumn("شماره موتور"),
                                                    new DataColumn("کاربر ثبت کننده"),
                                                    new DataColumn("وضعیت بررسی"),
                                                    new DataColumn("نظرات"),
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(SalesP6TroubledKhodroGet)));
            var parser = new Parser<SalesP6TroubledKhodroViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetSalesP6TroubledKhodro());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.AgentName, item.BnSodurName, item.BranchName, item.KhodroId, item.ShasiNo, item.PelakNo, item.Vin,
                            item.MotorNo, item.UserName, item.StatusName, item.Comment);




            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }


        #region سال ساخت خودرو- سال تخفیف سنواتی اعمال شده 
        /// <summary>
        /// شاخص هفت صدور ثالث :سال ساخت خودرو- سال تخفیف سنواتی اعمال شده 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult SalesP7SalSahkhtSanavatDiscountGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalesP7SalSahkhtSanavatDiscountPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesP7SalSahkhtSanavatDiscountViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetSalesP7SalSahkhtSanavatDiscount());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult SalesP7SalSahkhtSanavatDiscountAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordSalesP7SalSahkhtSanavatDiscount(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("SalesP7SalSahkhtSanavatAddcmtDiscountGet", obj);
        }

        [HttpPost]
        public IActionResult SalesP7SalSahkhtSanavatDiscountAddcmtPost(SalesP7SalSahkhtSanavatDiscountViewModel sales)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateSalesP7SalSahkhtSanavatDiscount(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }

                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }


        [HttpPost]
        public IActionResult SalesP7SalSahkhtSanavatDiscountToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(SalesP7SalSahkhtSanavatDiscountGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportSalesP7SalSahkhtSanavatDiscountToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[16] {new DataColumn("کد  بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("سال ساخت شمسی"),
                                                    new DataColumn("سال ساخت میلادی"),
                                                    new DataColumn("تفاوت تاریخ "),
                                                    new DataColumn("سابقه جانی"),
                                                    new DataColumn("نام بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("شناسه ملی"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه صدور") ,
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت پرونده"),
                                                    new DataColumn("توضیحات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(SalesP7SalSahkhtSanavatDiscountGet)));
            var parser = new Parser<SalesP7SalSahkhtSanavatDiscountViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetSalesP7SalSahkhtSanavatDiscount());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.BnSodurDate, item.SalSakhtShamsi, item.SalSakhtMiladi,
                            item.TafavotSal, item.SabeghJaniName, item.CustomerName, item.Nationalcode, item.CompanyCode,
                            item.AgentName, item.BnSodurName, item.BranchName, item.UserName, item.Status, item.Comment);

            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }
        #endregion

        #endregion

        #region Third Party Damage  

        #region شاخص شماره یک خسارت ثالث
        /// <summary>
        /// شاخص شماره یک خسارت ثالث: کاربری وسیله نقلیه در بیمه نامه 
        /// و در زمان وقوع خسارت
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult SalesD1KarbariGet()
        {
            return View();
        }//SalesDamageKpi1Get

        [HttpPost]
        public IActionResult SalesD1KarbariPost()
        {
            try
            {
                //HttpContext.Session.SetString(string.Join("-",User.Identity.Name,nameof(SalesD1KarbariPost)), "");
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesD1KarbariViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetSalesD1Karbari());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }//SalesDamageKpi1Post

        [HttpGet]
        [Route("{Id}")]
        public IActionResult SalesD1KarbariAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordSalesD1Karbari(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("SalesD1KarbariAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult SalesD1KarbariAddcmtPost(SalesD1KarbariViewModel sales)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateSalesD1Karbari(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }


        [HttpPost]
        public IActionResult SalesD1KarbariToExcel()
        {
            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(SalesD1KarbariGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportSalesD1KarbariToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[20] {new DataColumn("کد  بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه "),
                                                    new DataColumn("شماره  پرونده"),
                                                    new DataColumn("تاریخ شروع بیمه نامه"),
                                                    new DataColumn("تاریخ پایان بیمه نامه"),
                                                    new DataColumn("تاریخ پرونده"),
                                                    new DataColumn("تاریخ حادثه"),
                                                    new DataColumn("آدرس محل حادثه"),
                                                    new DataColumn("علت حادثه"),
                                                    new DataColumn("نوع گواهی نامه"),
                                                    new DataColumn("مورد استفاده"),
                                                    new DataColumn("کد خودرو"),
                                                    new DataColumn("نام خودرو"),
                                                    new DataColumn("نام واحد تشکیل پرونده"),
                                                    new DataColumn("نام شعبه صدور بیمه نامه"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("مبلغ خسارت"),
                                                    new DataColumn("نوع خسارت") ,
                                                    new DataColumn("وضعیت پرونده"),
                                                    new DataColumn("توضیحات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(SalesD1KarbariGet)));
            var parser = new Parser<SalesD1KarbariViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetSalesD1Karbari());
            var data = parser.Parse();
            var lst = from ply in data.data   
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.PrvNo, item.BeginDate, item.EndDate,item.PrvDate,
                            item.HadeseDate, item.HadeseAddress, item.ElatHadeseName, item.GovahiTypeName,
                            item.MoredEstefadeName, item.KhodroListId, item.KhodroKindName,
                            item.DamageSodurName ,item.BranchName, item.UserName, item.SumHvPayAmountAsRial,
                            item.DamageType, item.StatusName, item.Comment);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }

        }

        #endregion

        #region شاخص شماره دو خسارت ثالث
        /// <summary>
        /// نوع حادثه - تخلفات حادثه ساز -اطلاعات مالی ریکاوری 
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public IActionResult SalesD2TakhalofHadeseSazGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalesD2TakhalofHadeseSazPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesD2TakhalofHadeseSazViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetSalesD2TakhalofHadeseSaz());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult SalesD2TakhalofHadeseSazAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordSalesD2TakhalofHadeseSaz(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("SalesD2TakhalofHadeseSazAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult SalesD2TakhalofHadeseSazAddcmtPost(SalesD2TakhalofHadeseSazViewModel sales)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateSalesD2TakhalofHadeseSaz(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult SalesD2TakhalofHadeseSazToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(SalesD2TakhalofHadeseSazGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportSalesD2TakhalofHadeseSazToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[17] {new DataColumn("کد  بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("شناسه ملی"),
                                                    new DataColumn("کد پرونده"),
                                                    new DataColumn("شماره پرونده"),
                                                    new DataColumn("علت حادثه"),
                                                    new DataColumn("تاریخ پرونده"),
                                                    new DataColumn("تاریخ حادثه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("واحد تشکیل پرونده"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("وضعیت بررسی پرونده"),
                                                    new DataColumn("توضیحات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(SalesD2TakhalofHadeseSazGet)));
            var parser = new Parser<SalesD2TakhalofHadeseSazViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetSalesD2TakhalofHadeseSaz());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.BnSodurDate, item.CustomerName,
                            item.Nationalcode, item.CompanyCode, item.PrvId, item.PrvNo,
                            item.ElatHadeseName, item.PrvDate, item.HadeseDate, item.AgentName,
                            item.BnSodurName, item.PrvSodurName, item.BranchName, item.StatusName, item.Comment);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }


        /// <summary>
        /// نوع حادثه - پرونده های بازیافت تسویه نشده 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SalesD2BazyaftNotTasvieGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalesD2BazyaftNotTasviePost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesD2BazyaftNotTasvieViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetSalesD2BazyaftNotTasvie());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult SalesD2BazyaftNotTasvieAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordSalesD2BazyaftNotTasvie(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("SalesD2BazyaftNotTasvieAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult SalesD2BazyaftNotTasvieAddcmtPost(SalesD2BazyaftNotTasvieViewModel sales)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateSalesD2BazyaftNotTasvie(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult SalesD2BazyaftNotTasvieToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(SalesD2BazyaftNotTasvieGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportSalesD2BazyaftNotTasvieToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[23] {new DataColumn("کد  بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ شروع بیمه نامه"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("شناسه ملی"),
                                                    new DataColumn("کد پرونده"),
                                                    new DataColumn("شماره پرونده"),
                                                    new DataColumn("علت حادثه"),
                                                    new DataColumn("تاریخ پرونده"),
                                                    new DataColumn("تاریخ حادثه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("واحد تشکیل پرونده"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("تاریخ حواله"),
                                                    new DataColumn("کد حواله"),
                                                    new DataColumn("شماره حواله"),
                                                    new DataColumn("وضعیت بررسی پرونده"),
                                                    new DataColumn("مبلغ حواله"),
                                                    new DataColumn("مانده حواله"),
                                                    new DataColumn("وضعیت بررسی"),
                                                    new DataColumn("توضیحات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(SalesD2BazyaftNotTasvieGet)));
            var parser = new Parser<SalesD2BazyaftNotTasvieViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetSalesD2BazyaftNotTasvie());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.BnSodurDate, item.CustomerName,
                            item.Nationalcode, item.CompanyCode, item.PrvId, item.PrvNo,
                            item.ElatHadeseName, item.PrvDate, item.HadeseDate, item.AgentName,
                            item.BnSodurName, item.PrvSodurName, item.BranchName, item.Hvdate,
                            item.Hvid, item.Hvno, item.HvamountAsRial, item.HvgusableAmountAsRial,
                            item.Status, item.Comment);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }
        #endregion

        #region شاخص شماره سه خسارت ثالث
        /// <summary>
        /// شاخص شماره سه خسارت ثالث : نوع خودرو در بیمه نامه - نوع گواهی نامه 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult SalesD3GovahiCarTypeGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalesD3GovahiCarTypePost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesD3GovahiCarTypeViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetSalesD3GovahiCarType());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult SalesD3GovahiCarTypeAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordSalesD3GovahiCarType(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("SalesD3GovahiCarTypeAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult SalesD3GovahiCarTypeAddcmtPost(SalesD3GovahiCarTypeViewModel sales)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateSalesD3GovahiCarType(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult SalesD3GovahiCarTypeToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(SalesD3GovahiCarTypeGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportSalesD3GovahiCarTypeToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[21] {new DataColumn("کد  بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نوع گواهینامه"),
                                                    new DataColumn("گروه خودرو"),
                                                    new DataColumn("نام خودرو"),
                                                    new DataColumn("تعداد سرنشین"),
                                                    new DataColumn("تناژ"),
                                                    new DataColumn("کد پرونده"),
                                                    new DataColumn("شماره پرونده"),
                                                    new DataColumn("تاریخ پرونده"),
                                                    new DataColumn("تاریخ حادثه"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("شناسه ملی"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("کاربر"),
                                                    new DataColumn("وضعیت بررسی پرونده"),
                                                    new DataColumn("توضیحات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(SalesD3GovahiCarTypeGet)));
            var parser = new Parser<SalesD3GovahiCarTypeViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetSalesD3GovahiCarType());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.BnSodurDate, item.GovahiTypeName,
                            item.KhodroGoruhName, item.KhodroKindCaption, item.SarneshinCount,
                            item.Tonaje, item.PrvId, item.PrvNo, item.PrvDate, item.HadeseDate,
                            item.CustomerName, item.Nationalcode, item.CompanyCode, item.AgentName,
                            item.BnSodurName, item.BranchName, item.UserName, item.StatusName, item.Comment);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }

        #endregion

        #region شاخص شماره شش خسارت ثالث
        /// <summary>
        /// شاخص شماره شش خسارت ثالث: تاریخ صدور بیمه نامه - تاریخ وقوع حادثه 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult SalesD6DayDamageGet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SalesD6DayDamagePost()
        {
            //try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesD6DayDamageViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetSalesD6DayDamage());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            //catch (Exception ex)
            //{
            //    return null;
            //}
        }

        [HttpGet]
        [Route("{policyId}")]
        public IActionResult SalesD6DayDamageDetailGet(int policyId)  //SalesDataListDetail
        {
            TempData["policyId"] = policyId;
            return View("SalesD6DayDamageDetailGet");  ///SalesD6DayDamageDetailView   SalesDataListDetail
        }

        [HttpPost]
        public IActionResult SalesD6DayDamageDetailPost() ///GetSalesDataListDetail
        {
            try
            {
                var policyId = TempData["policyId"] != null ? int.Parse(TempData["policyId"].ToString()) : -1;
                if (policyId < 0)
                {
                    return null;
                }
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesD6DayDamageDetailViewModel>(ToNameValueCollection<string, string>(dict), _sv.GetSalesD6DayDamageDetail(policyId));
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult SalesD6DayDamageAddCmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordSalesD6DayDamage(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("SalesD6DayDamageAddCmtGet", obj);
        }

        [HttpPost]
        public IActionResult SalesD6DayDamageAddCmtPost(SalesD6DayDamageViewModel sales)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateSalesD6DayDamage(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }



        [HttpPost]
        public IActionResult SalesD6DayDamageToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(SalesD6DayDamageGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportSalesD6DayDamageToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[17] {new DataColumn("کد  بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه "),
                                                    new DataColumn("کد  پرونده"),
                                                    new DataColumn("شماره پرونده"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("تاریخ حادثه"),
                                                    new DataColumn("تعداد روز تفاوت"),
                                                    new DataColumn("تاریخ پرونده"),
                                                    new DataColumn("نوع خسارت"),
                                                    new DataColumn(" نام نمایندگی"),
                                                    new DataColumn("نام واحد صدور"),
                                                    new DataColumn("نام سرپرست واحد  صدور"),
                                                    new DataColumn("علت حادثه"),
                                                    new DataColumn("محل تشکیل پرونده"),
                                                    new DataColumn("کاربر ثبت کننده بیمه نامه"),
                                                    new DataColumn(" کاربر ثبت کننده پرونده") ,
                                                    new DataColumn(" تاریخ پایان بیمه نامه سال قبل")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(SalesD6DayDamageGet)));
            var parser = new Parser<SalesD6DayDamageViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetSalesD6DayDamage());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.PrvId, item.PrvNo, item.BnSodurDate, item.HadeseDate, item.DateDifference, item.PrvDate, item.DamageMoredName,
                item.AgentName, item.SodurName, item.BranchName, item.ElatHadeseName, item.PrvSodurName, item.BnUserName, item.PrvUserName, item.LastBnEndDate);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }
        #endregion

        #region شاخص شماره هفت خسارت ثالث

        /// <summary>
        /// شاخص شماره 7 خسارت ثالث : تاریخ اقساط - تاریخ واریزیها - تاریخ وقوع حادثه 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult SalesD7InstallmentGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalesD7InstallmentGetPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<SalesD7InstallmentWithHvViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetSalesD7InstallmentWithHv());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult SalesD7InstallmentWithHvAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordSalesD7InstallmentWithHv(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("SalesD7InstallmentWithHvAddcmtGet", obj);
        }
        [HttpPost]
        public IActionResult SalesD7InstallmentWithHvAddcmtPost(SalesD7InstallmentWithHvViewModel sales)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateSalesD7InstallmentWithHv(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult SalesD7InstallmentWithHvToExcel()
        {
            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(SalesD7InstallmentGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportSalesD7InstallmentWithHvToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[30] {new DataColumn("کد قلم دریافتی"),
                                                    new DataColumn("کد بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه "),
                                                    new DataColumn("شماره الحاقیه "),
                                                    new DataColumn("نام واحد معرف"),
                                                    new DataColumn("نام واحد صدور"),
                                                    new DataColumn("نام بیمه گذار"),
                                                    new DataColumn("شماره پرونده"),
                                                    new DataColumn("تاریخ پرونده"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("تاریخ شروع بیمه نامه"),
                                                    new DataColumn("تاریخ پایان بیمه نامه"),
                                                    new DataColumn("تاریخ سررسید"),
                                                    new DataColumn("تاریخ عملیات"),
                                                    new DataColumn("نوع تسویه"),
                                                    new DataColumn("مبلغ قسط"),
                                                    new DataColumn("مبلغ تسویه"),
                                                    new DataColumn("مبلغ تسویه نشده"),
                                                    new DataColumn("مبلغ وصول شده"),
                                                    new DataColumn("نوع عملیات تسویه"),
                                                    new DataColumn("نوع بستانکاری"),
                                                    new DataColumn("تاریخ وصول"),
                                                    new DataColumn("تاریخ تحویل"),
                                                    new DataColumn("وضعیت وصول"),
                                                    new DataColumn("نوع رسید"),
                                                    new DataColumn("تاریخ اعلام"),
                                                    new DataColumn("تاریخ حادثه"),
                                                    new DataColumn("مبلغ حواله"),
                                                    new DataColumn("وضعیت بررسی پرونده") ,
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(SalesD7InstallmentGet)));
            var parser = new Parser<SalesD7InstallmentWithHvViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetSalesD7InstallmentWithHv());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PrmSrdId, item.PolicyId, item.Bno, item.ElhNo, item.AgentName, item.SodurName, item.CustomerName,
                            item.PrvNo, item.PrvDate, item.BnSodurDate, item.BeginDate, item.EndDate, item.SrdDate, item.OpDate,
                            item.TasvieType, item.SrdAmountAsRial, item.TasvieAmount, item.TasvieNashode, item.VosulShode,
                            item.AmaliatTasvieType, item.CreditType, item.VslStateDate, item.DeliverDate, item.VslStateName,
                            item.RcvdKindName, item.ElamDate, item.HadeseDate, item.HvAmount,
                            item.Status, item.Comment);

            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }


        // export to excel ???
        #endregion

        #endregion

        #region Body Policy 
        #region شاخص شماره یک صدور بدنه 
        /// <summary>
        /// شاخص شماره یک صدور بدنه: نوع خودرو - پوشش اضافی بیمه نامه
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult BdP1206pusheshGet()
        {
            return View("BdP1206pusheshGet");
        }
        [HttpPost]
        public IActionResult BdP1206pusheshPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<BdP1206pusheshViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetBdP1206pushesh());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult BdP1206pusheshAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordBdP1206pushesh(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("BdP1206pusheshAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult BdP1206pusheshAddcmtPost(BdP1206pusheshViewModel sales)
        {


            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateBdP1206pushesh(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult BdP1206pusheshToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(BdP1206pusheshGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportBdP1206pusheshToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[14] {new DataColumn("کد قلم دریافتی"),
                                                    new DataColumn("کد بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه "),
                                                    new DataColumn("شماره الحاقیه "),
                                                    new DataColumn("نام واحد معرف"),
                                                    new DataColumn("نام واحد صدور"),
                                                    new DataColumn("نام بیمه گذار"),
                                                    new DataColumn("شماره پرونده"),
                                                    new DataColumn("تاریخ پرونده"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("تاریخ شروع بیمه نامه"),
                                                    new DataColumn("تاریخ پایان بیمه نامه"),
                                                    new DataColumn("تاریخ سررسید"),
                                                    new DataColumn("تاریخ عملیات")

                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(BdP1206pusheshGet)));
            var parser = new Parser<BdP1206pusheshViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetBdP1206pushesh());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.ElhNo, item.KhodroName, item.SalSakht,
                             item.CustomerName, item.Nationalcode, item.CompanyCode, item.AgentName,
                             item.BnSodurName, item.BranchName, item.UserName, item.Status, item.Comment);



            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }
        #endregion

        #region شاخص شماره سه صدور بدنه 
        /// <summary>
        /// شاخص شماره سه صدور بدنه: تخفیفات اعمال شده - سال ساخت خودرو
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult BdP3NewCarDiscountGet()
        {
            return View("BdP3NewCarDiscountGet");
        }
        [HttpPost]
        public IActionResult BdP3NewCarDiscountPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<BdP3NewCarDiscountViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetBdP3NewCarDiscount());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult BdP3NewCarDiscountAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordBdP3NewCarDiscount(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("BdP3NewCarDiscountAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult BdP3NewCarDiscountAddcmtPost(BdP3NewCarDiscountViewModel sales)
        {


            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateBdP1206pushesh(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult BdP3NewCarDiscountToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(BdP3NewCarDiscountGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportBdP3NewCarDiscountToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[18] {new DataColumn("کد بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("شماره الحاقیه "),
                                                    new DataColumn("تاریخ صدور الحاقیه "),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("تاریخ صدور پلاک"),
                                                    new DataColumn("تفاوت تاریخ"),
                                                    new DataColumn("نرخ"),
                                                    new DataColumn("پوشش اضافی نرخ"),
                                                    new DataColumn("نام مشتری"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("شناسه ملی"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("کاربر ثبت"),
                                                    new DataColumn("وضعیت بررسی"),
                                                    new DataColumn("نظرات")

                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(BdP3NewCarDiscountGet)));
            var parser = new Parser<BdP3NewCarDiscountViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetBdP3NewCarDiscount());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.ElhNo, item.SodurDate, item.BnsodurDate, item.PelakDate,
                             item.TafavotPelakSodurDate, item.Nerkh, item.PusheshEzafiNerkh, item.CustomerName,
                             item.Nationalcode, item.CompanyCode, item.AgentName, item.BnSodurName, item.BranchName,
                             item.UserName, item.StatusName, item.Comment);



            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }


        /// <summary>
        /// شاخص شماره 4 بدنه : اشخاص ها با اطلاعات ناقص 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BdP4TroubledCustomerGet()
        {
            return View("BdP4TroubledCustomerGet");
        }
        [HttpPost]
        public IActionResult BdP4TroubledCustomerPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<BdP4TroubledCustomerViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetBdP4TroubledCustomer());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult BdP4TroubledCustomerAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordBdP4TroubledCustomer(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("BdP4TroubledCustomerAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult BdP4TroubledCustomerAddcmtPost(BdP4TroubledCustomerViewModel sales)
        {


            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateBdP4TroubledCustomer(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult BdP4TroubledCustomerToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(BdP4TroubledCustomerGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportBdP4TroubledCustomerToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[14] {
                                                    new DataColumn("کد رایانه بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه"),
                                                    new DataColumn("کد بیمه گذار"),
                                                    new DataColumn("نوع شخص"),
                                                    new DataColumn("نوع شخص "),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("کد پستی"),
                                                    new DataColumn("آدرس"),
                                                    new DataColumn("موبایل"),
                                                    new DataColumn("وضعیت بررسی"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(BdP4TroubledCustomerGet)));
            var parser = new Parser<BdP4TroubledCustomerViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetBdP4TroubledCustomer());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.AgentName, item.BnSodurName, item.BranchName, item.CustomerId, item.PersonKindText, item.CodeMelli, item.CodePosti,
                             item.Address, item.Mobile, item.StatusName, item.Comment);



            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }




        /// <summary>
        /// شاخص شماره 5 بدنه : خودرو ها با اطلاعات ناقص 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BdP5TroubledKhodroGet()
        {
            return View("BdP5TroubledKhodroGet");
        }
        [HttpPost]
        public IActionResult BdP5TroubledKhodroPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<BdP5TroubledKhodroViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetBdP5TroubledKhodro());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult BdP5TroubledKhodroAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordBdP5TroubledKhodro(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("BdP5TroubledKhodroAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult BdP5TroubledKhodroAddcmtPost(BdP5TroubledKhodroViewModel sales)
        {


            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateBdP5TroubledKhodro(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult BdP5TroubledKhodroToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(BdP5TroubledKhodroGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportBdP5TroubledKhodroToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[13] {
                                                    new DataColumn("کد رایانه بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه"),
                                                    new DataColumn("کد خودرو"),
                                                    new DataColumn("شماره شاسی"),
                                                    new DataColumn("شماره پلاک "),
                                                    new DataColumn("vin "),
                                                    new DataColumn("شماره موتور"),
                                                    new DataColumn("کاربر ثبت کننده"),
                                                    new DataColumn("وضعیت بررسی"),
                                                    new DataColumn("نظرات"),
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(BdP5TroubledKhodroGet)));
            var parser = new Parser<BdP5TroubledKhodroViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetBdP5TroubledKhodro());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId , item.Bno , item.AgentName , item.BnSodurName , item.BranchName,item.KhodroId, item.ShasiNo, item.PelakNo, item.Vin,
                            item.MotorNo, item.UserName, item.StatusName, item.Comment);




            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }


        #endregion
        #endregion

        #region Body Damage  

        #region شاخص شماره یک خسارت بدنه 
        /// <summary>
        /// شاخص شماره یک خسارت بدنه: کاربری وسیله نقلیه در بیمه نامه - کاربری وسیله نقلیه در زمان وقوع خسارت
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult BdD1KarbariGet()
        {
            return View("BdD1KarbariGet");
        }
        [HttpPost]
        public IActionResult BdD1KarbariPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<BdD1KarbariViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetBdD1Karbari());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult BdD1KarbariAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordBdD1Karbari(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("BdD1KarbariAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult BdD1KarbariAddcmtPost(BdD1KarbariViewModel sales)
        {


            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateBdD1Karbari(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult BdD1KarbariToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(BdD1KarbariGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportBdD1KarbariToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[25] {new DataColumn("کد  بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه "),
                                                    new DataColumn("شماره  پرونده"),
                                                    new DataColumn("تاریخ  پرونده"),
                                                    new DataColumn("تاریخ شروع بیمه نامه"),
                                                    new DataColumn("تاریخ پایان بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("تاریخ حادثه"),
                                                    new DataColumn("تاریخ صدور گواهینامه"),
                                                    new DataColumn("آدرس محل حادثه"),
                                                    new DataColumn("علت حادثه"),
                                                    new DataColumn("نوع گواهی نامه"),
                                                    new DataColumn("مورد استفاده"),
                                                    new DataColumn("کد خودرو"),
                                                    new DataColumn("نام خودرو"),
                                                    new DataColumn("واحد تشکیل پرونده"),
                                                    new DataColumn("شعبه صدور بیمه نامه"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("مبلغ خسارت"),
                                                    new DataColumn("ارزش خودرو"),
                                                    new DataColumn("سال ساخت میلادی"),
                                                    new DataColumn("سال ساخت شمسی"),
                                                    new DataColumn("نوع خسارت") ,
                                                    new DataColumn("وضعیت پرونده"),
                                                    new DataColumn("توضیحات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(BdD1KarbariGet)));
            var parser = new Parser<BdD1KarbariViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetBdD1Karbari());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.PrvNo, item.PrvDate,item.BeginDate, item.EndDate, item.BnSodurDate,
                            item.HadeseDate, item.GovahiSodurDate, item.HadesePlaceDesc, item.ElatHadeseName,
                            item.GovahiTypeName, item.MoredEstefadeName, item.KhodroListId, item.KhodrokindName,
                            item.DamageSodurName, item.BranchName,item.UserName, item.SumHvPayAmountAsRial, item.KhodroArzeshAsRial,
                            item.SalSakhtMiladi, item.SalSakhtShamsi, item.BdHadeseKindName, item.StatusName, item.Comment);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }
        #endregion

        #region شاخص شماره دو خسارت بدنه 
        /// <summary>
        /// شاخص شماره دو خسارت بدنه: تاریخ صدور گواهی نامه - فرانشیز مندرج در فرم محاسبه
        /// </summary>
        /// <returns></returns>
        public IActionResult BdD2FranshizGet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BdD2FranshizPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<BdD2FranshizViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetBdD2Franshiz());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult BdD2FranshizAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordBdD2Franshiz(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("BdD2FranshizAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult BdD2FranshizAddcmtPost(BdD2FranshizViewModel sales)
        {


            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateBdD2Franshiz(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult BdD2FranshizToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(BdD2FranshizGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportBdD2FranshizToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[20] {new DataColumn("کد پرونده"),
                                                    new DataColumn("شماره پرونده"),
                                                    new DataColumn("تاریخ پرونده "),
                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("شماره الحاقیه"),
                                                    new DataColumn("تاریخ صدور الحاقیه"),
                                                    new DataColumn("تاریخ صدور گواهی نامه"),
                                                    new DataColumn("تفاوت تاریخ "),
                                                    new DataColumn("نام بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("شناسه ملی"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه صدور"),
                                                    new DataColumn("واحد صدور خسارت"),
                                                    new DataColumn("کاربر ثبت بیمه نامه"),
                                                    new DataColumn("کاربر ثبت پرونده خسارت"),
                                                    new DataColumn("وضعیت بررسی پرونده") ,
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(BdD2FranshizGet)));
            var parser = new Parser<BdD2FranshizViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetBdD2Franshiz());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PrvId, item.PrvNo, item.PrvDate, item.PolicyId, item.Bno, item.ElhNo, item.VsodurDate,
                            item.GovahiSodurDate, item.Tafavot, item.CustomerName, item.Nationalcode, item.CompanyCode,
                            item.AgentName, item.BnSodurName, item.BranchName, item.PrvSodurName,
                            item.BnUserName, item.PrvUserName, item.Status, item.Comment);





            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }


        #endregion

        #region شاخص شماره سه خسارت بدنه 
        /// <summary>
        /// شاخص شماره سه خسارت بدنه: کاربری وسیله نقلیه در بیمه نامه - کاربری وسیله نقلیه در زمان وقوع خسارت
        /// </summary>
        /// <returns></returns>
        public IActionResult BdD3GovahiCarTypeGet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BdD3GovahiCarTypePost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<BdD3GovahiCarTypeViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetBdD3GovahiCarType());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult BdD3GovahiCarTypeAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordBdD3GovahiCarType(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("BdD3GovahiCarTypeAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult BdD3GovahiCarTypeAddcmtPost(BdD3GovahiCarTypeViewModel sales)
        {


            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateBdD3GovahiCarType(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult BdD3GovahiCarTypeToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(BdD3GovahiCarTypeGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportBdD3GovahiCarTypeToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[23] {
                                                    new DataColumn("کد بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه "),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نوع گواهینامه"),
                                                    new DataColumn("نام گروه خودرو"),
                                                    new DataColumn("کد خودرو"),
                                                    new DataColumn("نام خودرو"),
                                                    new DataColumn("تعداد سرنشین"),
                                                    new DataColumn("تناژ"),
                                                    new DataColumn("کد پرونده"),
                                                    new DataColumn("شماره پرونده"),
                                                    new DataColumn("تاریخ پرونده"),
                                                    new DataColumn("تاریخ حادثه"),
                                                    new DataColumn("نام بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("شناسه ملی"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("کاربر ثبت بیمه نامه"),
                                                    new DataColumn("کاربر ثبت پرونده"),
                                                    new DataColumn("وضعیت بررسی پرونده"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(BdD3GovahiCarTypeGet)));
            var parser = new Parser<BdD3GovahiCarTypeViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetBdD3GovahiCarType());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.BnSodurDate, item.GovahiTypeName, item.KhodroGoruhName,
                             item.KhodroId, item.KhodroKindCaption, item.SarneshinCount, item.Tonaje, item.PrvId, item.PrvNo,
                             item.PrvDate, item.HadeseDate, item.CustomerName, item.Nationalcode, item.CompanyCode,
                             item.AgentName, item.BnSodurName, item.BranchName, item.BnUserName, item.PrvUserName,
                             item.Status, item.Comment);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }


        #endregion

        #region شاخص شماره چهار خسارت بدنه 
        /// <summary>
        /// شاخص شماره چهار خسارت بدنه: سال ساخت خودرو- سال وقوع حادثه
        /// </summary>
        /// <returns></returns>
        public IActionResult BdD4EstehlakGet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BdD4EstehlakPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<BdD4EstehlakViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetBdD4Estehlak());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult BdD4EstehlakAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordBdD4Estehlak(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("BdD4EstehlakAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult BdD4EstehlakAddcmtPost(BdD4EstehlakViewModel sales)
        {


            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateBdD4Estehlak(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult BdD4EstehlakToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(BdD4EstehlakGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportBdD4EstehlakToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[16] {
                                                    new DataColumn("کد بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه "),
                                                    new DataColumn("کد پرونده"),
                                                    new DataColumn("شماره پرونده"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نام بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("واحد تشکیل پرونده"),
                                                    new DataColumn("تاریخ پرونده"),
                                                    new DataColumn("تاریخ حادثه"),
                                                    new DataColumn("کاربر ثبت بیمه نامه"),
                                                    new DataColumn("وضعیت بررسی پرونده"),
                                                    new DataColumn("نظرات")

                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(BdD4EstehlakGet)));
            var parser = new Parser<BdD4EstehlakViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetBdD4Estehlak());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.PrvId, item.PrvNo, item.BnSodurDate, item.CustomerName,
                            item.Nationalcode, item.AgentName, item.BnSodurName, item.BranchName, item.PrvSodurName,
                            item.PrvDate, item.HadeseDate, item.BnUserName, item.Status, item.Comment);



            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }


        #endregion

        #region شاخص شماره پنج خسارت بدنه 

        /// <summary>
        /// شاخص شماره پنج خسارت بدنه: ارزش خودرو در بیمه نامه - ارزش کارشناسی خودرو در زمان وقوع حادثه 
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public IActionResult BdD5CarAmountGet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BdD5CarAmountPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<BdD5CarAmountViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetBdD5CarAmount());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult BdD5CarAmountAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordBdD5CarAmount(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("BdD5CarAmountAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult BdD5CarAmountAddcmtPost(BdD5CarAmountViewModel sales)
        {


            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateBdD5CarAmount(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult BdD5CarAmountToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(BdD5CarAmountGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportBdD5CarAmountToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[18] {
                                                    new DataColumn("کد بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه "),
                                                    new DataColumn("کد پرونده "),
                                                    new DataColumn("شماره پرونده"),
                                                    new DataColumn("ارزش خودرو"),
                                                    new DataColumn("ارزش روز خودرو"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("تاریخ پرونده"),
                                                    new DataColumn("نام بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("واحد تشکیل پرونده"),
                                                    new DataColumn("کاربر ثبت بیمه نامه"),
                                                    new DataColumn("کاربر ثبت پرونده"),
                                                    new DataColumn("وضعیت بررسی پرونده"),
                                                    new DataColumn("نظرات")

                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(BdD5CarAmountGet)));
            var parser = new Parser<BdD5CarAmountViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetBdD5CarAmount());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.PrvId, item.PrvNo, item.KhodroArzesh, item.KhodroArzeshRouz,
                            item.BnSodurDate, item.PrvDate, item.CustomerName, item.Nationalcode, item.AgentName, item.BnSodurName,
                            item.BranchName, item.PrvSodurName, item.BnUserName, item.PrvUserName, item.Status,
                            item.Comment);



            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }
        #endregion

        #region شاخص شماره شش خسارت بدنه 
        /// <summary>
        /// شاخص شماره شش خسارت بدنه: تاریخ صدور بیمه نامه - تاریخ وقوع حادثه
        /// </summary>
        /// <returns></returns>
        public IActionResult BdD6DayDamageGet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BdD6DayDamagePost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<BdD6DayDamageViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetBdD6DayDamage());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult BdD6DayDamageAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordBdD6DayDamage(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("BdD6DayDamageAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult BdD6DayDamageAddcmtPost(BdD6DayDamageViewModel sales)
        {


            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateBdD6DayDamage(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult BdD6DayDamageToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(BdD6DayDamageGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportBdD6DayDamageToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[19] {
                                                    new DataColumn("کد بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه "),
                                                    new DataColumn("کد پرونده "),
                                                    new DataColumn("شماره پرونده"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("تاریخ حادثه"),
                                                    new DataColumn("تفاوت تاریخی"),
                                                    new DataColumn("تاریخ پرونده"),
                                                    new DataColumn("نام بیمه گذار"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("علت حادثه"),
                                                    new DataColumn("واحد تشکیل پرونده"),
                                                    new DataColumn("کاربر ثبت بیمه نامه"),
                                                    new DataColumn("کاربر ثبت پرونده"),
                                                    new DataColumn("تاریخ بیمه نامه قبلی"),
                                                    new DataColumn("وضعیت پرونده"),
                                                    new DataColumn("نظرات"),
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(BdD6DayDamageGet)));
            var parser = new Parser<BdD6DayDamageViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetBdD6DayDamage());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.Bno, item.PrvId, item.PrvNo, item.BnsodurDate, item.HadeseDate,
                             item.DateDifference, item.PrvDate, item.CustomerName, item.AgentName, item.SodurName, item.BranchName,
                             item.ElatHadeseName, item.PrvSodurName, item.BnUserName, item.PrvUserName, item.LastBnEndDate,
                             item.Status, item.Comment);



            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }


        #endregion

        #region شاخص شماره هفت خسارت بدنه 

        /// <summary>
        /// شاخص شماره هفت خسارت بدنه:تاریخ اقساط تاریخ واریزها - تاریخ وقوع حادثه
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public IActionResult BdD7InstallmentWithHvGet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BdD7InstallmentWithHvPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<BdD7InstallmentWithHvViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetBdD7InstallmentWithHv());
                var data = parser.Parse();
                var ss = Json(data);
                return Json(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult BdD7InstallmentWithHvAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordBdD7InstallmentWithHv(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("BdD7InstallmentWithHvAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult BdD7InstallmentWithHvAddcmtPost(BdD7InstallmentWithHvViewModel sales)
        {


            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateBdD7InstallmentWithHv(sales.Comment, sales.Id, sales.Status);
                if (res == null)
                {
                    result = new { message = "پیدا نشد", success = false };
                }
                else
                {
                    result = new { message = "عملیات با موفقیت انجام شد", success = true };
                }
                //return RedirectToAction("AddcommentToRecord1");
            }
            else
            {
                result = new { message = "معتبر نیست", success = false };

            }
            return Json(result);
        }

        [HttpPost]
        public IActionResult BdD7InstallmentWithHvToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(BdD7InstallmentWithHvGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportBdD7InstallmentWithHvToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[30] {new DataColumn("کد قلم دریافتی"),
                                                    new DataColumn("کد بیمه نامه"),
                                                    new DataColumn("شماره بیمه نامه "),
                                                    new DataColumn("شماره الحاقیه "),
                                                    new DataColumn("نام واحد معرف"),
                                                    new DataColumn("نام واحد صدور"),
                                                    new DataColumn("نام بیمه گذار"),
                                                    new DataColumn("شماره پرونده"),
                                                    new DataColumn("تاریخ پرونده"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("تاریخ شروع بیمه نامه"),
                                                    new DataColumn("تاریخ پایان بیمه نامه"),
                                                    new DataColumn("تاریخ سررسید"),
                                                    new DataColumn("تاریخ عملیات"),
                                                    new DataColumn("نوع تسویه"),
                                                    new DataColumn("مبلغ قسط"),
                                                    new DataColumn("مبلغ تسویه"),
                                                    new DataColumn("مبلغ تسویه نشده"),
                                                    new DataColumn("مبلغ وصول شده"),
                                                    new DataColumn("نوع عملیات تسویه"),
                                                    new DataColumn("نوع بستانکاری"),
                                                    new DataColumn("تاریخ وصول"),
                                                    new DataColumn("تاریخ تحویل"),
                                                    new DataColumn("وضعیت وصول"),
                                                    new DataColumn("نوع رسید"),
                                                    new DataColumn("تاریخ اعلام"),
                                                    new DataColumn("تاریخ حادثه"),
                                                    new DataColumn("مبلغ حواله"),
                                                    new DataColumn("وضعیت بررسی پرونده") ,
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(BdD7InstallmentWithHvGet)));
            var parser = new Parser<BdD7InstallmentWithHvViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetBdD7InstallmentWithHv());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PrmSrdId, item.PolicyId, item.Bno, item.ElhNo, item.AgentName, item.SodurName, item.CustomerName,
                            item.PrvNo, item.PrvDate, item.BnSodurDate, item.BeginDate, item.EndDate, item.SrdDate, item.OpDate,
                            item.TasvieType, item.SrdAmountAsRial, item.TasvieAmount, item.TasvieNashode, item.VosulShode,
                            item.AmaliatTasvieType, item.CreditType, item.VslStateDate, item.DeliverDate, item.VslStateName,
                            item.RcvdKindName, item.ElamDate, item.HadeseDate, item.HvAmount,
                            item.Status, item.Comment);

            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream st = new MemoryStream())
                {
                    wb.SaveAs(st);
                    return File(st.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheatml.sheet", "Grid.xlsx");
                }
            }
        }

        #endregion
        #endregion

        #endregion



        #region Common

        [HttpPost]
        public JsonResult IndexAjax(string name)
        {
            List<SalesD6DayDamageViewModel> Ply = _sv.GetSalesD6DayDamage().ToList();
            return Json(Ply);
        }
        //public IEnumerable<SP_PolicyPaginationResult> GetPolicyList(int? pageNumber = 0)
        //{
        //    FruddataContext context = new FruddataContext();
        //    FruddataContextProcedures prs = new FruddataContextProcedures(context);
        //    if (pageNumber < 0)
        //    {
        //        pageNumber = 1;
        //    }
        //    decimal pageSize = 10;
        //    var temp = prs.SP_PolicyPaginationAsync(Convert.ToInt32(Math.Abs((Convert.ToDecimal(pageNumber) - 1)) * pageSize), Convert.ToInt32(pageSize)).Result;

        //    return temp;
        //}
        NameValueCollection ToNameValueCollection<TKey, TValue>(IDictionary<TKey, TValue> dict)
        {
            var nameValueCollection = new NameValueCollection();
            foreach (var kvp in dict)
            {
                string value = null;
                if (kvp.Value != null)
                    value = kvp.Value.ToString();
                nameValueCollection.Add(kvp.Key.ToString(), value);
            }
            return nameValueCollection;
        }




        #endregion





        //[HttpGet, Route("/Report/GetResultTestData/{id}")]
        //public IActionResult GetResultTestData(int id )
        //{
        //    var data = _sv.GetResultTestData(id);

        //    return new JsonResult(data);
        //}
    }
}
