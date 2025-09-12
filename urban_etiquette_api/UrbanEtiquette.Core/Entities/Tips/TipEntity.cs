using UrbanEtiquette.Core.Common;
using UrbanEtiquette.Core.Entities.Locations;
using UrbanEtiquette.Core.Entities.Users;
using UrbanEtiquette.Core.Entities.Venues;

namespace UrbanEtiquette.Core.Entities.Tips;

public class TipEntity : BaseEntity
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public int RatingCount { get; set; }
    public bool IsStaff { get; set; }

    #region User
    public Guid UserId { get; set; } //FK
    public UserEntity User { get; set; } = null!;
    #endregion

    #region Location
    public Guid? LocationId { get; set; } //FK
    public LocationEntity? Location {get; set; } = null;
    #endregion

    #region Venue
    public Guid VenueTypeId { get; set; } //FK
    public VenueTypeEntity VenueType { get; set; } = null!;
    #endregion
}