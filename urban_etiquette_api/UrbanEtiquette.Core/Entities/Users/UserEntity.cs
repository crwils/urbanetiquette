using UrbanEtiquette.Core.Common;

namespace UrbanEtiquette.Core.Entities.Users;

public class UserEntity : BaseEntity
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string? PhoneNumber { get; set; }
    public string? AboutMe { get; set; }
    public int RatingCount { get; set; } = 0;

}  