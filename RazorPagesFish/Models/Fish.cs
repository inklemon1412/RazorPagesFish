using System.ComponentModel.DataAnnotations;

namespace RazorPagesFish.Models
{
    public class Fish
    {
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 2)]
        [Required]
        public string? Name { get; set; }
            
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(10)]
        public string? Type { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string? Description { get; set; }
    }
}
