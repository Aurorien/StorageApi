using System.ComponentModel.DataAnnotations;

namespace StorageApi.Models
{
    public class Products // Keep it as a class (not a record as the DTOs). Entity classes work better with Entity Framework because EF needs to mutate properties for change tracking, while records are designed to be immutable and would require creating new instances instead of modifying existing ones.
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; } = null!;

        [Range(0, 500000)]
        public int Price { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string Category { get; set; } = null!;

        [StringLength(100, MinimumLength = 1)]
        public string Shelf { get; set; } = null!;

        [Range(1, 100000)]
        public int Count { get; set; }

        [StringLength(4000, MinimumLength = 1)] // The StringLength attribute only validates when the value is not null
        public string? Description { get; set; }
    }
}
