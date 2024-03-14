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
    public class DeleteModel : PageModel
    {
        private readonly BranchRegistrationWork.Data.BranchRegistrationWorkContext _context;

        public DeleteModel(BranchRegistrationWork.Data.BranchRegistrationWorkContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Monk Monk { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monk = await _context.Monk.FirstOrDefaultAsync(m => m.Id == id);

            if (monk == null)
            {
                return NotFound();
            }
            else
            {
                Monk = monk;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monk = await _context.Monk.FindAsync(id);
            if (monk != null)
            {
                Monk = monk;
                _context.Monk.Remove(Monk);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
