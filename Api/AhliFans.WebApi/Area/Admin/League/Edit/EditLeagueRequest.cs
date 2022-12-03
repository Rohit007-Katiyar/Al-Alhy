using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.League;

public record EditLeagueRequest(int LeagueId,string? Name, string? NameAr, List<int>? LeagueDateTimes)
{
  public const string Route = $"{nameof(Areas.Admin)}/Leageue";

}
