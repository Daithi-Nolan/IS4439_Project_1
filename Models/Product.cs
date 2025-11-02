using System.ComponentModel.DataAnnotations;

namespace IS4439_Project_1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(60, MinimumLength = 2)]
        public string Name { get; set; } = "";

        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10000.")]
        public decimal Price { get; set; }

        [Display(Name = "In Stock")]
        public bool InStock { get; set; }

        [Display(Name = "Short Description")]
        [StringLength(700, ErrorMessage = "Description must be 100 words or fewer (approximately 700 characters).")]
        public string? Description { get; set; }
    }
}
