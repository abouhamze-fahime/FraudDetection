using Fraud.Convertor;
using Fraud.Infrastructure.Cache;
using Fraud.Models;
using Fraud.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Fraud.Models.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace Fraud.Controllers
{
    [Route("/[controller]/[action]")]
    //[ApiController]
    //[Authorize]

    public class FireController : Controller
    {

        private readonly IFireServices _sv;
        readonly ICacheProvider _cache;
        private readonly ILogger<AccountController> _logger;
        public FireController(IFireServices sv, ICacheProvider cache , ILogger<AccountController> logger)
        {
            _cache = cache;
            _sv = sv;
            _logger = logger;
        }


        public IActionResult Index()
        {
            _logger.LogWarning("open Fire Indecator 1");
            return View();
        }

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



        [HttpGet]
        public IActionResult FireP01TroubledCodePostiGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP01TroubledCodePostiPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP01TroubledCodePostiViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP01TroubledCodePosti());
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
        public IActionResult FireP01TroubledCodePostiAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP01TroubledCodePosti(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP01TroubledCodePostiAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP01TroubledCodePostiAddcmtPost([FromBody] FireP01TroubledCodePostiViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP01TroubledCodePosti(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP01TroubledCodePostiToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP01TroubledCodePostiGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP01TroubledCodePostiToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[12] {
                                                    new DataColumn("کد رایانه نامه "),
                                                    new DataColumn("شماره الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("کد پستی"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP01TroubledCodePostiGet)));
            var parser = new Parser<FireP01TroubledCodePostiViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP01TroubledCodePosti());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.AgentName,
                             item.SodurName, item.BranchName, item.CustomerName, item.UserName, item.PostalCode,
                             item.StatusName, item.Comment
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


        ////
        ///

        [HttpGet]
        public IActionResult FireP03BnNoLastPolicyIdGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP03BnNoLastPolicyIdPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP03BnNoLastPolicyIdViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP03BnNoLastPolicyId());
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
        public IActionResult FireP03BnNoLastPolicyIdAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP03BnNoLastPolicyId(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP03BnNoLastPolicyIdAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP03BnNoLastPolicyIdAddcmtPost([FromBody] FireP03BnNoLastPolicyIdViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP03BnNoLastPolicyId(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP03BnNoLastPolicyIdToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP03BnNoLastPolicyIdGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP03BnNoLastPolicyIdToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[11] {
                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("شماره الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP03BnNoLastPolicyIdGet)));
            var parser = new Parser<FireP03BnNoLastPolicyIdViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP03BnNoLastPolicyId());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.AgentName,
                             item.SodurName, item.BranchName, item.CustomerName, item.UserName, item.StatusName, item.Comment
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


        ////
        ///

        [HttpGet]
        public IActionResult FireP04TafkikListGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP04TafkikListPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP04TafkikListViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP04TafkikList());
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
        public IActionResult FireP04TafkikListAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP04TafkikList(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP04TafkikListAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP04TafkikListAddcmtPost([FromBody] FireP04TafkikListViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP04TafkikList(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP04TafkikListToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP04TafkikListGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP04TafkikListToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[16] {
                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("شماره الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("خطر اضافی"),
                                                    new DataColumn("مورد بیمه"),
                                                    new DataColumn("شرح مورد بیمه"),
                                                    new DataColumn("سرمایه"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP04TafkikListGet)));
            var parser = new Parser<FireP04TafkikListViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP04TafkikList());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.AgentName,
                             item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode, item.UserName,
                             item.KhatarEzafiName, item.MoreBimeName, item.MoreBimeSharh, item.Sarmaye,
                             item.StatusName, item.Comment
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

        ////
        ///

        [HttpGet]
        public IActionResult FireP06AfzayeshSarmayeGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP06AfzayeshSarmayePost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP06AfzayeshSarmayeViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP06AfzayeshSarmaye());
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
        public IActionResult FireP06AfzayeshSarmayeAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP06AfzayeshSarmaye(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP06AfzayeshSarmayeAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP06AfzayeshSarmayeAddcmtPost([FromBody] FireP06AfzayeshSarmayeViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP06AfzayeshSarmaye(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP06AfzayeshSarmayeToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP06AfzayeshSarmayeGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP06AfzayeshSarmayeToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[15] {
                                                    new DataColumn("کد رایانه نسخه بیمه نامه "),
                                                    new DataColumn("کد رایانه نامه "),
                                                    new DataColumn("شماره الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("تغییر نرخ"),
                                                    new DataColumn("سرمایه"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP06AfzayeshSarmayeGet)));
            var parser = new Parser<FireP06AfzayeshSarmayeViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP06AfzayeshSarmaye());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyVerId, item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.AgentName,
                             item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode, item.UserName,
                             item.DiffRate, item.Sarmaye, item.StatusName, item.Comment
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

        ////
        ///

        [HttpGet]
        public IActionResult FireP07AnbarBazdidGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP07AnbarBazdidPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP07AnbarBazdidViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP07AnbarBazdid());
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
        public IActionResult FireP07AnbarBazdidAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP07AnbarBazdid(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP07AnbarBazdidAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP07AnbarBazdidAddcmtPost([FromBody] FireP07AnbarBazdidViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP07AnbarBazdid(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP07AnbarBazdidToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP07AnbarBazdidGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP07AnbarBazdidToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[12] {
                                                    new DataColumn("کد بیمه نامه "),
                                                    new DataColumn("کد الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP07AnbarBazdidGet)));
            var parser = new Parser<FireP07AnbarBazdidViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP07AnbarBazdid());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.AgentName,
                             item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode, item.UserName,
                             item.StatusName, item.Comment
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

        ////
        ///

        [HttpGet]
        public IActionResult FireP08AsaBazdidGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP08AsaBazdidPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP08AsaBazdidViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP08AsaBazdid());
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
        public IActionResult FireP08AsaBazdidAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP08AsaBazdid(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP08AsaBazdidAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP08AsaBazdidAddcmtPost([FromBody]  FireP08AsaBazdidViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP08AsaBazdid(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP08AsaBazdidToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP08AsaBazdidGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP08AsaBazdidToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[13] {
                                                    
                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("کد الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ بازدید"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP08AsaBazdidGet)));
            var parser = new Parser<FireP08AsaBazdidViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP08AsaBazdid());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add( item.PolicyId, item.ElhNo, item.Bno, item.BazdidDate, item.BnSodurDate, item.AgentName,
                             item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode, item.UserName,
                             item.StatusName, item.Comment
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



        [HttpGet]
        public IActionResult FireP09MaskanBazdidGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP09MaskanBazdidPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP09MaskanBazdidViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP09MaskanBazdid());
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
        public IActionResult FireP09MaskanBazdidAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP09MaskanBazdid(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP09MaskanBazdidAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP09MaskanBazdidAddcmtPost([FromBody] FireP09MaskanBazdidViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP09MaskanBazdid(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP09MaskanBazdidToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP09MaskanBazdidGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP09MaskanBazdidToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[13] {

                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("کد الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("سرمایه"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP09MaskanBazdidGet)));
            var parser = new Parser<FireP09MaskanBazdidViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP09MaskanBazdid());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno,  item.BnSodurDate, item.AgentName,
                             item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode,
                             item.Sarmaye,item.UserName,item.StatusName, item.Comment
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




        [HttpGet]
        public IActionResult FireP10GheirSanatiBazdidOver10Get()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP10GheirSanatiBazdidOver10Post()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP10GheirSanatiBazdidOver10ViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP10GheirSanatiBazdidOver10());
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
        public IActionResult FireP10GheirSanatiBazdidOver10AddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP10GheirSanatiBazdidOver10(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP10GheirSanatiBazdidOver10AddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP10GheirSanatiBazdidOver10AddcmtPost([FromBody]  FireP10GheirSanatiBazdidOver10ViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP10GheirSanatiBazdidOver10(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP10GheirSanatiBazdidOver10ToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP10GheirSanatiBazdidOver10Get)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP10GheirSanatiBazdidOver10ToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[15] {

                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("کد الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نام رشته"),
                                                    new DataColumn("طبقه خطر"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("سرمایه"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP10GheirSanatiBazdidOver10Get)));
            var parser = new Parser<FireP10GheirSanatiBazdidOver10ViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP10GheirSanatiBazdidOver10());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate ,item.ReshteName , item.RiskTabagh, item.AgentName,
                             item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode,
                             item.Sarmaye, item.UserName, item.StatusName, item.Comment
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




        [HttpGet]
        public IActionResult FireP11GheirSanatiBazdidOver80Get()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP11GheirSanatiBazdidOver80Post()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP11GheirSanatiBazdidOver80ViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP11GheirSanatiBazdidOver80());
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
        public IActionResult FireP11GheirSanatiBazdidOver80AddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP11GheirSanatiBazdidOver80(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP11GheirSanatiBazdidOver80AddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP11GheirSanatiBazdidOver80AddcmtPost([FromBody] FireP11GheirSanatiBazdidOver80ViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP11GheirSanatiBazdidOver80(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP11GheirSanatiBazdidOver80ToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP11GheirSanatiBazdidOver80Get)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP11GheirSanatiBazdidOver80ToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[14] {

                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("کد الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نام رشته"),
                                                    new DataColumn("سرمایه"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP10GheirSanatiBazdidOver10Get)));
            var parser = new Parser<FireP11GheirSanatiBazdidOver80ViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP11GheirSanatiBazdidOver80());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.ReshteName, item.Sarmaye, item.AgentName,
                             item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode,
                             item.UserName, item.StatusName, item.Comment
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


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public IActionResult FireP12AnbarBazdidOver10Get()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP12AnbarBazdidOver10Post()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP12AnbarBazdidOver10ViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP12AnbarBazdidOver10());
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
        public IActionResult FireP12AnbarBazdidOver10AddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP12AnbarBazdidOver10(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP12AnbarBazdidOver10AddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP12AnbarBazdidOver10AddcmtPost([FromBody]  FireP12AnbarBazdidOver10ViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP12AnbarBazdidOver10(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP12AnbarBazdidOver10ToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP12AnbarBazdidOver10Get)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP12AnbarBazdidOver10ToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[15] {

                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("کد الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نام رشته"),
                                                    new DataColumn("سرمایه"),
                                                    new DataColumn("طبقه خطر"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP12AnbarBazdidOver10Get)));
            var parser = new Parser<FireP12AnbarBazdidOver10ViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP12AnbarBazdidOver10());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.ReshteName, item.Sarmaye ,item.RiskTabagh , 
                            item.AgentName, item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode,
                            item.UserName, item.StatusName, item.Comment
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FireP13SanatiBazdidOver20Get()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP13SanatiBazdidOver20Post()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP13SanatiBazdidOver20ViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP13SanatiBazdidOver20());
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
        public IActionResult FireP13SanatiBazdidOver20AddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP13SanatiBazdidOver20(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP13SanatiBazdidOver20AddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP13SanatiBazdidOver20AddcmtPost([FromBody]  FireP13SanatiBazdidOver20ViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP13SanatiBazdidOver20(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP13SanatiBazdidOver20ToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP13SanatiBazdidOver20Get)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP13SanatiBazdidOver20ToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[15] {

                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("کد الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نام رشته"),
                                                    new DataColumn("سرمایه"),
                                                    new DataColumn("طبقه خطر"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP13SanatiBazdidOver20Get)));
            var parser = new Parser<FireP13SanatiBazdidOver20ViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP13SanatiBazdidOver20());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.ReshteName, item.Sarmaye, item.RiskTabagh,
                            item.AgentName, item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode,
                            item.UserName, item.StatusName, item.Comment
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


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FireP14SanatiAnbarBazdidSpecialGroupGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP14SanatiAnbarBazdidSpecialGroupPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP14SanatiAnbarBazdidSpecialGroupViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP14SanatiAnbarBazdidSpecialGroup());
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
        public IActionResult FireP14SanatiAnbarBazdidSpecialGroupAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP14SanatiAnbarBazdidSpecialGroup(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP14SanatiAnbarBazdidSpecialGroupAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP14SanatiAnbarBazdidSpecialGroupAddcmtPost([FromBody]  FireP14SanatiAnbarBazdidSpecialGroupViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP14SanatiAnbarBazdidSpecialGroup(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP14SanatiAnbarBazdidSpecialGroupToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP14SanatiAnbarBazdidSpecialGroupGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP14SanatiAnbarBazdidSpecialGroupToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[15] {

                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("کد الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نام رشته"),
                                                    new DataColumn("سرمایه"),
                                                    new DataColumn("طبقه خطر"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP14SanatiAnbarBazdidSpecialGroupGet)));
            var parser = new Parser<FireP14SanatiAnbarBazdidSpecialGroupViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP14SanatiAnbarBazdidSpecialGroup());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.ReshteName, item.Sarmaye, item.RiskTabagh,
                            item.AgentName, item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode,
                            item.UserName, item.StatusName, item.Comment
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FireP15BazdidSpecialGroupOver30Get()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP15BazdidSpecialGroupOver30Post()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP15BazdidSpecialGroupOver30ViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP15BazdidSpecialGroupOver30());
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
        public IActionResult FireP15BazdidSpecialGroupOver30AddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP15BazdidSpecialGroupOver30(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP15BazdidSpecialGroupOver30AddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP15BazdidSpecialGroupOver30AddcmtPost([FromBody] FireP15BazdidSpecialGroupOver30ViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP15BazdidSpecialGroupOver30(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP15BazdidSpecialGroupOver30ToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP15BazdidSpecialGroupOver30Get)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP15BazdidSpecialGroupOver30ToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[15] {

                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("کد الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نام رشته"),
                                                    new DataColumn("سرمایه"),
                                                    new DataColumn("طبقه خطر"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP15BazdidSpecialGroupOver30Get)));
            var parser = new Parser<FireP15BazdidSpecialGroupOver30ViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP15BazdidSpecialGroupOver30());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.ReshteName, item.Sarmaye, item.RiskTabagh,
                            item.AgentName, item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode,
                            item.UserName, item.StatusName, item.Comment
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FireP16SerghatBazdidOver700Get()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP16SerghatBazdidOver700Post()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP16SerghatBazdidOver700ViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP16SerghatBazdidOver700());
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
        public IActionResult FireP16SerghatBazdidOver700AddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP16SerghatBazdidOver700(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP16SerghatBazdidOver700AddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP16SerghatBazdidOver700AddcmtPost([FromBody] FireP16SerghatBazdidOver700ViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP16SerghatBazdidOver700(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP16SerghatBazdidOver700ToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP16SerghatBazdidOver700Get)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP16SerghatBazdidOver700ToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[15] {

                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("کد الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نام رشته"),
                                                    new DataColumn("سرمایه"),
                                                    new DataColumn("طبقه خطر"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP16SerghatBazdidOver700Get)));
            var parser = new Parser<FireP16SerghatBazdidOver700ViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP16SerghatBazdidOver700());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.ReshteName, item.Sarmaye, item.RiskTabagh,
                            item.AgentName, item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode,
                            item.UserName, item.StatusName, item.Comment
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



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FireP17SpecialGroupBazdidGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP17SpecialGroupBazdidPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP17SpecialGroupBazdidViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP17SpecialGroupBazdid());
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
        public IActionResult FireP17SpecialGroupBazdidAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP17SpecialGroupBazdid(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP17SpecialGroupBazdidAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP17SpecialGroupBazdidAddcmtPost([FromBody] FireP17SpecialGroupBazdidViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP17SpecialGroupBazdid(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP17SpecialGroupBazdidToExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP17SpecialGroupBazdidGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP17SpecialGroupBazdidToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[15] {

                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("کد الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نام رشته"),
                                                    new DataColumn("سرمایه"),
                                                    new DataColumn("طبقه خطر"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP17SpecialGroupBazdidGet)));
            var parser = new Parser<FireP17SpecialGroupBazdidViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP17SpecialGroupBazdid());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.ReshteName, item.Sarmaye, item.RiskTabagh,
                            item.AgentName, item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode,
                            item.UserName, item.StatusName, item.Comment
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



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FireP18DamagedBazdidGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP18DamagedBazdidPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP18DamagedBazdidViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP18DamagedBazdid());
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
        public IActionResult FireP18DamagedBazdidAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP18DamagedBazdid(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP18DamagedBazdidAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP18DamagedBazdidAddcmtPost([FromBody] FireP18DamagedBazdidViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP17SpecialGroupBazdid(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP18DamagedBazdidExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP18DamagedBazdidGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP18DamagedBazdidToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[15] {

                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("کد الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نام رشته"),
                                                    new DataColumn("سرمایه"),
                                                    new DataColumn("نوع ریسک اضافی"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP18DamagedBazdidGet)));
            var parser = new Parser<FireP18DamagedBazdidViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP18DamagedBazdid());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.ReshteName, item.Sarmaye, item.EzafiRiskKind,
                            item.AgentName, item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode,
                            item.UserName, item.StatusName, item.Comment
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


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FireP19MinPrmGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP19MinPrmPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP19MinPrmViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP19MinPrm());
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
        public IActionResult FireP19MinPrmAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP19MinPrm(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP19MinPrmAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP19MinPrmAddcmtPost([FromBody] FireP19MinPrmViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP17SpecialGroupBazdid(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP19MinPrmExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP19MinPrmGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP19MinPrmToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[14] {

                                                    new DataColumn("کد رایانه بیمه نامه "),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نام رشته"),
                                                    new DataColumn("سرمایه"),
                                                    new DataColumn("مبلغ"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("کد ملی"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP19MinPrmGet)));
            var parser = new Parser<FireP19MinPrmViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP19MinPrm());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PolicyId,  item.Bno, item.BnSodurDate, item.ReshteName, item.Sarmaye, item.Prm,
                            item.AgentName, item.SodurName, item.BranchName, item.CustomerName, item.Nationalcode,
                            item.UserName, item.StatusName, item.Comment
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


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FireP21CashPrmBnGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP21CashPrmBnPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP21CashPrmBnViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP21CashPrmBn());
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
        public IActionResult FireP21CashPrmBnAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP21CashPrmBn(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP21CashPrmBnAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP21CashPrmBnAddcmtPost([FromBody] FireP21CashPrmBnViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP21CashPrmBn(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP21CashPrmBnExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP21CashPrmBnGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP21CashPrmBnToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[18] {
                                                    new DataColumn("کد رایانه پرداخت"),
                                                    new DataColumn("کد رایانه بیمه نامه"),
                                                    new DataColumn("شماره الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نام رشته"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("مبلغ بیمه نامه"),
                                                    new DataColumn("مبلغ وصول شده"),
                                                    new DataColumn("مبلغ مانده"),
                                                    new DataColumn("نوع عملیات"),
                                                    new DataColumn("نوع بستانکاری"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP21CashPrmBnGet)));
            var parser = new Parser<FireP21CashPrmBnViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP21CashPrmBn());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PrmSrdId, item.PolicyId,item.ElhNo, item.Bno, item.BnSodurDate, item.ReshteName,
                            item.AgentName, item.SodurName, item.BranchName, item.CustomerName, item.PrmAsRial,  item.VosulShode, item.Remain,
                            item.OperationType , item.CreditType, item.UserName, item.StatusName, item.Comment
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




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult FireP23CashPrmElhGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FireP23CashPrmElhPost()
        {
            try
            {
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var parser = new Parser<FireP23CashPrmElhViewModel>(ToNameValueCollection<string, string>(dict),
                           _sv.GetFireP23CashPrmElh());
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
        public IActionResult FireP23CashPrmElhAddcmtGet(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _sv.OpenRecordFireP23CashPrmElh(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["Id"] = id;
            return View("FireP23CashPrmElhAddcmtGet", obj);
        }

        [HttpPost]
        public IActionResult FireP23CashPrmElhAddcmtPost([FromBody] FireP23CashPrmElhViewModel fire)
        {
            var result = new { message = "", success = false };
            if (ModelState.IsValid)
            {
                var res = _sv.UpdateFireP23CashPrmElh(fire.Comment, fire.Id, fire.Status);
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
        public IActionResult FireP23CashPrmElhExcel()
        {

            var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
            dict["start"] = "0";
            dict["length"] = int.MaxValue.ToString();
            _cache.Set(string.Join("-", User.Identity.Name, nameof(FireP23CashPrmElhGet)), dict);
            return Ok();
        }
        [HttpPost]
        public IActionResult ExportFireP23CashPrmElhToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[18] {
                                                    new DataColumn("کد رایانه پرداخت"),
                                                    new DataColumn("کد رایانه بیمه نامه"),
                                                    new DataColumn("شماره الحاقیه"),
                                                    new DataColumn("شماره بیمه نامه"),
                                                    new DataColumn("تاریخ صدور بیمه نامه"),
                                                    new DataColumn("نام رشته"),
                                                    new DataColumn("واحد معرف"),
                                                    new DataColumn("واحد صدور"),
                                                    new DataColumn("شعبه واحد صدور"),
                                                    new DataColumn("بیمه گذار"),
                                                    new DataColumn("مبلغ بیمه نامه"),
                                                    new DataColumn("مبلغ وصول شده"),
                                                    new DataColumn("مبلغ مانده"),
                                                    new DataColumn("نوع عملیات"),
                                                    new DataColumn("نوع بستانکاری"),
                                                    new DataColumn("نام کاربر"),
                                                    new DataColumn("وضعیت بررسی شاخص"),
                                                    new DataColumn("نظرات")
                                                   });
            var dict = (Dictionary<string, string>)_cache.Get(string.Join("-", User.Identity.Name, nameof(FireP23CashPrmElhGet)));
            var parser = new Parser<FireP23CashPrmElhViewModel>(ToNameValueCollection<string, string>(dict),
                         _sv.GetFireP23CashPrmElh());
            var data = parser.Parse();
            var lst = from ply in data.data
                      select ply;
            foreach (var item in lst)
            {
                dt.Rows.Add(item.PrmSrdId, item.PolicyId, item.ElhNo, item.Bno, item.BnSodurDate, item.ReshteName,
                            item.AgentName, item.SodurName, item.BranchName, item.CustomerName, item.PrmAsRial, item.VosulShode, item.Remain,
                            item.OperationType, item.CreditType, item.UserName, item.StatusName, item.Comment
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

    }
}
