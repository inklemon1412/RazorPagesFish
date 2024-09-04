using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesFish.Data;
using RazorPagesFish.Models;

namespace RazorPagesFish.Pages.Fishes
{
   
    public class IndexModel : PageModel
    {
        private readonly RazorPagesFish.Data.RazorPagesFishContext _context;

        public IndexModel(RazorPagesFish.Data.RazorPagesFishContext context)
        {
            _context = context;
        }

        public IList<Fish> Fish { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Types { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FishType { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string>typeQuery = from f in _context.Fish
                                          orderby f.Type
                                          select f.Type;
            var fishes = from f in _context.Fish
                       select f;
            if (!string.IsNullOrEmpty(SearchString))
            {
                fishes = fishes.Where(s => s.Name.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(FishType))
            {
                fishes = fishes.Where(x => x.Type == FishType);
            }
            Types = new SelectList(await typeQuery.Distinct().ToListAsync());
           Fish = await fishes.ToListAsync();
           // Fish = await _context.Fish.ToListAsync();

        }

    }
}
