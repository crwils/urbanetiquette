using Microsoft.EntityFrameworkCore;
using UrbanEtiquette.Core.Entities.Users;

namespace UrbanEtiquette.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
}
