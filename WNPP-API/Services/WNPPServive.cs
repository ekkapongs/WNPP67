using Microsoft.EntityFrameworkCore;
using WNPP_API.Models;

namespace WNPP_API.Services
{
    public interface IWNPPServive
    {
        public List<TBranch> getAllBranch();
        public List<TBranch>? getBranchByTypeID(int typeID);
        public List<TBranch>? findByAbbotName(String abbotName);
        public List<TBranch>? findByMonasteryName(String monasteryName);
        public List<TBranch>? searchByName(String name);
    }
    public class WNPPServive: CommonService, IWNPPServive
    {
        private readonly Wnpp66Context ctx = new Wnpp66Context();
        public List<TBranch>? searchByName(String name)
        {
            List<TBranch> result = null;
            try
            {
                var rows = ctx.TBranches.Where(x =>
                            x.ActiveStatus == true && 
                            (
                                x.BranchName.Contains(name) ||
                                x.MonasteryName.Contains(name) ||
                                x.AbbotName.Contains(name) ||
                                x.AddressTextMonatery.Contains(name) ||
                                x.SubDistrictMonatery.Contains(name) ||
                                x.DistrictMonatery.Contains(name) ||
                                x.ProvinceMonatery.Contains(name)
                            )
                            
                            ).AsNoTracking().ToList();

                if (!rows.Any())
                {
                    throw new Exception($"Search data is not found by [ { name } ].");

                }
                result = rows;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public List<TBranch>? findByMonasteryName(String monasteryName)
        {
            List<TBranch> result = null;
            try
            {
                var rows = ctx.TBranches.Where(x =>
                            x.ActiveStatus == true &&
                            x.MonasteryName.Contains(monasteryName)).AsNoTracking().ToList();

                if (!rows.Any())
                {
                    throw new Exception($"No data by Monastery Name:[ {monasteryName} ] is not found.");

                }
                result = rows;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public List<TBranch>? findByAbbotName(String abbotName)
        {
            List<TBranch> result = null;
            try
            {
                var rows = ctx.TBranches.Where(x => 
                            x.ActiveStatus == true && 
                            x.AbbotName.Contains(abbotName) ).AsNoTracking().ToList();

                if (!rows.Any())
                {
                    throw new Exception($"No data by Abbot Name:[ {abbotName} ] is not found.");

                }
                result = rows;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public List<TBranch>? getBranchByTypeID(int typeID)
        {
            List<TBranch> result = null;
            try
            {
                var rows = ctx.TBranches.Where(x => x.ActiveStatus == true && x.BranchType == typeID).AsNoTracking().ToList();
                if (!rows.Any())
                {
                    throw new Exception($"No data by type ID [{typeID}] is not found. ");

                }
                result = rows;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public List<TBranch>? getAllBranch()
        {
            List<TBranch> result = null;
            try
            {
                var rows = ctx.TBranches.Where(x => x.ActiveStatus == true).AsNoTracking().ToList();
                if (!rows.Any())
                {
                    throw new Exception($"No data is not found. ");
                    
                }
                result = rows;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
