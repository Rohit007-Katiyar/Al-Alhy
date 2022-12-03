using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Locations.GetAllCities;

public record GetAllCitiesRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Cities";
  public string Lang { get; set; } = Languages.Ar;
  public string? Name { get; set; } 
  public int CountryId { get; set; }
}
