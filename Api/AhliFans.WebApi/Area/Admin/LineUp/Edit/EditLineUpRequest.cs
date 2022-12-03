using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.LineUp;

public record EditLineUpRequest(int MatchId, List<int> PlayersList, List<int> PositionList, List<bool> IsSubstitute)
{
  public const string Route = $"{nameof(Areas.Admin)}/LineUp";
}
