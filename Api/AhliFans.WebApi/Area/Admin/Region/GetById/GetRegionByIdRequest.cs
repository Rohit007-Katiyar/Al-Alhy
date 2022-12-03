using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Region.GetById;

public record GetRegionByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Region";
  public int RegionId { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
