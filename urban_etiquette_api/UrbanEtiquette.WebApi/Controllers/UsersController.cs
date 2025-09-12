using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrbanEtiquette.Application.Common.Interfaces;
using UrbanEtiquette.Core.Entities.Users;

namespace UrbanEtiquette.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IApplicationDbContext _dbContext;

    public UsersController(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserEntity>>> GetUsers(CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users.ToListAsync(cancellationToken);
        return Ok(users);
    }

    // POST: api/users
    [HttpPost]
    public async Task<ActionResult<UserEntity>> CreateUser(UserEntity user, CancellationToken cancellationToken)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // GET: api/users/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<UserEntity>> GetUser(Guid id, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FindAsync([id], cancellationToken);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    // PUT: api/users/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<UserEntity>> UpdateUser(Guid id, UserEntity user, CancellationToken cancellationToken)
    {
        var existingUser = await _dbContext.Users.FindAsync([id], cancellationToken);
        
        if (existingUser == null)
        {
            return NotFound();
        }

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.PhoneNumber = user.PhoneNumber;
        existingUser.LocationId = user.LocationId;
        existingUser.AboutMe = user.AboutMe;
        existingUser.RatingCount = user.RatingCount;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Ok(existingUser);
    }   

    //DELETE: api/users/{userId}
    [HttpDelete("{id}")]
    public async Task<ActionResult<UserEntity>> DeleteUser(Guid id, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FindAsync([id], cancellationToken);

        if (user == null)
        {
            return NotFound();
        }

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return NoContent();
    }
}