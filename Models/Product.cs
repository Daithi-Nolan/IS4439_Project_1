using System.ComponentModel.DataAnnotations;

namespace IS4439_Project_1.Models
{
    // The Product model represents a single item in the MiniMart store.
    // It stores basic information like name, price, stock status, and a short description.
    public class Product
    {
        // Unique ID for each product
        public int Id { get; set; }

        // The name of the product (must be between 2 and 60 characters)
        [Required, StringLength(60, MinimumLength = 2)]
        public string Name { get; set; } = "";

        // The product price, with limits to prevent unrealistic values
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10000.")]
        public decimal Price { get; set; }

        // Tells the user whether the product is currently in stock or not
        [Display(Name = "In Stock")]
        public bool InStock { get; set; }

        // A short description to describe the product (max about 100 words)
        [Display(Name = "Short Description")]
        [StringLength(700, ErrorMessage = "Description must be 100 words or fewer (approximately 700 characters).")]
        public string? Description { get; set; }
    }
}
