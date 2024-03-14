using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BranchRegister.Models;

namespace BranchRegister.Data
{
    public class BranchRegisterContext : DbContext
    {
        public BranchRegisterContext (DbContextOptions<BranchRegisterContext> options)
            : base(options)
        {
        }

        public DbSet<BranchRegister.Models.TBranch> TBranch { get; set; } = default!;
    }
}
