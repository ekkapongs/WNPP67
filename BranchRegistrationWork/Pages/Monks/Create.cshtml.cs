using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BranchRegistrationWork.Data;
using BranchRegistrationWork.Models;

namespace BranchRegistrationWork.Pages.Monks
{
    public class CreateModel : PageModel
    {
        private readonly BranchRegistrationWork.Data.BranchRegistrationWorkContext _context;

        public CreateModel(BranchRegistrationWork.Data.BranchRegistrationWorkContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Monk Monk { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Monk.Add(Monk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
