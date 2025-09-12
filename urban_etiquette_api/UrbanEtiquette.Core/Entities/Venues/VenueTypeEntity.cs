using UrbanEtiquette.Core.Common;
using UrbanEtiquette.Core.Entities.Locations;

namespace UrbanEtiquette.Core.Entities.Venues;

public class VenueTypeEntity : BaseEntity
{
    public string Name { get; set; } = "";

    #region Venue Category
    public Guid VenueCategoryId { get; set; }
    public VenueCategoryEntity VenueCategory { get; set; } = null!;
    #endregion

    #region Location
    public Guid? LocationId { get; set; }
    public LocationEntity? Location { get; set; }
    #endregion
}