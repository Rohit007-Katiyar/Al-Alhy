using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Locations.GetAllCountries;

public record GetAllRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Countries";
  public string? Name { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
