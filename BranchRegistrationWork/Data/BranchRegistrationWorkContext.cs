using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BranchRegistrationWork.Models;

namespace BranchRegistrationWork.Data
{
    public class BranchRegistrationWorkContext : DbContext
    {
        public BranchRegistrationWorkContext (DbContextOptions<BranchRegistrationWorkContext> options)
            : base(options)
        {
        }

        public DbSet<BranchRegistrationWork.Models.Monk> Monk { get; set; } = default!;
    }
}
