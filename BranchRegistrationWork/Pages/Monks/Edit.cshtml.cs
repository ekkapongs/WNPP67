using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BranchRegistrationWork.Data;
using BranchRegistrationWork.Models;

namespace BranchRegistrationWork.Pages.Monks
{
    public class EditModel : PageModel
    {
        private readonly BranchRegistrationWork.Data.BranchRegistrationWorkContext _context;

        public EditModel(BranchRegistrationWork.Data.BranchRegistrationWorkContext context)
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

            var monk =  await _context.Monk.FirstOrDefaultAsync(m => m.Id == id);
            if (monk == null)
            {
                return NotFound();
            }
            Monk = monk;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Monk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonkExists(Monk.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MonkExists(int id)
        {
            return _context.Monk.Any(e => e.Id == id);
        }
    }
}
