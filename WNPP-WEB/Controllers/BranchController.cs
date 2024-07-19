using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using WNPP_WEB.Models;
using WNPP_WEB.Models.ViewModels;
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
                MenuName = "B0 คัดค้นทะเบียนสาขา",
                MenuListB = "show",
                MenuB0 = "active",
            };

            if (string.IsNullOrEmpty(txtSearch))
            {
                return View();
            }
            else
            {
                return View(_service.searchBranch(txtSearch));
            }
            
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
            TBranch? branch;
            try
            {
                branch = _service.findByID(Id);

            }
            catch (Exception)
            {
                throw;
            }

            return View(branch);
        }
        [HttpPost]
        public IActionResult Edit2Branch(TBranch data)
        {
            ViewBag.MenuViewModel = new MenuViewModel()
            {
                MenuName = "ทะเบียนสาขานานาชาติ",
                MenuListB = "show",
                MenuB5 = "active",
            };
            TBranch branch = new TBranch();
            try
            {
                _service.edit2Branch(data);
                if (data.BranchType == 1)
                    return View("SearchBranch01", _service.getAllBranch());
                else if (data.BranchType == 2)
                    return View("SearchBranch02", _service.getAllReserve());
                else if (data.BranchType == 3)
                    return View("SearchBranch03", _service.getAllSurvey());
                else if (data.BranchType == 4)
                    return View("SearchBranch04", _service.getAllSurvey());
                else
                    return View("SearchBranch00");

            }
            catch (Exception)
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
