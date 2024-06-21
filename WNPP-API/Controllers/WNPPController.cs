using Microsoft.AspNetCore.Mvc;
using WNPP_API.Models;
using WNPP_API.Services;

namespace WNPP_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WNPPController : ControllerBase
    {
        private readonly ILogger<WNPPController> _logger;
        private readonly IWNPPServive _service;

        public WNPPController(ILogger<WNPPController> logger)
        {
            _logger = logger;
            _service = new WNPPServive();
        }
        [HttpPost]
        [ActionName("searchByName2")]
        public List<TBranch> searchByName2(String name)
        {
            _logger.LogTrace("searchByName2 : " + name);
            return _service.searchByName2(name);
        }
        [HttpPost]
        [ActionName("searchByName")]
        public List<TBranch> searchByName(String name)
        {
            _logger.LogTrace("searchByName : " + name);
            return _service.searchByName(name);
        }

        [HttpPost]
        [ActionName("findByMonasteryName")]
        public List<TBranch> findByMonasteryName(String monasteryName)
        {
            _logger.LogTrace("findByMonasteryName : " + monasteryName);
            return _service.findByMonasteryName(monasteryName);
        }

        [HttpPost]
        [ActionName("findByAbbotName")]
        public List<TBranch> findByAbbotName(String abbotName)
        {
            _logger.LogTrace("findByAbbotName : " + abbotName);
            return _service.findByAbbotName(abbotName);
        }

        [HttpGet]
        [ActionName("getAllBranch")]
        public List<TBranch> getAllBranch()
        {
            _logger.LogTrace("getAllBranch : ");
            return _service.getAllBranch();
        }
        [HttpGet]
        [ActionName("getBranchByTypeID")]
        public List<TBranch> getBranchByTypeID(int typeID)
        {
            _logger.LogTrace("getBranchByTypeID : ");
            return _service.getBranchByTypeID(typeID);
        }
    }
}
