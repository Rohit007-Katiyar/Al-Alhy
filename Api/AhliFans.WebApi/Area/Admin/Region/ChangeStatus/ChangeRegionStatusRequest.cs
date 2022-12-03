using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Region.ChangeStatus;

public record ChangeRegionStatusRequest(int RegionId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Region";
}
