using Microsoft.EntityFrameworkCore;
using RazorPagesFish.Models;

namespace RazorPagesFish.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesFishContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesFishContext>>()))
        {
            if (context == null || context.Fish == null)
            {
                throw new ArgumentNullException("Null RazorPagesFishContext");
            }
            if (context.Fish.Any())
            {
                return;
            }

            context.Fish.AddRange(
                new Fish
                {
                    Name = "Clown Fish",
                    Type = "Ocean",
                    Description = "Sadly comes without a clown nose"
                },
                new Fish
                {
                    Name = "Great White",
                    Type = "Ocean",
                    Description = "A big shark that is surprisingly grey despite its name"
                },
                new Fish
                {
                    Name = "Sardine",
                    Type = "Ocean",
                    Description = "Perfect on a pizza"
                }
               

         );
            context.SaveChanges();
        }
    }
}
