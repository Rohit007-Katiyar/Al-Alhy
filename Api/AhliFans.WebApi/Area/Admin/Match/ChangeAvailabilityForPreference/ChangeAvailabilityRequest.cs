using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Match;

public record ChangeAvailabilityRequest(int MatchId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Match/Availability";

}
