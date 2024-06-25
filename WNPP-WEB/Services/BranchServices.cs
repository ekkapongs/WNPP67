
using WNPP_WEB.Models;
using WNPP_WEB.Services.Mappers;

namespace WNPP_WEB.Services
{
    public interface IBranchServices : IWNPPServive
    {
        public void editBranch(TBranch data);

        public List<BranchViewModel> searchBranch(string message);

        public List<BranchViewModel> getAllBranch();
        public List<BranchViewModel> getAllReserve();
        public List<BranchViewModel> getAllSurvey();
    }
    public class BranchServices : WNPPServive, IBranchServices
    {
        private IBranchMapper _mapper;
        private readonly Wnpp67Context ctx = new Wnpp67Context();
        public BranchServices() {
            _mapper = new BranchMapper();
        }
        public void editBranch(TBranch data)
        {
            try
            {
                var row = ctx.TBranches.Where(x =>
                            x.ActiveStatus == true &&
                            x.Id == data.Id).FirstOrDefault();

                if (row != null)
                {
                    row.BranchName = data.BranchName;
                    row.MonasteryName = data.MonasteryName;
                    row.AddressTextMonatery = data.AddressTextMonatery;
                    row.SubDistrictMonatery = data.SubDistrictMonatery;
                    row.DistrictMonatery = data.DistrictMonatery;
                    row.ProvinceMonatery = data.ProvinceMonatery;
                    row.CountryMonatery = data.CountryMonatery;
                    row.PostCodeMonatery = data.PostCodeMonatery;
                    row.MonasteryPhoneNo = data.MonasteryPhoneNo;
                    row.AbbotName = data.AbbotName;

                    row.CertifierName = data.CertifierName;
                    row.CertifierTemple = data.CertifierTemple;

                    row.DateOfBirth = data.DateOfBirth;
                    row.DateOfOrdination = data.DateOfOrdination;
                    
                    ctx.TBranches.Update(row);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
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
