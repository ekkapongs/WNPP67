using Microsoft.EntityFrameworkCore;
using WNPP_WEB.Models;

namespace WNPP_WEB.Services
{
    public interface IWNPPServive : IFileServices
    {
        public List<TBranch> getAllBranch();
        public List<TBranch>? getBranchByTypeID(int typeID);

        public TBranch? findByID(int ID);
        public List<TBranch>? findByAbbotName(String abbotName);
        public List<TBranch>? findByMonasteryName(String monasteryName);

        public List<TBranch>? searchByName(String name);
        public List<TBranch>? searchByName2(String name);
        public List<TBranch>? calPhranSa(List<TBranch> datas);
    }
    public class WNPPServive: FileServices, IWNPPServive
    {

        private readonly Wnpp67Context ctx = new Wnpp67Context();

        public List<TBranch>? calPhranSa(List<TBranch> datas)
        {
            List<TBranch> result = new List<TBranch>();
            string countYearOfOrdinate;
            string countYearOfAge;
            try
            {
                foreach (TBranch data in datas)
                {
                    if (data.OrdainedAtAge > 0)
                    {
                        countYearOfOrdinate = (DateTime.Now.Year - ((DateTime)data.DateOfOrdination).Year) + " พรรษา";
                        countYearOfAge = (DateTime.Now.Year - ((DateTime)data.DateOfBirth).Year) + " ปี";

                        data.Notation = data.Notation + " ปัจจุบันอายุ " + countYearOfAge + " " + countYearOfOrdinate;
                    }
                    else
                    {
                        data.Notation = "--ไม่มีข้อมูล--";
                    }

                    result.Add(data);
                }

            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<TBranch>? searchByName2(String name)
        {
            List<TBranch> result = new List<TBranch>();
            try
            {
                result = calPhranSa(searchByName(name));
                
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
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
        public TBranch? findByID(int ID)
        {
            TBranch result = null;
            try
            {
                var rows = ctx.TBranches.Where(x =>
                            x.ActiveStatus == true &&
                            x.Id == ID).AsNoTracking().ToList();

                if (!rows.Any())
                {
                    throw new Exception($"No data by ID :[ {ID} ] is not found.");

                }
                result = rows.FirstOrDefault();
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
