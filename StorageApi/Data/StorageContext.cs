using Microsoft.EntityFrameworkCore;

public class StorageContext : DbContext
{
    public StorageContext(DbContextOptions<StorageContext> options)
        : base(options)
    {
    }

    public DbSet<StorageApi.Models.Products> Products { get; set; } = default!;
}
