using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductInventory.Api.Models;

namespace ProductInventory.Api.Data;

public class ApplicationDbContext : DbContext
{

    public DbSet<Products> products { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Products>()
            .Property(c => c.Categories)
            .HasConversion(
                new ValueConverter<List<Category>, string>(
                    value => JsonSerializer.Serialize(value, (JsonSerializerOptions?)null),
                    static value => JsonSerializer.Deserialize<List<Category>>(value, (JsonSerializerOptions?)null) ?? new List<Category>()
                )
            )
            .Metadata.SetValueComparer(
                new ValueComparer<List<Category>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()
                )
            );
    }
}