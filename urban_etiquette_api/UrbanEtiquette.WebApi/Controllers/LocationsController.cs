using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrbanEtiquette.Application.Common.Interfaces;
using UrbanEtiquette.Core.Entities.Locations;

namespace UrbanEtiquette.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly IApplicationDbContext _dbContext;

    public LocationsController(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET: api/locations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LocationEntity>>> GetLocations(CancellationToken cancellationToken)
    {
        var locations = await _dbContext.Locations.ToListAsync(cancellationToken);
        return Ok(locations);
    }

    // POST: api/locations
    [HttpPost]
    public async Task<ActionResult<LocationEntity>> CreateLocation(LocationEntity location, CancellationToken cancellationToken)
    {
        _dbContext.Locations.Add(location);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetLocation), new { id = location.Id }, location);
    }

    // GET: api/locations/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<LocationEntity>> GetLocation(Guid id, CancellationToken cancellationToken)
    {
        var location = await _dbContext.Locations.FindAsync([id], cancellationToken);

        if (location == null)
        {
            return NotFound();
        }

        return Ok(location);
    }

    // PUT: api/locations/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<LocationEntity>> UpdateLocation(Guid id, LocationEntity location, CancellationToken cancellationToken)
    {
        var existingLocation = await _dbContext.Locations.FindAsync([id], cancellationToken);

        if (existingLocation == null)
        {
            return NotFound();
        }

        existingLocation.Name = location.Name;
        existingLocation.CountryCode = location.CountryCode;
        existingLocation.Latitude = location.Latitude;
        existingLocation.Longitude = location.Longitude;
        return Ok(existingLocation);
    }

    // DELETE: api/locations/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult<LocationEntity>> DeleteLocation(Guid id, CancellationToken cancellationToken)
    {
        var location = await _dbContext.Locations.FindAsync([id], cancellationToken);

        if (location == null)
        {
            return NotFound();
        }

        _dbContext.Locations.Remove(location);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}