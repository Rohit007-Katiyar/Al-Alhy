using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.LineUp;

public record AddLineUpRequest(List<int> PlayersList, List<int> PositionList, int MatchId, List<bool> IsSubstitute)
{
  public const string Route = $"{nameof(Areas.Admin)}/LineUp";
}
