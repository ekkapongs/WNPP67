
using WNPP_WEB.Models;
using WNPP_WEB.Services.Mappers;

namespace WNPP_WEB.Services
{
    public interface IBranchServices
    {
        public List<BranchViewModel> searchBranch(string message);

        public List<BranchViewModel> getAllBranch();
        public List<BranchViewModel> getAllReserve();
        public List<BranchViewModel> getAllSurvey();
    }
    public class BranchServices : WNPPServive, IBranchServices
    {
        private IBranchMapper _mapper;
        public BranchServices() {
            _mapper = new BranchMapper();
        }
        public List<BranchViewModel> searchBranch(string message)
        {
            List<BranchViewModel> result = new List<BranchViewModel>();
            result = _mapper.ToViews(calPhranSa(searchByName(message)));
            return result;
            
        }

        public List<BranchViewModel> getAllBranch()
        {
            List<BranchViewModel> result = new List<BranchViewModel>();
            result = _mapper.ToViews(calPhranSa(getBranchByTypeID(1)));
            return result;
        }
        public List<BranchViewModel> getAllReserve()
        {
            List<BranchViewModel> result = new List<BranchViewModel>();
            result = _mapper.ToViews(calPhranSa(getBranchByTypeID(2)));
            return result;
        }
        public List<BranchViewModel> getAllSurvey()
        {
            List<BranchViewModel> result = new List<BranchViewModel>();
            result = _mapper.ToViews(calPhranSa(getBranchByTypeID(3)));
            return result;
        }
        
    }
}
