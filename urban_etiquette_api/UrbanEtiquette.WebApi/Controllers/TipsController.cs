using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrbanEtiquette.Application.Common.Interfaces;
using UrbanEtiquette.Core.Entities.Tips;

namespace UrbanEtiquette.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TipsController : ControllerBase
{
    private readonly IApplicationDbContext _dbContext;

    public TipsController(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET: api/tips
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TipEntity>>> GetTips(CancellationToken cancellationToken)
    {
        var tips = await _dbContext.Tips.ToListAsync(cancellationToken);
        return Ok(tips);
    }

    // POST: api/tips
    [HttpPost]
    public async Task<ActionResult<TipEntity>> CreateTip(TipEntity tip, CancellationToken cancellationToken)
    {
        _dbContext.Tips.Add(tip);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetTip), new { id = tip.Id }, tip);
    }

    // GET: api/tips/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<TipEntity>> GetTip(Guid id, CancellationToken cancellationToken)
    {
        var tip = await _dbContext.Tips.FindAsync([id], cancellationToken);

        if (tip == null)
        {
            return NotFound();
        }

        return Ok(tip);
    }

    // PUT: api/tips/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<TipEntity>> UpdateTip(Guid id, TipEntity tip, CancellationToken cancellationToken)
    {
        var existingTip = await _dbContext.Tips.FindAsync([id], cancellationToken);

        if (existingTip == null)
        {
            return NotFound();
        }

        existingTip.Title = tip.Title;
        existingTip.Description = tip.Description;
        existingTip.RatingCount = tip.RatingCount;
        existingTip.IsStaff = tip.IsStaff;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(existingTip);
    }

    //DELETE: api/tips/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult<TipEntity>> DeleteTip(Guid id, CancellationToken cancellationToken)
    {
        var tip = await _dbContext.Tips.FindAsync([id], cancellationToken);

        if (tip == null)
        {
            return NotFound();
        }

        _dbContext.Tips.Remove(tip);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }

}