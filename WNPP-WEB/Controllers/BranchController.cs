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
        private readonly IFileServices _serviceFiles;
        public BranchController(ILogger<BranchController> logger)
        {
            _logger = logger;
            _service = new BranchServices();
            _serviceFiles = new FileServices();
        }
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Index(string txtSearch)
        {

            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult SearchBranch00()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchBranch00(string txtSearch)
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
        public IActionResult EditBranch(int Id)
        {
            TBranch branch = new TBranch();
            try                       
            {
               

                branch = _service.findByID(Id);

            }
            catch (Exception ex)
            {
                return View("SearchBranch00");
            }

            return View(branch);
        }
        [HttpPost]
        public IActionResult EditBranch(TBranch data)
        {
            TBranch branch = new TBranch();
            try
            {
                _service.editBranch(data);
                return View("SearchBranch00");
            }
            catch (Exception ex)
            {
                return View("SearchBranch00");
            }

            
        }

        [HttpPost]
        [ActionName("PostSingleFile")]
        public async Task<IActionResult> PostSingleFile([FromForm] BranchViewModel view)
        {
            long size = view.FileUploadFormFile.Length;
            await _serviceFiles.PostFileAsync(view.FileUploadFormFile);
            return Ok();
        }

        [HttpGet]
        [ActionName("LoadImage")]
        public IActionResult LoadImage(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                return File(_serviceFiles.getImage(id), "image/jpeg");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [ActionName("LoadPDF")]
        public IActionResult LoadPDF(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                return File(_serviceFiles.getImage(id), "application/pdf");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
