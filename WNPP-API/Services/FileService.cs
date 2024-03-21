
using Microsoft.EntityFrameworkCore;
using WNPP_API.Models;

namespace WNPP_API.Services
{
    public enum FileType
    {
        image = 1,
        PDF = 2,
        DOCX = 3
    }
    public interface IFileService
    {
        public Task<int> PostFileAsync(IFormFile fileData, FileType fileType);

        public Task DownloadFileById(int fileName);
        public Byte[] getImage(int Id);

    }
    public class FileService : CommonService, IFileService
    {
        private readonly Wnpp66Context ctx = new Wnpp66Context();
        public async Task<int> PostFileAsync(IFormFile fileData, FileType fileType)
        {
            int result = 0;
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
                    tFileOnDb.FileType = fileType.ToString();
                    tFileOnDb.FileSize = stream.Length;
                    tFileOnDb.FileBinary = stream.ToArray();
                }
                ctx.TFileOnDbs.Add(tFileOnDb);
                await ctx.SaveChangesAsync();
                result = tFileOnDb.Id;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
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
