using AhliFans.Core.Feature.Enums;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Match;

public record EditMatchRequest(int MatchId,int? SeasonId, int? OpponentTeamId, int? StadiumId, int? RefereeId,
  bool? IsAway, DateTime? MatchDate, string? Time, int? Score, int? OpponentScore, int? LeagueId, int? LeagueDateId,
  MatchTypes? MatchType, int? JerseyId, string? PlannedTime, DateTime? PlannedDate, string? ActualTime, DateTime? ActualDate, 
  MatchStatus? MatchStatus,int? BroadcastChannelId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Match";
}
