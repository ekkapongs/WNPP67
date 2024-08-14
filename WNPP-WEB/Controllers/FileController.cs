using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WNPP_WEB.Models;
using WNPP_WEB.Models.ViewModels;
using WNPP_WEB.Services;

namespace WNPP_WEB.Controllers
{
    public class FileController : Controller
    {
        private readonly ILogger<FileController> _logger;
        private readonly IFileServices _service;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
            _service = new FileServices();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAbbotImage(int id)
        {
            try
            {
                return File(_service.getAbbotImage(id), "image/jpeg");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("PostAbbotImage")]
        public async Task<IActionResult> PostAbbotImage([FromForm] AbbotImageViewModel view)
        {

            return RedirectToAction("EditBranch", "Branch", new { id = view.DataId });
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
                return File(_service.getImage(id), "image/jpeg");
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
                return File(_service.getImage(id), "application/pdf");
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

