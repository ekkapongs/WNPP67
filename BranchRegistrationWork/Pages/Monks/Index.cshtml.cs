using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BranchRegistrationWork.Data;
using BranchRegistrationWork.Models;

namespace BranchRegistrationWork.Pages.Monks
{
    public class IndexModel : PageModel
    {
        private readonly BranchRegistrationWork.Data.BranchRegistrationWorkContext _context;

        public IndexModel(BranchRegistrationWork.Data.BranchRegistrationWorkContext context)
        {
            _context = context;
        }

        public IList<Monk> Monk { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Monk = await _context.Monk.ToListAsync();
        }
    }
}
