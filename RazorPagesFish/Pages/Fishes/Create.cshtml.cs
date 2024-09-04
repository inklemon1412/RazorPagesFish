using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesFish.Data;
using RazorPagesFish.Models;

namespace RazorPagesFish.Pages.Fishes
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesFish.Data.RazorPagesFishContext _context;

        public CreateModel(RazorPagesFish.Data.RazorPagesFishContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Fish Fish { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Fish.Add(Fish);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
