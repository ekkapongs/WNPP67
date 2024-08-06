
using WNPP_WEB.Mappers;
using WNPP_WEB.Models;
using WNPP_WEB.Models.ViewModels;

namespace WNPP_WEB.Services
{
    public interface IBranchServices : IWNPPServive
    {
        public void edit2Branch(TBranch data);

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
        public void edit2Branch(TBranch data)
        {
            try
            {
                var row = ctx.TBranches.Where(x =>
                            x.ActiveStatus == true &&
                            x.Id == data.Id).FirstOrDefault();

                if (row != null)
                {
                    row.BranchType = data.BranchType;
                    row.BranchName = data.BranchName;
                    row.MonasteryName = data.MonasteryName;
                    
                    row.AddressTextMonatery = data.AddressTextMonatery;
                    row.HouseNoMonatery = data.HouseNoMonatery;
                    row.MooMonatery = data.MooMonatery;
                    row.VillageMonatery = data.VillageMonatery;
                    row.RoadMonatery = data.RoadMonatery;

                    row.SubDistrictMonatery = data.SubDistrictMonatery;
                    row.DistrictMonatery = data.DistrictMonatery;
                    row.ProvinceMonatery = data.ProvinceMonatery;
                    row.CountryMonatery = data.CountryMonatery;
                    row.PostCodeMonatery = data.PostCodeMonatery;

                    row.DepositaryName = data.DepositaryName;
                    row.DepositaryPhoneNo = data.DepositaryPhoneNo;
                    
                    row.LandRightsDocuments = data.LandRightsDocuments;
                    row.MonasteryAreaRai = data.MonasteryAreaRai;
                    row.MonasteryAreaNgan = data.MonasteryAreaNgan;
                    row.MonasteryAreaWa = data.MonasteryAreaWa;
                    row.MonasteryPhoneNo = data.MonasteryPhoneNo;

                    row.AbbotName = data.AbbotName;
 
                    row.AbbotImageUrl = data.AbbotImageUrl;
                    row.AbbotTemple = data.AbbotTemple;
                    row.EcclesiasticalTitle = data.EcclesiasticalTitle;
                    row.AbbotTitle = data.AbbotTitle;

                    row.AbbotPhoneNo = data.AbbotPhoneNo;
                    row.AbbotEmail = data.AbbotEmail;
                    row.AbbotLineId = data.AbbotLineId;

                    row.DateOfAcceptPosition = data.DateOfAcceptPosition;
                    row.DateOfBirth = data.DateOfBirth;
                    row.DateOfOrdination = data.DateOfOrdination;
                    row.DateOfRegister = data.DateOfRegister;

                    row.Preceptor = data.Preceptor;
                    row.PreceptorTemple = data.PreceptorTemple;

                    row.CertifierName = data.CertifierName;
                    row.CertifierTemple = data.CertifierTemple;

                    ctx.TBranches.Update(row);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<BranchViewModel> searchBranch(string message)
        {
            List<BranchViewModel> result = [];
            try
            {
                result = _mapper.ToViews(calPhranSa(searchByName(message)));
            }
            catch (Exception)
            {

                throw;
            }

            return result;
            
        }

        public List<BranchViewModel> getAllBranch()
        {
            List<BranchViewModel> result = [];
            try
            {
                result = _mapper.ToViews(calPhranSa(getBranchByTypeID(1)));
            }
            catch (Exception)
            {

                throw;
            }
            
            return result;
        }
        public List<BranchViewModel> getAllReserve()
        {
            List<BranchViewModel> result = [];
            try
            {
                result = _mapper.ToViews(calPhranSa(getBranchByTypeID(2)));
            }
            catch (Exception)
            {

                throw;
            }
            
            return result;
        }
        public List<BranchViewModel> getAllSurvey()
        {
            List<BranchViewModel> result = [];
            try
            {
                result = _mapper.ToViews(calPhranSa(getBranchByTypeID(3)));
            }
            catch (Exception)
            {

                throw;
            }
            
            return result;
        }
        
    }
}
