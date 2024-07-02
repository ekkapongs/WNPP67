using Microsoft.EntityFrameworkCore;
using WNPP_WEB.Models;

namespace WNPP_WEB.Services
{
    public interface IFileServices : ICommonService
    {
        public Task<TAbbotImg> PostAbbotImage(AbbotImageViewModel view);
        public Byte[] getImage(int Id);
        public Byte[] getAbbotImage(int Id);
        public List<TAbbotImg> getAllAbbotImage();

    }
    public class FileServices : CommonService, IFileServices
    {
        private readonly Imdb67Context ctx = new Imdb67Context();
        private readonly Wnpp67Context ctxDB = new Wnpp67Context();
        public List<TAbbotImg> getAllAbbotImage()
        {
            try
            {
                return ctx.TAbbotImgs.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Byte[] getAbbotImage(int Id)
        {
            try
            {
                var file = ctx.TAbbotImgs.Where(x => x.Id == Id && x.ActiveStatus == true).FirstOrDefaultAsync();
                return file.Result.ImgBinary.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Byte[] getImage(int Id)
        {
            try
            {
                var file = ctx.TAbbotImgs.Where(x => x.Id == Id).FirstOrDefaultAsync();
                return file.Result.ImgBinary.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<TAbbotImg> PostAbbotImage(AbbotImageViewModel view)
        {
            TAbbotImg result = null;
            try
            {
                IFormFile fileData = view.FileUploadFormFile;

                result = new TAbbotImg()
                {
                    ActiveStatus = _Record_Active,
                    LanguageId = _Lang_TH,

                    CreatedBy = _Admin_ID,
                    CreatedByName = _Admin_Name,
                    CreatedDate = DateTime.Now,

                    AbbotName = view.AbbotName,
                };

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    result.ImgType = result.ToString();
                    result.ImgSize = stream.Length;
                    result.ImgBinary = stream.ToArray();
                }

                ctx.TAbbotImgs.Add(result);
                await ctx.SaveChangesAsync();

                var row = ctxDB.TBranches.Where(x =>
                            x.ActiveStatus == true &&
                            x.Id == view.DataId).FirstOrDefault();

                row.AbbotImageUrl = "/File/GetAbbotImage?id=" + result.Id;
                ctxDB.TBranches.Update(row);
                ctxDB.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
      
    }
}
