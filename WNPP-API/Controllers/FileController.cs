﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> PostSingleFile([FromForm] FileUploadModel file)
        {
            int result = 0;
            if (file == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _service.PostFileAsync(file.FileDetails, file.FileType);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                await _service.DownloadFileById(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("LoadImage")]
        public IActionResult LoadImage(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                return File( _service.getImage(id), "image/jpeg");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("LoadPDF")]
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
    }
}
