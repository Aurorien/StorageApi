using System.ComponentModel.DataAnnotations;

namespace StorageApi.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required] // Runtime required constraint (at program execution and object lifetime)
        [StringLength(200, MinimumLength = 1)]
        public required string Name { get; set; }  // Compile-time required constraint (at build and object creation)

        [Range(0, 500000)]
        public int Price { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public required string Category { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public required string Shelf { get; set; }

        public int Count { get; set; }

        [Required]
        [StringLength(4000, MinimumLength = 1)]
        public required string Description { get; set; }
    }
}
