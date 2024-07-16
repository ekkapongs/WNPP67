using WNPP_WEB.Models;
using WNPP_WEB.Models.ViewModels;

namespace WNPP_WEB.Services.Mappers
{
    public interface IMonkMapper
    {
        public PhanSaViewModel ToPhanSaView(TBuddhistLent bl);
        public List<PhanSaViewModel> ToPhanSaViews(List<TBuddhistLent> bls);
    }
    public class MonkMapper : IMonkMapper
    {
        public List<PhanSaViewModel> ToPhanSaViews(List<TBuddhistLent> bls)
        {
            List<PhanSaViewModel> result = new List<PhanSaViewModel>();
            foreach (var bl in bls)
            {
                result.Add(ToPhanSaView(bl));
            }
            return result;
        }

        public PhanSaViewModel ToPhanSaView(TBuddhistLent bl)
        {
            PhanSaViewModel result = new PhanSaViewModel()
            {
                Id = bl.Id,
                BuddhistLentYear = bl.BuddhistLentYear,
                BuddhistLentStartDate = bl.BuddhistLentStartDate,
                BuddhistLentEndDate = bl.BuddhistLentEndDate,
                BuddhistLentInFo = bl.BuddhistLentInFo,

                MonkCount = bl.MonkCount,
                NoviceCount = bl.NoviceCount,
                NunsCount = bl.NunsCount,
                UpasikaCount = bl.UpasikaCount,
            };

            return result;
        }
    }
}
