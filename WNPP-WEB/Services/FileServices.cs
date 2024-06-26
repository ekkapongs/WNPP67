using Microsoft.EntityFrameworkCore;
using WNPP_WEB.Models;

namespace WNPP_WEB.Services
{
    public interface IFileServices
    {
        public Task<TFileDb> PostFileAsync(IFormFile fileData);
        public Byte[] getImage(int Id);
    }
    public class FileServices : WNPPServive, IFileServices
    {
        private readonly Imdb67Context ctx = new Imdb67Context();
        public Byte[] getImage(int Id)
        {
            try
            {
                var file = ctx.TFileDbs.Where(x => x.Id == Id).FirstOrDefaultAsync();
                return file.Result.FileBinary.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<TFileDb> PostFileAsync(IFormFile fileData)
        {
            TFileDb result = null;
            try
            {
                result = new TFileDb()
                {
                    ActiveStatus = _Record_Active,
                    LanguageId = _Lang_TH,

                    CreatedBy = _Admin_ID,
                    CreatedByName = _Admin_Name,
                    CreatedDate = DateTime.Now,

                    FileName = fileData.FileName,
                };

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    result.FileType = result.ToString();
                    result.FileSize = stream.Length;
                    result.FileBinary = stream.ToArray();
                }

                ctx.TFileDbs.Add(result);
                await ctx.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
      
    }
}
