using Microsoft.AspNetCore.Mvc;
using WNPP_WEB.Models;
using WNPP_WEB.Models.ViewModels;
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
            _service = new MonkServices();
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
        public IActionResult BuddhistLent()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง",
                MenuListM = "show",
                MenuM1 = "active",
            };
            List<PhanSaViewModel> datas = new List<PhanSaViewModel>();

            return View(datas);
        }
        [HttpPost]
        public IActionResult BuddhistLent(PhanSaViewModel data)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง",
                MenuListM = "show",
                MenuM1 = "active",
            };
            List<PhanSaViewModel> datas = new List<PhanSaViewModel>();

            return View(datas);
        }
        public IActionResult Add2BuddhistLent()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง",
                MenuListM = "show",
                MenuM1 = "active",
            };
            PhanSaViewModel data = new PhanSaViewModel();

            return View(data);
        }
        [HttpPost]
        public IActionResult Add2BuddhistLent(PhanSaViewModel data)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง",
                MenuListM = "show",
                MenuM1 = "active",
            };


            return View("BuddhistLent");
        }
        public IActionResult TimeLine()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง",
                MenuListM = "show",
                MenuM1 = "active",
            };
            return View();
        }
    }
}
