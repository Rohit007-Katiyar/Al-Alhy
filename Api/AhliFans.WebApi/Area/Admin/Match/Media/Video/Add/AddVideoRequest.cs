using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Match;

public record AddVideoRequest(List<string> Videos, int MatchId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Match/Media/Videos";
}
