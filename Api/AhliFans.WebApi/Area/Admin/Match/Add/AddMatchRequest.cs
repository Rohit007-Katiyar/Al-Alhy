using AhliFans.Core.Feature.Enums;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Match;

public record AddMatchRequest(int SeasonId, int OpponentTeamId, int StadiumId, int RefereeId, int LeagueId, int LeagueDateId,
  bool IsAway, string Time, int? Score, int? OpponentScore,MatchTypes MatchType, int? JerseyId,
  string PlannedTime, DateTime PlannedDate, string? ActualTime, DateTime? ActualDate,int? BroadcastChannelId,MatchStatus? MatchStatus)
{
  public const string Route = $"{nameof(Areas.Admin)}/Match";
}
