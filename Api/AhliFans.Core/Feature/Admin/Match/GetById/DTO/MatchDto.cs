using AhliFans.Core.Feature.Enums;

namespace AhliFans.Core.Feature.Admin.Match.GetById.DTO;

public record MatchDto(int Id, string OpponentTeam, string OpponentTeamName, int? OpponentTeamScore, int? AhliScore, string Stadium, string StadiumName, bool IsAway, 
  string Time,string Referee, string RefereeName , string MatchType , DateTime? ActualDate , DateTime? PlannedDate, string? ActualTime , string PlannedTime,int? Jersey,
  int? SeasonId,int LeagueId , int? LeagueDateId,MatchStatus? MatchStatus,string ChannelName,int? ChannelId);
