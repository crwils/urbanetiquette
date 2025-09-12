using Microsoft.EntityFrameworkCore;
using UrbanEtiquette.Core.Entities.Locations;
using UrbanEtiquette.Core.Entities.Tips;
using UrbanEtiquette.Core.Entities.Users;
using UrbanEtiquette.Core.Entities.Venues;

namespace UrbanEtiquette.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<UserEntity> Users { get; }
    DbSet<TipEntity> Tips { get; }
    DbSet<LocationEntity> Locations { get; }
    DbSet<VenueEntity> Venues { get; }
    DbSet<VenueTypeEntity> VenueTypes { get; }
    DbSet<VenueCategoryEntity> VenueCategories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
}
