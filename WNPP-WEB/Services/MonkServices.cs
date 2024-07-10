using Microsoft.EntityFrameworkCore;
using WNPP_WEB.Models;

namespace WNPP_WEB.Services
{
    public interface IMonkServices : IBranchServices
    {
  
    }
    public class MonkServices : BranchServices, IMonkServices
    {
        private readonly Wnpp67Context ctx = new Wnpp67Context();
        private readonly Imdb67Context ctxImG = new Imdb67Context();
        public MonkServices() { 
        }
  

    }
}
