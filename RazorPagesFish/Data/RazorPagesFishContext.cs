using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesFish.Models;

namespace RazorPagesFish.Data
{
    public class RazorPagesFishContext : DbContext
    {
        public RazorPagesFishContext (DbContextOptions<RazorPagesFishContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesFish.Models.Fish> Fish { get; set; } = default!;
    }
}
