using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using WNPP_WEB.Models;
using WNPP_WEB.Models.ViewModels;
using WNPP_WEB.Services.Mappers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WNPP_WEB.Services
{
    public interface IMonkServices : IBranchServices
    {
        public List<TMonk> searchMonkByName(string name);
        public List<TMonkViewModel> searchMonk(string txtSearch);
        public TMonk getMonkByName(string name);
        public TMonk getMonk(int id);
        public TMonkViewModel getMonkView(int id);
        public List<PhanSaViewModel> getAllBuddhistLent();
        public void add2BuddhistLent(PhanSaViewModel data);
        public PhanSaViewModel getPhanSaViewModel(int year);
        public void addMonkBuddhistLentDetail(PhanSaViewModel data);
        public void editBL2Monk(TMonkViewModel monk);
        public TMonk edit2Monk(TMonkViewModel monk);
    }
    public class MonkServices : BranchServices, IMonkServices
    {
        private IMonkMapper _mapper;
        private readonly Wnpp67Context ctx = new Wnpp67Context();
        private readonly Imdb67Context ctxImG = new Imdb67Context();
        public MonkServices()
        {
            _mapper = new MonkMapper();
        }
        public List<TMonk> searchMonkByName(string name)
        {
            List<TMonk> result = new List<TMonk>();
            try
            {
                result = ctx.TMonks.Where(x =>
                            x.ActiveStatus == true &&
                            x.MonkName.Contains(name)).AsNoTracking().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public TMonk getMonkByName(string name)
        {
            TMonk result = null;
            try
            {
                var rows = ctx.TMonks.Where(x =>
                           x.ActiveStatus == true &&
                           x.MonkName.Equals(name)).AsNoTracking().ToList();
                if (!rows.Any())
                {
                    throw new Exception($"getMonkByName is not found by [ {name} ].");

                }
                result = rows.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public List<TMonkViewModel> searchMonk(string txtSearch)
        {
            List<TMonkViewModel> result = new List<TMonkViewModel>();
            try
            {
                var rows = ctx.TMonks.Where(x =>
                            x.ActiveStatus == true &&
                            (
                                x.MonkName.Contains(txtSearch) ||
                                x.MFirstName.Contains(txtSearch) ||
                                x.MSurName.Contains(txtSearch) ||
                                x.MNickName.Contains(txtSearch) ||
                                x.MSubDistrict.Contains(txtSearch) ||
                                x.MDistrict.Contains(txtSearch) ||
                                x.MProvince.Contains(txtSearch)
                            )
                            ).AsNoTracking().ToList();
                if (!rows.Any())
                {
                    throw new Exception($"Search data is not found by [ {txtSearch} ].");

                }
                result = _mapper.ToMonkViews(rows);

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public void editBL2Monk(TMonkViewModel mv)
        {
            TMonk row = null;
            TBuddhistLent bl = null;
            TBuddhistLentDetail blDetail = null;
            try
            {
                row = edit2Monk(mv);
                
                bl = ctx.TBuddhistLents.Where(x =>
                        x.ActiveStatus == true &&
                        x.BuddhistLentYear == mv.BuddhistLentYear).FirstOrDefault();

                blDetail = ctx.TBuddhistLentDetails.Where(x =>
                            x.ActiveStatus == true &&
                            x.Blid == bl.Id &&
                            x.MonkId == mv.Id).FirstOrDefault();


                blDetail.ModifiedBy = row.ModifiedBy;
                blDetail.ModifiedByName = row.ModifiedByName;
                blDetail.ModifiedDate = DateTime.Now;

                blDetail.MonkNicName = row.MNickName;
                blDetail.DateOfBirth = row.MDateOfBirth;
                blDetail.DateOfOrdination = row.DateOfOrdination;
                blDetail.TempleName = row.TempleName;
                blDetail.Preceptor = row.Preceptor;

                ctx.TBuddhistLentDetails.Update(blDetail);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public TMonk edit2Monk(TMonkViewModel mv)
        {
            TMonk row = null;
            try
            {
                row = getMonk(mv.Id);

                row.ModifiedBy = _Admin_ID;
                row.ModifiedByName = _Admin_Name;
                row.ModifiedDate = DateTime.Now;

                row.MonkType = mv.MonkType;
                row.MonkName = mv.MonkName;
                row.MFirstName = mv.MFirstName;
                row.MSurName = mv.MSurName;
                row.MNickName = mv.MNickName;

                row.MDateOfBirth = strTHDateToDateTIme(mv.txtDateOfBirth);
                row.MPid = mv.MPid;
                row.MEthnicity = mv.MEthnicity;
                row.MNationality = mv.MNationality;

                row.MHouseNo = mv.MHouseNo;
                row.MMoo = mv.MMoo;
                row.MVillage = mv.MVillage;
                row.MRoad = mv.MRoad;
                row.MSubDistrict = mv.MSubDistrict;
                row.MDistrict = mv.MDistrict;
                row.MProvince = mv.MProvince;
                row.MPostCode = mv.MPostCode;
                row.MCountry = mv.MCountry;
                row.MPhoneNo = mv.MPhoneNo;
                row.MLineId = mv.MLineId;
                row.MEmail = mv.MEmail;

                row.DateOfOrdination = strTHDateToDateTIme(mv.txtDateOfOrdination);
                row.CertificateForMonksNo = mv.CertificateForMonksNo;
                row.TempleName = mv.TempleName;

                row.Preceptor = mv.Preceptor;
                row.PTemple = mv.PTemple;
                row.PSubDistrict = mv.PSubDistrict;
                row.PDistrict = mv.PDistrict;
                row.PProvince = mv.PProvince;

                row.FirstOrdinationTeacher = mv.FirstOrdinationTeacher;
                row.FTemple = mv.FTemple;
                row.FSubDistrict = mv.FSubDistrict;
                row.FDistrict = mv.FDistrict;
                row.FProvince = mv.FProvince;

                row.SecondOrdinationTeacher = mv.SecondOrdinationTeacher;
                row.STemple = mv.STemple;
                row.SSubDistrict = mv.SSubDistrict;
                row.SDistrict = mv.SDistrict;
                row.SProvince = mv.SProvince;

                ctx.TMonks.Update(row);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return row;
        }
        public TMonkViewModel getMonkView(int id)
        {
            TMonkViewModel result = null;
            try
            {
                result = _mapper.ToMonkView(getMonk(id));
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public TMonk getMonk(int id)
        {
            TMonk result = null;
            try
            {
                var rows = ctx.TMonks.Where(x =>
                            x.ActiveStatus == true &&
                            x.Id == id).ToList();

                if (!rows.Any()) throw new Exception($"ไม่พบข้อมูลที่กำหนด ID:{id} !!");

                result = (TMonk)rows[0];
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public void addMonkBuddhistLentDetail(PhanSaViewModel data)
        {
            TBuddhistLent bl;
            TBuddhistLentDetail detail;
            TMonk monk;

            DateTime BuddhistLentYear = new DateTime(data.BuddhistLentYear - 543, 1, 1);

            try
            {
                bl = ctx.TBuddhistLents.Where(x => 
                        x.ActiveStatus == true && 
                        x.BuddhistLentYear == data.BuddhistLentYear).FirstOrDefault();

                var datails = ctx.TBuddhistLentDetails.Where(x =>
                                x.ActiveStatus == true &&
                                x.Blid == bl.Id &&
                                x.MonkName.Contains(data.MonkName.Trim())).ToList();

                if (datails.Any()) throw new Exception($"มีข้อมูล {data.MonkName} ในตารางแล้ว !! ");

                var monks = ctx.TMonks.Where(x =>
                            x.ActiveStatus == true &&
                            x.MonkName.Equals(data.MonkName.Trim())).ToList();

                if (monks.Any())
                {
                    monk = monks.FirstOrDefault();

                    monk.ModifiedBy = _Admin_ID;
                    monk.ModifiedByName = _Admin_Name;
                    monk.ModifiedDate = DateTime.Now;

                    monk.MNickName = data.NickName.Trim();
                    monk.TempleName = data.TempleName.Trim();
                    monk.Preceptor = data.Preceptor.Trim();

                    monk.MDateOfBirth = strTHDateToDateTIme(data.DateOfBirth);
                    monk.DateOfOrdination = strTHDateToDateTIme(data.DateOfOrdination);

                    ctx.TMonks.Update(monk);
                }
                else
                {
                    monk = new TMonk()
                    {
                        ActiveStatus = _Record_Active,
                        LanguageId = _Lang_TH,
                        CreatedBy = _Admin_ID,
                        CreatedByName = _Admin_Name,
                        CreatedDate = DateTime.Now,

                        MonkType = data.MonkType,
                        MonkName = data.MonkName.Trim(),
                        MNickName = data.NickName.Trim(),
                        TempleName = data.TempleName.Trim(),
                        Preceptor = data.Preceptor.Trim(),

                        MDateOfBirth = strTHDateToDateTIme(data.DateOfBirth),
                        DateOfOrdination = strTHDateToDateTIme(data.DateOfOrdination),
                    };
                    ctx.TMonks.Add(monk);
                }
                ctx.SaveChanges();

                detail = new TBuddhistLentDetail()
                {
                    ActiveStatus = _Record_Active,
                    LanguageId = _Lang_TH,
                    CreatedBy = _Admin_ID,
                    CreatedByName = _Admin_Name,
                    CreatedDate = DateTime.Now,

                    MonkId = monk.Id,
                    Blid = bl.Id,

                    MonkName = monk.MonkName,
                    MonkNicName = monk.MNickName,
                    TempleName = monk.TempleName,
                    Preceptor = monk.Preceptor,

                    DateOfBirth = strTHDateToDateTIme(data.DateOfBirth),
                    DateOfOrdination = strTHDateToDateTIme(data.DateOfOrdination),

                    MonkAge = BuddhistLentYear.Year - strTHDateToDateTIme(data.DateOfBirth).Year,
                    MonkPhanSa = BuddhistLentYear.Year - strTHDateToDateTIme(data.DateOfOrdination).Year,
                };
                ctx.TBuddhistLentDetails.Add(detail);

                switch (monk.MonkType)
                {
                    case 1:
                        bl.MonkCount = bl.MonkCount == null ? 1 : bl.MonkCount + 1;
                        break;
                    case 2:
                        bl.NoviceCount = bl.NoviceCount == null ? 1 : bl.NoviceCount + 1;
                        break;
                    case 3:
                        bl.NunsCount = bl.NunsCount == null ? 1 : bl.NunsCount + 1;
                        break;
                    case 4:
                        bl.UpasakaCount = bl.UpasakaCount == null ? 1 : bl.UpasakaCount + 1;
                        break;
                    case 5:
                        bl.UpasikaCount = bl.UpasikaCount == null ? 1 : bl.UpasikaCount + 1;
                        break;

                }
                bl.ModifiedByName = _Admin_Name;
                bl.ModifiedDate = DateTime.Now;
                ctx.TBuddhistLents.Update(bl);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public PhanSaViewModel getPhanSaViewModel(int year)
        {
            PhanSaViewModel result = new PhanSaViewModel();

            try
            {
                var rows = ctx.TBuddhistLents.Where(x =>
                            x.ActiveStatus == true &&
                            x.BuddhistLentYear == year).AsNoTracking().ToList();

                if (!rows.Any())
                    throw new Exception($"ไม่พบข้อมูลปีพรรษา {year} . !!");

                result = _mapper.ToPhanSaView(rows.FirstOrDefault());
                result.Details = new List<TBuddhistLentDetail>();

                var details = ctx.TBuddhistLentDetails.Where(x =>
                                x.ActiveStatus == true &&
                                x.Blid == result.Id).AsNoTracking().ToList();

                result.Details.AddRange(details);

            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public List<PhanSaViewModel> getAllBuddhistLent()
        {
            List<PhanSaViewModel> result = new List<PhanSaViewModel>();
            result = _mapper.ToPhanSaViews(ctx.TBuddhistLents.ToList());
            return result;
        }

        public void add2BuddhistLent(PhanSaViewModel data)
        {
            try
            {
                var rows = ctx.TBuddhistLents.Where(x =>
                            x.ActiveStatus == true &&
                            x.BuddhistLentYear == data.BuddhistLentYear).ToList();

                if (rows.Any()) throw new Exception($"มีข้อมูลปี {data.BuddhistLentYear} อยู่แล้ว !!");

                TBuddhistLent buddhistLent = new TBuddhistLent()
                {
                    ActiveStatus = _Record_Active,
                    LanguageId = _Lang_TH,
                    CreatedBy = _Admin_ID,
                    CreatedByName = _Admin_Name,
                    CreatedDate = DateTime.Now,

                    BuddhistLentYear = data.BuddhistLentYear,
                    BuddhistLentStartDate = data.BuddhistLentStartDate,
                    BuddhistLentEndDate = data.BuddhistLentEndDate,
                    BuddhistLentInFo = data.BuddhistLentInFo,

                };

                ctx.TBuddhistLents.Add(buddhistLent);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
