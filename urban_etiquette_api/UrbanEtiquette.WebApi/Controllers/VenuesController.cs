

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrbanEtiquette.Application.Common.Interfaces;
using UrbanEtiquette.Core.Entities.Venues;

namespace UrbanEtiquette.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VenuesController : ControllerBase
{
    private readonly IApplicationDbContext _dbContext;

    public VenuesController(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    #region Venues
    // GET: api/venues
    [HttpGet("venues")]
    public async Task<ActionResult<IEnumerable<VenueEntity>>> GetVenues(CancellationToken cancellationToken)
    {
        var venues = await _dbContext.Venues.ToListAsync(cancellationToken);
        return Ok(venues);
    }

    // POST: api/venues
    [HttpPost("venues")]
    public async Task<ActionResult<VenueEntity>> CreateVenue(VenueEntity venue, CancellationToken cancellationToken)
    {
        _dbContext.Venues.Add(venue);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetVenue), new { id = venue.Id }, venue);
    }

    // GET: api/venues/{id}
    [HttpGet("venues/{id}")]
    public async Task<ActionResult<VenueEntity>> GetVenue(Guid id, CancellationToken cancellationToken)
    {
        var venue = await _dbContext.Venues.FindAsync([id], cancellationToken);

        if (venue == null)
        {
            return NotFound();
        }

        return Ok(venue);
    }

    // PUT: api/venues/{id}
    [HttpPut("venues/{id}")]
    public async Task<ActionResult<VenueEntity>> UpdateVenue(Guid id, VenueEntity venue, CancellationToken cancellationToken)
    {
        var existingVenue = await _dbContext.Venues.FindAsync([id], cancellationToken);

        if (existingVenue == null)
        {
            return NotFound();
        }

        existingVenue.Name = venue.Name;
        existingVenue.Website = venue.Website;
        existingVenue.VenueTypeId = venue.VenueTypeId;
        existingVenue.LocationId = venue.LocationId;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(existingVenue);
    }

    //DELETE: api/venues/{id}
    [HttpDelete("venues/{id}")]
    public async Task<ActionResult<VenueEntity>> DeleteVenue(Guid id, CancellationToken cancellationToken)
    {
        var venue = await _dbContext.Venues.FindAsync([id], cancellationToken);

        if (venue == null)
        {
            return NotFound();
        }

        _dbContext.Venues.Remove(venue);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    #endregion


    #region Venue Types

    // GET: api/venue-types
    [HttpGet("venue-types")]
    public async Task<ActionResult<IEnumerable<VenueTypeEntity>>> GetVenueTypes(CancellationToken cancellationToken)
    {
        var venueTypes = await _dbContext.VenueTypes.ToListAsync(cancellationToken);
        return Ok(venueTypes);
    }

    // POST: api/venue-types
    [HttpPost("venue-types")]
    public async Task<ActionResult<VenueTypeEntity>> CreateVenueType(VenueTypeEntity venueType, CancellationToken cancellationToken)
    {
        _dbContext.VenueTypes.Add(venueType);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetVenueType), new { id = venueType.Id }, venueType);
    }

    // GET: api/venue-types/{id}
    [HttpGet("venue-types/{id}")]
    public async Task<ActionResult<VenueTypeEntity>> GetVenueType(Guid id, CancellationToken cancellationToken)
    {
        var venueType = await _dbContext.VenueTypes.FindAsync([id], cancellationToken);

        if (venueType == null)
        {
            return NotFound();
        }

        return Ok(venueType);
    }

    // PUT: api/venue-types/{id}
    [HttpPut("venue-types/{id}")]
    public async Task<ActionResult<VenueTypeEntity>> UpdateVenueType(Guid id, VenueTypeEntity venueType, CancellationToken cancellationToken)
    {
        var existingVenueType = await _dbContext.VenueTypes.FindAsync([id], cancellationToken);

        if (existingVenueType == null)
        {
            return NotFound();
        }

        existingVenueType.Name = venueType.Name;
        existingVenueType.VenueCategoryId = venueType.VenueCategoryId;
        existingVenueType.LocationId = venueType.LocationId;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(existingVenueType);
    }

    //DELETE: api/venue-types/{id}
    [HttpDelete("venue-types/{id}")]
    public async Task<ActionResult<VenueTypeEntity>> DeleteVenueType(Guid id, CancellationToken cancellationToken)
    {
        var venueType = await _dbContext.VenueTypes.FindAsync([id], cancellationToken);

        if (venueType == null)
        {
            return NotFound();
        }

        _dbContext.VenueTypes.Remove(venueType);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    #endregion


    #region Venue Categories

    // GET: api/venue-categories
    [HttpGet("venue-categories")]
    public async Task<ActionResult<IEnumerable<VenueCategoryEntity>>> GetVenueCategories(CancellationToken cancellationToken)
    {
        var venueCategories = await _dbContext.VenueCategories.ToListAsync(cancellationToken);
        return Ok(venueCategories);
    }

    // POST: api/venue-categories
    [HttpPost("venue-categories")]
    public async Task<ActionResult<VenueCategoryEntity>> CreateVenueCategory(VenueCategoryEntity venueCategory, CancellationToken cancellationToken)
    {
        _dbContext.VenueCategories.Add(venueCategory);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetVenueCategory), new { id = venueCategory.Id }, venueCategory);
    }

    // GET: api/venue-categories/{id}
    [HttpGet("venue-categories/{id}")]
    public async Task<ActionResult<VenueCategoryEntity>> GetVenueCategory(Guid id, CancellationToken cancellationToken)
    {
        var venueCategory = await _dbContext.VenueCategories.FindAsync([id], cancellationToken);

        if (venueCategory == null)
        {
            return NotFound();
        }

        return Ok(venueCategory);
    }

    // PUT: api/venue-categories/{id}
    [HttpPut("venue-categories/{id}")]
    public async Task<ActionResult<VenueCategoryEntity>> UpdateVenueCategory(Guid id, VenueCategoryEntity venueCategory, CancellationToken cancellationToken)
    {
        var existingVenueCategory = await _dbContext.VenueCategories.FindAsync([id], cancellationToken);

        if (existingVenueCategory == null)
        {
            return NotFound();
        }

        existingVenueCategory.Name = venueCategory.Name;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(existingVenueCategory);
    }

    //DELETE: api/venue-categories/{id}
    [HttpDelete("venue-categories/{id}")]
    public async Task<ActionResult<VenueCategoryEntity>> DeleteVenueCategory(Guid id, CancellationToken cancellationToken)
    {
        var venueCategory = await _dbContext.VenueCategories.FindAsync([id], cancellationToken);

        if (venueCategory == null)
        {
            return NotFound();
        }

        _dbContext.VenueCategories.Remove(venueCategory);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

    #endregion
}