using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics;

public record AddMatchCardRequest(int MatchId, bool IsRed, bool IsForAhly, int? PlayerId, int Minute)
{
    public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Cards";
}