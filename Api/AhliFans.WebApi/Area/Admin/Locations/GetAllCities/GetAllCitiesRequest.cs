using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Locations;

public record GetAllCitiesRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Cities";
  public string Lang { get; set; } = Languages.Ar;
  public string? Name { get; set; } 
  public int CountryId { get; set; }
}
