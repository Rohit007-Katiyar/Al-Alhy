namespace AhliFans.Core.Feature.Admin.League.Get.DTO;

public record LeaguesDto(int LeagueId,bool IsDeleted, string NameByLang,string Name,string NameAr,IEnumerable<LeagueDate> LeagueDates);
public record LeagueDate(int DateId,int Date);
