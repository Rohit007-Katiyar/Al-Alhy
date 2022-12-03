using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Locations;

public record GetAllRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Countries";
  public string? Name { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
