using Microsoft.AspNetCore.Mvc;
using WNPP_WEB.Models;
using WNPP_WEB.Services;

namespace WNPP_WEB.Controllers
{
    public class MonkController : Controller
    {
        private readonly ILogger<MonkController> _logger;
        private readonly IMonkServices _service;
        public MonkController(ILogger<MonkController> logger)
        {
            _logger = logger;
        }
        public IActionResult Tmp()
        {
            IFileServices services = new FileServices();
            return View(services.getAllAbbotImage());
        }
        public IActionResult Add2Monk()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "งาน ทะเบียนภิกษุ",
                MenuListM = "show",
                MenuM0 = "active",
            };
            return View(new TMonk());
        }
    }
}
