using AhliFans.Core.Feature.Enums;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Match;

public record MatchCenterDto(int Id,string LeagueName,string OpponentTeam, int OpponentTeamId, int? OpponentTeamScore, int? AhliScore,
  string Stadium, bool IsAway, string PlannedTime, string RefereeName,string PlannedDate, MatchTypes Type);
