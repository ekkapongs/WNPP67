using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WNPP_WEB.Models.ViewModels;

namespace WNPP_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ศูนย์ข้อมูล สำนักเลขา วัดหนองป่าพง",

            };
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ศูนย์ข้อมูล สำนักเลขา วัดหนองป่าพง",

            };
            ViewData["page"] = "Users";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
