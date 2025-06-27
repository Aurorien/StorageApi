using System.ComponentModel.DataAnnotations;

namespace StorageApi.DTOs
{
    public record UpdatePutProductDto
    (
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

        [Range(1, 100000)]
        int Count,

        [Required]
        [StringLength(4000, MinimumLength = 1)]
        string Description
    );

    //public class UpdatePutProductDto
    //{
    //    [Required] // Runtime required constraint (at program execution and object lifetime)
    //    [StringLength(200, MinimumLength = 1)]
    //    public required string Name { get; set; }  // Compile-time required constraint (at build and object creation)

    //    [Range(0, 500000)]
    //    public int Price { get; set; }

    //    [Required]
    //    [StringLength(200, MinimumLength = 1)]
    //    public required string Category { get; set; }

    //    [Required]
    //    [StringLength(100, MinimumLength = 1)]
    //    public required string Shelf { get; set; }

    //    [Range(1, 100000)]
    //    public int Count { get; set; }

    //    [Required]
    //    [StringLength(4000, MinimumLength = 1)]
    //    public required string Description { get; set; }
    //}
}
