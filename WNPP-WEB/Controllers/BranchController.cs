using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using WNPP_WEB.Models;
using WNPP_WEB.Services;

namespace WNPP_WEB.Controllers
{
    public class BranchController : Controller
    {
        private readonly ILogger<BranchController> _logger;
        private readonly IBranchServices _service;

        public BranchController(ILogger<BranchController> logger)
        {
            _logger = logger;
            _service = new BranchServices();
        }
        public IActionResult Index()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "งานทะเบียนสาขา",
                MenuListB = "show"
            };

            return View();
        }
        [HttpPost]
        public IActionResult Index(string txtSearch)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "งานทะเบียนสาขา",
                MenuListB = "show"
            };

            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult AddBranch()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "งานทะเบียนสาขา",
                MenuListB = "show",
                MenuB5 = "active",
            };
            return View();
        }
        public IActionResult SearchBranch00()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "B0 คัดค้นทะเบียนสาขา",
                MenuListB = "show",
                MenuB0 = "active",
            };
            return View();
        }
        [HttpPost]
        public IActionResult SearchBranch00(string txtSearch)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "คัดค้นข้อมูล สาขา สำรอง สำรวจ",
                MenuListB = "show",
                MenuB0 = "active",
            };
            List<BranchViewModel> lst = new List<BranchViewModel>();
            try
            {
                lst = _service.searchBranch(txtSearch);

            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(lst);
        }
        public IActionResult SearchBranch01()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ทะเบียนสาขา",
                MenuListB = "show",
                MenuB1 = "active",
            };
            List<BranchViewModel> lst = _service.getAllBranch();

            return View(lst);
        }
        public IActionResult SearchBranch02()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ทะเบียนสาขาสำรอง",
                MenuListB = "show",
                MenuB2 = "active",
            };
            List<BranchViewModel> lst = _service.getAllReserve();



            return View(lst);

        }
        public IActionResult SearchBranch03()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ทะเบียนสาขาสำรวจ",
                MenuListB = "show",
                MenuB3 = "active",
            };
            List<BranchViewModel> lst = _service.getAllSurvey();



            return View(lst);
        }
        public IActionResult SearchBranch04()
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ทะเบียนสาขานานาชาติ",
                MenuListB = "show",
                MenuB4 = "active",
            };
            List<BranchViewModel> lst = _service.getAllSurvey();



            return View(lst);
        }
        public IActionResult Edit2Branch(int Id)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "แก้ไขข้อมูลทะเบียนสาขา",
                MenuListB = "show",
                MenuB5 = "active",
            };
            TBranch branch;
            try
            {


                branch = _service.findByID(Id);

            }
            catch (Exception ex)
            {
                branch = new TBranch();
            }

            return View(branch);
        }
        public IActionResult EditBranch(int Id)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ทะเบียนสาขานานาชาติ",
                MenuListB = "show",
                MenuB4 = "active",
            };
            TBranch branch = new TBranch();
            try
            {


                branch = _service.findByID(Id);

            }
            catch (Exception ex)
            {
                return View("Error");
            }

            return View(branch);
        }
        [HttpPost]
        public IActionResult EditBranch(TBranch data)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ทะเบียนสาขานานาชาติ",
                MenuListB = "show",
                MenuB4 = "active",
            };
            TBranch branch = new TBranch();
            try
            {
                _service.editBranch(data);
                return View("SearchBranch00");
            }
            catch (Exception ex)
            {
                return View("Error");
            }


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
