using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleSession.Models;
using System.Diagnostics;
using myUtility.Extensions;
using myServices.Interfaces;

namespace SampleSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestService _testService;

        public HomeController(ILogger<HomeController> logger, ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        public IActionResult Index()
        {
            //(1)Session標準作法
            HttpContext.Session.SetString("code", "1234");
            var data1 = HttpContext.Session.GetString("code");

            //(2)Session擴充方法使用myUtility.Extensions
            var currentTime = DateTime.Now;
            HttpContext.Session.Set<DateTime>("code1", currentTime);
            var data2 = HttpContext.Session.Get<DateTime>("code1");

            //(3)使用注入Service方式在Service中使用Session
            var data3 = _testService.GetTest1();

            return View();
        }

        public IActionResult Privacy()
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