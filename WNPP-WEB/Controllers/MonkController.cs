using Microsoft.AspNetCore.Mvc;
using WNPP_WEB.Models;
using WNPP_WEB.Models.ViewModels;
using WNPP_WEB.Services;
using System.Web;

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
        public IActionResult Index()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "M0 งานทะเบียนภิกษุ ",
                MenuListM = "show",
                MenuM0 = "active",
            };
            return View();
        }
        public IActionResult SearchMonk00(string txtSearch)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "M0 งานทะเบียนภิกษุ / คัดค้นทะเบียนภิกษุ ",
                MenuListM = "show",
                MenuM0 = "active",
            };
            try
            {
                if (string.IsNullOrEmpty(txtSearch))
                {
                    return View();
                }
                else
                {
                    return View(_service.searchMonk(txtSearch));
                }
            }
            catch (Exception ex)
            {
                return View("Error500", ex);
            }
        }
        public IActionResult Add2Monk(int id)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "งาน ทะเบียนภิกษุ",
                MenuListM = "show",
                MenuM0 = "active",
            };
            return View();
        }
        public IActionResult Edit2Monk(int id)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "คัดค้นทะเบียนภิกษุ / แก้ไขข้อมูลพระ",
                MenuListM = "show",
                MenuM0 = "active",
            };
            try
            {
                return View(_service.getMonkView(id));
            }
            catch (Exception ex)
            {
                return View("Error500", ex);
            }
        }
        [HttpPost]
        public IActionResult Edit2Monk(TMonkViewModel data)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "คัดค้นทะเบียนภิกษุ / แก้ไขข้อมูลพระ",
                MenuListM = "show",
                MenuM0 = "active",
            };
            try
            {
                _service.edit2Monk(data);
                return View("SearchMonk00");
            }
            catch (Exception ex)
            {
                return View("Error500", ex);
            }
        }

        public IActionResult BuddhistLent()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง",
                MenuListM = "show",
                MenuM1 = "active",
            };
            try
            {
                return View(_service.getAllBuddhistLent());
            }
            catch (Exception ex)
            {
                return View("Error500", ex);
            }

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
            try
            {
                _service.add2BuddhistLent(data);

                return View("BuddhistLent", _service.getAllBuddhistLent());
            }
            catch (Exception ex)
            {
                return View("Error500", ex);
            }

        }
        public IActionResult Add2BuddhistLentDetail(int year)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง / แก้ไขข้อมูลรายปี",
                MenuListM = "show",
                MenuM1 = "active",
            };
            try
            {
                ViewData["CallBack"] = Request.Path + Request.QueryString;

                return View(_service.getPhanSaViewModel(year));
            }
            catch (Exception ex)
            {
                return View("Error500", ex);
            }

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
            try
            {
                _service.addMonkBuddhistLentDetail(data);

                return View(_service.getPhanSaViewModel(data.BuddhistLentYear));
            }
            catch (Exception ex)
            {
                return View("Error500", ex);
            }

        }

        public IActionResult EditBL2Monk(int id, string callBack, int year)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง / แก้ไขข้อมูลรายปี / แก้ไขข้อมูลพระ",
                MenuListM = "show",
                MenuM1 = "active",
            };
            try
            {
                ViewData["CallBack"] = callBack;
                TMonkViewModel model = _service.getMonkView(id);
                model.BuddhistLentYear = year;
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error500", ex);
            }

        }
        [HttpPost]
        public IActionResult EditBL2Monk(TMonkViewModel data)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ภิกษุจำพรรษาวัดหนองป่าพง / แก้ไขข้อมูลรายปี / แก้ไขข้อมูลพระ",
                MenuListM = "show",
                MenuM1 = "active",
            };
            try
            {
                _service.editBL2Monk(data);

                return Redirect(data.CallBackPage);
            }
            catch (Exception ex)
            {
                return View("Error500", ex);
            }
            
        }
        [HttpPost]
        public JsonResult searchMonkByName(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    return new JsonResult(_service.searchMonkByName(name));
                }
                else
                {
                    return new JsonResult(new List<TMonk>());
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }
        [HttpPost]
        public JsonResult getMonk(string name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    return new JsonResult(_service.getMonkByName(name));
                }
                else
                {
                    return new JsonResult(new TMonk());
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
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
        public IActionResult Tmp()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "M2 คัดค้นทะเบียนภิกษุ ",
                MenuListM = "show",
                MenuM2 = "active",
            };
            try
            {
                IFileServices services = new FileServices();
                return View(services.getAllAbbotImage());
            }
            catch (Exception ex)
            {

                return View("Error500", ex);
            }

        }
    }
}
