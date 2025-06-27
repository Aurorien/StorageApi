using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public class UpdatePatchProductDto
    {
        [StringLength(200, MinimumLength = 1)]
        public string? Name { get; set; }

        [Range(0, 500000)]
        public int? Price { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string? Category { get; set; }

        [StringLength(100, MinimumLength = 1)]
        public string? Shelf { get; set; }

        [Range(1, 100000)]
        public int? Count { get; set; }

        [StringLength(4000, MinimumLength = 1)]
        public string? Description { get; set; }
    }
}
