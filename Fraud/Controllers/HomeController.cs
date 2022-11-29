using Fraud.Models;
using Fraud.Models.Common;
using Fraud.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace Fraud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServices _sv;

        public HomeController(IServices sv, ILogger<HomeController> logger)
        {
            _logger = logger;
            _sv = sv;
        }
        [Authorize]
        public IActionResult Index()
        {
            //var statusType0 = _sv.GetResultTestData(0);
            //ViewBag.FraudData0 = statusType0[0];
            return View();
        }

        [HttpGet]
        public IActionResult GetResultTestData(int id)
        {
            var data = _sv.GetResultTestData(id);
            return new JsonResult(data[0].StatusCnt);
        }


        [HttpGet]
        public List<MiniRepoByBranchViewModel> GetResultRepoByBranch()
        {
            var data = _sv.GetBnFileByBranch();
            return data;
        }


        [HttpGet]
        public IEnumerable<object> GetRevenueChartByBranch()
        {
            var data = _sv.GetChartInfo();
        //var data1 = new object[]{
        //                                      new { y= "semnan Q1", item1= 2666, item2= 2666 },
        //                                      new { y= "kish Q2", item1= 2778, item2= 2294 },
        //                                      new { y= "ahvaz Q3", item1= 4912, item2= 1969 },
        //                                      new { y= "asdf Q4", item1= 3767, item2= 3597 },
        //                                      new { y= "uuu Q1", item1= 6810, item2= 1914 },
        //                                      new { y= "rrr Q2", item1= 5670, item2= 4293 },
        //                                      new { y= "2012 Q3", item1= 4820, item2= 3795 },
        //                                      new { y= "2012 Q4", item1= 15073, item2= 5967 },
        //                                      new { y= "2013 Q1", item1= 10687, item2= 4460 },
        //                                      new { y= "2013 Q2", item1= 8432, item2= 5713 }

        //};
            //return data1;
            return data.Select(x => new { y = x.BranchName, item1 = x.BnCnt, item2 = x.DmgCnt });
        }






        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Report()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
