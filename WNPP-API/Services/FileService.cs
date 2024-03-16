
using Microsoft.EntityFrameworkCore;
using WNPP_API.Models;

namespace WNPP_API.Services
{
    public enum FileType
    {
        PDF = 1,
        DOCX = 2
    }
    public interface IFileService
    {
        public Task PostFileAsync(IFormFile fileData);

        public Task DownloadFileById(int fileName);
        public Byte[] getImage(int Id);

    }
    public class FileService : CommonService, IFileService
    {
        private readonly Wnpp66Context ctx = new Wnpp66Context();
        public async Task PostFileAsync(IFormFile fileData)
        {
            try
            {
                var tFileOnDb = new TFileOnDb()
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
                    tFileOnDb.FileBinary = stream.ToArray();
                }
                ctx.TFileOnDbs.Add(tFileOnDb);
                await ctx.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public async Task DownloadFileById(int Id)
        {
            try
            {
                var file = ctx.TFileOnDbs.Where(x => x.Id == Id).FirstOrDefaultAsync();
                var content = new System.IO.MemoryStream(file.Result.FileBinary);
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "FileDownloaded",
                   file.Result.FileName);

                await CopyStream(content, path);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        public Byte[] getImage(int Id)
        {
            try
            {
                var file = ctx.TFileOnDbs.Where(x => x.Id == Id).FirstOrDefaultAsync();
                return file.Result.FileBinary.ToArray();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
