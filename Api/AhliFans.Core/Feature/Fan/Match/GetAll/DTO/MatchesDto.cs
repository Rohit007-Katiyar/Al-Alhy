namespace AhliFans.Core.Feature.Fan.Match.GetAll.DTO;

public record MatchesDto(int Id,string LeagueName,string OpponentTeam,int OpponentTeamId, int? OpponentTeamScore, int? AhliScore,
  string Stadium, bool IsAway, string PlannedTime, string RefereeName,string PlannedDate);
