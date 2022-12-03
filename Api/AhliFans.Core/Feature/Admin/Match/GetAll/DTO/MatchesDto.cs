namespace AhliFans.Core.Feature.Admin.Match.GetAll.DTO;

public record MatchesDto(int Id, bool IsDeleted, bool IsAvailable, DateTime? PlannedDate, string OpponentTeam, int? OpponentTeamScore, int? AhliScore, string Stadium, 
   bool IsAway, string Time, string RefereeName);
