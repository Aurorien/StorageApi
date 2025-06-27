using System.ComponentModel.DataAnnotations;

namespace StorageApi.Models
{
    public record ProductsDto
    (
        [Required]
        [StringLength(4000, MinimumLength = 1)]
        int Id,

        [Required] // Runtime required constraint (at program execution and object lifetime)
        [StringLength(200, MinimumLength = 1)]
        string Name,

        [Range(0, 500000)]
         int Price,

        [Required]
        [StringLength(200, MinimumLength = 1)]
        string Category,

        [Required]
        [StringLength(100, MinimumLength = 1)]
        string Shelf,

        [Required]
        [Range(1, 100000)]
        int Count,

        [StringLength(4000, MinimumLength = 1)] // The StringLength attribute only validates when the value is not null
        string? Description = null
    );
}
