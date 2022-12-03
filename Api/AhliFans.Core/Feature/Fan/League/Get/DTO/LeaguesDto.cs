namespace AhliFans.Core.Feature.Fan.League.Get.DTO;

public record LeaguesDto(int LeagueId,string Name,IEnumerable<LeagueDate> LeagueDates);
public record LeagueDate(int DateId,int Date);
