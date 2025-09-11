using Microsoft.EntityFrameworkCore;
using UrbanEtiquette.Core.Entities.Users;
using System.Reflection;
using UrbanEtiquette.Core.Common;
using UrbanEtiquette.Application.Common.Interfaces;

namespace UrbanEtiquette.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<User> Users { get; set; } = null!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Apply any entity configurations from the current assembly
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        // add specific configurations here as app grows
        // Eg:
        // builder.Entity<User>()
        //     .HasIndex(u => u.Email)
        //     .IsUnique();
        
        base.OnModelCreating(builder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Update timestamps on modified entities
        UpdateTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    private void UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity && 
                       (e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            if (entry.Entity is BaseEntity entity)
            {
                entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}