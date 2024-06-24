using Microsoft.AspNetCore.Mvc;
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
            
            return View();
        }

        [HttpPost]
        public IActionResult Index(string txtSearch)
        {
            List<BranchViewModel> lst = new List<BranchViewModel>();
            try
            {
                lst = _service.searchBranch(txtSearch);
                
            }
            catch (Exception ex)
            {

            }
            return View(lst);
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult SearchBranch01()
        {
            List<BranchViewModel> lst = _service.getAllBranch();

            return View(lst);
        }
        public IActionResult SearchBranch02()
        {
            List<BranchViewModel> lst = _service.getAllReserve();
 


            return View(lst);

        }
        public IActionResult SearchBranch03()
        {
            List<BranchViewModel> lst = _service.getAllSurvey();



            return View(lst);
        }
        public IActionResult SearchBranch04()
        {
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
