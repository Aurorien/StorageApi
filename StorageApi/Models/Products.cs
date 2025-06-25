using System.ComponentModel.DataAnnotations;

namespace StorageApi.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public int Price { get; set; }

        [Required]
        public string Category { get; set; } = null!;

        [Required]
        public string Shelf { get; set; } = string.Empty;

        public int Count { get; set; }

        public required string Description { get; set; }
    }
}
