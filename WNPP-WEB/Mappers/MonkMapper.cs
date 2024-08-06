using Microsoft.AspNetCore.Http.HttpResults;
using WNPP_WEB.Models;
using WNPP_WEB.Models.ViewModels;

namespace WNPP_WEB.Mappers
{
    public interface IMonkMapper
    {
        public PhanSaViewModel ToPhanSaView(TBuddhistLent bl);
        public List<PhanSaViewModel> ToPhanSaViews(List<TBuddhistLent> bls);

        public TMonkViewModel ToMonkView(TMonk monk);
        public List<TMonkViewModel> ToMonkViews(List<TMonk> monk);
    }
    public class MonkMapper : IMonkMapper
    {
        public List<TMonkViewModel> ToMonkViews(List<TMonk> monks)
        {
            List<TMonkViewModel> result = new List<TMonkViewModel>();
            foreach (var monk in monks)
            {
                result.Add(ToMonkView(monk));
            }
            return result;
        }
        public TMonkViewModel ToMonkView(TMonk monk)
        {
            TMonkViewModel result = new TMonkViewModel()
            {
                Id = monk.Id,
                ActiveStatus = monk.ActiveStatus,
                LanguageId = monk.LanguageId,
                RecordStatus = monk.RecordStatus,
                CreatedBy = monk.CreatedBy,
                ModifiedBy = monk.ModifiedBy,
                CreatedByName = monk.CreatedByName,
                ModifiedByName = monk.ModifiedByName,
                Notation = monk.Notation,
                CreatedDate = monk.CreatedDate,
                ModifiedDate = monk.ModifiedDate,
                MonkType = monk.MonkType,
                MonkTypeName = monk.MonkTypeName,
                MonkName = monk.MonkName,
                MFirstName = monk.MFirstName,
                MSurName = monk.MSurName,
                MNickName = monk.MNickName,
                MDateOfBirth = monk.MDateOfBirth,
                MPid = monk.MPid,
                MHouseNo = monk.MHouseNo,
                MMoo = monk.MMoo,
                MVillage = monk.MVillage,
                MRoad = monk.MRoad,
                MSubDistrict = monk.MSubDistrict,
                MDistrict = monk.MDistrict,
                MProvince = monk.MProvince,
                MCountry = monk.MCountry,
                MPostCode = monk.MPostCode,
                MEthnicity = monk.MEthnicity,
                MNationality = monk.MNationality,
                DateOfOrdination = monk.DateOfOrdination,
                TempleName = monk.TempleName,
                TSubDistrict = monk.TSubDistrict,
                TDistrict = monk.TDistrict,
                TProvince = monk.TProvince,
                CertificateForMonksNo = monk.CertificateForMonksNo,
                ParticipateTemple = monk.ParticipateTemple,
                PtSubDistrict = monk.PtSubDistrict,
                PtDistrict = monk.PtDistrict,
                PtProvince = monk.PtProvince,
                Preceptor = monk.Preceptor,
                PTemple = monk.PTemple,
                PSubDistrict = monk.PSubDistrict,
                PDistrict = monk.PDistrict,
                PProvince = monk.PProvince,
                FirstOrdinationTeacher = monk.FirstOrdinationTeacher,
                FTemple = monk.FTemple,
                FSubDistrict = monk.FSubDistrict,
                FDistrict = monk.FDistrict,
                FProvince = monk.FProvince,
                SecondOrdinationTeacher = monk.SecondOrdinationTeacher,
                STemple = monk.STemple,
                SSubDistrict = monk.SSubDistrict,
                SDistrict = monk.SDistrict,
                SProvince = monk.SProvince,
                MPhoneNo = monk.MPhoneNo,
                MEmail = monk.MEmail,
                MLineId = monk.MLineId,

            };
            return result;
        }
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
