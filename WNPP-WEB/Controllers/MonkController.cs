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
        public IActionResult Add2Monk(int id)
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


            return View(_service.getAllBuddhistLent());
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
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง / เพิ่มข้อมูล เข้า พรรษา",
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
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง / เพิ่มข้อมูล เข้า พรรษา",
                MenuListM = "show",
                MenuM1 = "active",
            };

            _service.add2BuddhistLent(data);

            return View("BuddhistLent", _service.getAllBuddhistLent());
        }
        public IActionResult Add2BuddhistLentDetail(int year)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง / แก้ไขข้อมูลรายปี",
                MenuListM = "show",
                MenuM1 = "active",
            };

            return View(_service.getPhanSaViewModel(year));
        }
        [HttpPost]
        public IActionResult Add2BuddhistLentDetail(PhanSaViewModel data)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง / แก้ไขข้อมูลรายปี",
                MenuListM = "show",
                MenuM1 = "active",
            };
            _service.addMonkBuddhistLentDetail(data);

            return View(_service.getPhanSaViewModel(data.BuddhistLentYear));
        }
        public IActionResult EditBL2Monk(int id)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง / แก้ไขข้อมูลรายปี / แก้ไขข้อมูลพระ",
                MenuListM = "show",
                MenuM1 = "active",
            };
            //_service.addMonkBuddhistLentDetail(data);

            return View(new TMonk());
        }
        [HttpPost]
        public IActionResult EditBL2Monk(TMonk data)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง / แก้ไขข้อมูลรายปี / แก้ไขข้อมูลพระ",
                MenuListM = "show",
                MenuM1 = "active",
            };
            //_service.addMonkBuddhistLentDetail(data);

            return View(new TMonk());
        }
        public IActionResult TimeLine()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "จำพรรษาวัดหนองป่าพง",
                MenuListM = "show",
                MenuM1 = "active",
            };
            return View();
        }
    }
}
