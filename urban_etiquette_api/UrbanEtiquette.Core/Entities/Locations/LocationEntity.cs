using UrbanEtiquette.Core.Common;
using UrbanEtiquette.Core.Entities.Tips;
using UrbanEtiquette.Core.Entities.Users;

namespace UrbanEtiquette.Core.Entities.Locations;

public class LocationEntity : BaseEntity
{
    public string Name { get; set; } = "";
    public string CountryCode { get; set; } = "";

    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    public List<TipEntity> Tips { get; set; } = [];
}