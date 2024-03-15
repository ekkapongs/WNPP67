using Microsoft.AspNetCore.Mvc;
using WNPP_API.Models;
using WNPP_API.Services;

namespace WNPP_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;
        private readonly IFileService _service;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
            _service = new FileService();
        }
        [HttpPost]
        [ActionName("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile([FromForm] IFormFile fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                await _service.PostFileAsync(fileDetails);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
