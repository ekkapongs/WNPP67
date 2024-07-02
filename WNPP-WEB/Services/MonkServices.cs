using Microsoft.EntityFrameworkCore;
using WNPP_WEB.Models;

namespace WNPP_WEB.Services
{
    public interface IMonkServices : IBranchServices
    {
        public List<TAbbotImg> getAllAbbotImage();
    }
    public class MonkServices : BranchServices, IMonkServices
    {
        private readonly Wnpp67Context ctx = new Wnpp67Context();
        private readonly Imdb67Context ctxImG = new Imdb67Context();
        public MonkServices() { 
        }
        public List<TAbbotImg> getAllAbbotImage()
        {
            try
            {
                return ctxImG.TAbbotImgs.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
