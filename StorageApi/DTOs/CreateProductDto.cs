using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public class CreateProductDto
    {
        [Required] // Runtime required constraint (at program execution and object lifetime)
        public required string Name { get; set; }  // Compile-time required constraint (at build and object creation)

        public int Price { get; set; }

        [Required]
        public required string Category { get; set; }

        [Required]
        public required string Shelf { get; set; }

        public int Count { get; set; }

        [Required]
        public required string Description { get; set; }
    }
}
