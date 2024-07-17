using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebTestEx.Context;
using WebTestEx.Interface;
using WebTestEx.Models;
using WebTestEx.Models.Data;
using WebTestEx.Service;

namespace WebTestEx.Controllers
{
    /// <summary>
    /// WebTestEx_Self
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbCustomDbSampleContext _db;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, dbCustomDbSampleContext db, IHomeService homeService)
        {
            _db = db;
            _logger = logger;
            _homeService = homeService;
        }
        /// <summary>
        /// index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            int iResult = 4111 + 5111;
            ViewData["msg"] = iResult;
            return View(iResult);
        }

        [HttpGet]
        public async  Task<IActionResult> Student()
        {
            // var result = _db.Menus.ToList();123
            var result = await _homeService.Student();
            return View(result);
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

        public IActionResult Count()
        {
            return View();
        }
    }
}