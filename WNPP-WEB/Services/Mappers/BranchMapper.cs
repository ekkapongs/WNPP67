using WNPP_WEB.Models;

namespace WNPP_WEB.Services.Mappers
{
    public interface IBranchMapper
    {
        public List<BranchViewModel> ToViews(List<TBranch> branches);
        public BranchViewModel ToView(TBranch branch);

        public TBranchViewModel ToBranchView(TBranch branch);
    }
    public class BranchMapper: IBranchMapper
    {
        public TBranchViewModel ToBranchView(TBranch branch)
        {
            TBranchViewModel result = new TBranchViewModel();
            try
            {
                
            }
            catch (Exception ex)
            {
                result = new TBranchViewModel();
            }
            return result;
        }
        public List<BranchViewModel> ToViews(List<TBranch> branches)
        {
            List<BranchViewModel> result = new List<BranchViewModel>();
            BranchViewModel data;
            try
            {
                foreach (TBranch branch in branches)
                {
                    data = ToView(branch);
                    result.Add(data);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;

        }
        public BranchViewModel ToView(TBranch branch)
        {
            BranchViewModel result = new BranchViewModel();
            try
            {
                result = new BranchViewModel()
                {
                    Id = branch.Id,
                    BranchName = branch.BranchName,
                    MonasteryName = branch.MonasteryName,
                    MonasteryPhoneNO = branch.MonasteryPhoneNo,
                    AbbotName = branch.AbbotName,
                    AbbotImageUrl = branch.AbbotImageUrl,
                    Notation = branch.Notation,
                    CertifierName = branch.CertifierName,
                    CertifierTemple = branch.CertifierTemple,
                    AddressTextMonatery = branch.AddressTextMonatery,
                    SubDistrictMonatery = branch.SubDistrictMonatery,
                    DistrictMonatery = branch.DistrictMonatery,
                    ProvinceMonatery = branch.ProvinceMonatery,
                    CountryMonatery = branch.CountryMonatery,
                    PostCodeMonatery = branch.PostCodeMonatery,
                };
            }
            catch (Exception e)
            {
                throw;
            }
            return result;

        }
    }
}
