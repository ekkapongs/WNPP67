using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WNPP_WEB.Models;

namespace WNPP_WEB.Controllers
{
    public class BranchController : Controller
    {
        private readonly ILogger<BranchController> _logger;
        public BranchController(ILogger<BranchController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewData["page"] = "Users";
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
            return View();
        }
        public IActionResult SearchBranch02()
        {
            ViewData["page"] = "Users";
            return View();

        }
        public IActionResult SearchBranch03()
        {
            ViewData["page"] = "Users";
            return View();
        }
        public IActionResult SearchBranch04()
        {
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
