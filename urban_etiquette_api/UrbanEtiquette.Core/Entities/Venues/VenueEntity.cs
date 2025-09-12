
using UrbanEtiquette.Core.Common;
using UrbanEtiquette.Core.Entities.Locations;

namespace UrbanEtiquette.Core.Entities.Venues;

public class VenueEntity : BaseEntity
{
    public string Name { get; set; } = "";
    public string Website { get; set; } = "";

    #region Venue Type
    public Guid VenueTypeId { get; set; }
    public VenueTypeEntity VenueType { get; set; } = null!;
    #endregion

    #region Location
    public Guid? LocationId { get; set; }
    public LocationEntity? Location { get; set; } = null!;
    #endregion


}