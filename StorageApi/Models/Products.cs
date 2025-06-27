using System.ComponentModel.DataAnnotations;

namespace StorageApi.Models
{
    public class Products // Keep it as a class (not a record as the DTOs). Entity classes work better with Entity Framework because EF needs to mutate properties for change tracking, while records are designed to be immutable and would require creating new instances instead of modifying existing ones.
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

        [Required]
        [Range(1, 100000)]
        public int Count { get; set; }

        [StringLength(4000, MinimumLength = 1)] // The StringLength attribute only validates when the value is not null
        public string? Description { get; set; }
    }
}
