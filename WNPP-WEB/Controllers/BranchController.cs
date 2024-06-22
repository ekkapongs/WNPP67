using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WNPP_API.Services;
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
            
            return View();
        }
        public IActionResult Register()
        {
            ViewData["page"] = "Users";
            return View();
        }
        public IActionResult SearchBranch01()
        {
            ViewData["page"] = "Users";
            List<BranchViewModel> lst = _service.getAllBranch();

            return View(lst);
        }
        public IActionResult SearchBranch02()
        {
            ViewData["page"] = "Users";
            List<BranchViewModel> lst = _service.getAllReserve();
 


            return View(lst);

        }
        public IActionResult SearchBranch03()
        {
            ViewData["page"] = "Users";
            List<BranchViewModel> lst = _service.getAllSurvey();



            return View(lst);
        }
        public IActionResult SearchBranch04()
        {
            ViewData["page"] = "Users";
            List<BranchViewModel> lst = _service.getAllSurvey();



            return View(lst);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
