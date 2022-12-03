using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Trophy;

public record ChangeAvailabilityRequest(int MatchId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Trophy/Availability";

}
