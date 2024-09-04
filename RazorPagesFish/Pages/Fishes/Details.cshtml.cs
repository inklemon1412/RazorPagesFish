using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesFish.Data;
using RazorPagesFish.Models;

namespace RazorPagesFish.Pages.Fishes
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesFish.Data.RazorPagesFishContext _context;

        public DetailsModel(RazorPagesFish.Data.RazorPagesFishContext context)
        {
            _context = context;
        }

        public Fish Fish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fish = await _context.Fish.FirstOrDefaultAsync(m => m.Id == id);
            if (fish == null)
            {
                return NotFound();
            }
            else
            {
                Fish = fish;
            }
            return Page();
        }
    }
}
