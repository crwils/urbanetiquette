using Microsoft.EntityFrameworkCore;
using UrbanEtiquette.Core.Entities.Users;
using System.Reflection;
using UrbanEtiquette.Core.Common;
using UrbanEtiquette.Application.Common.Interfaces;
using UrbanEtiquette.Core.Entities.Tips;
using UrbanEtiquette.Core.Entities.Locations;
using UrbanEtiquette.Core.Entities.Venues;

namespace UrbanEtiquette.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<TipEntity> Tips { get; set; } = null!;
    public DbSet<LocationEntity> Locations { get; set; } = null!;
    public DbSet<VenueEntity> Venues { get; set; } = null!;
    public DbSet<VenueTypeEntity> VenueTypes { get; set; } = null!;
    public DbSet<VenueCategoryEntity> VenueCategories { get; set; } = null!;

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

        // Venue → Location (Many-to-One)
        builder.Entity<VenueEntity>()
            .HasOne(v => v.Location)
            .WithMany()
            .HasForeignKey(v => v.LocationId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Venue → VenueType (Many-to-One)
        builder.Entity<VenueEntity>()
            .HasOne(v => v.VenueType)
            .WithMany()
            .HasForeignKey(v => v.VenueTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Tip → Location (Many-to-One) 
        builder.Entity<TipEntity>()
            .HasOne(t => t.Location)
            .WithMany(l => l.Tips)
            .HasForeignKey(t => t.LocationId)
            .OnDelete(DeleteBehavior.SetNull);

        // Tip → User (Many-to-One)
        builder.Entity<TipEntity>()
            .HasOne(t => t.User)
            .WithMany()
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Tip → VenueType (Many-to-One)
        builder.Entity<TipEntity>()
            .HasOne(t => t.VenueType)
            .WithMany()
            .HasForeignKey(t => t.VenueTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // VenueType → VenueCategory (Many-to-One)
        builder.Entity<VenueTypeEntity>()
            .HasOne(vt => vt.VenueCategory)
            .WithMany()
            .HasForeignKey(vt => vt.VenueCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // VenueType → Location (Many-to-One, Optional)
        builder.Entity<VenueTypeEntity>()
            .HasOne(vt => vt.Location)
            .WithMany()
            .HasForeignKey(vt => vt.LocationId)
            .OnDelete(DeleteBehavior.SetNull);

        // User → Location (Many-to-One, Optional)
        // Set the cascade delete behavior to set the LocationId to null instead of deleting the Location
        builder.Entity<UserEntity>()
            .HasOne(u => u.Location)
            .WithMany()
            .HasForeignKey(u => u.LocationId)
            .OnDelete(DeleteBehavior.SetNull);

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