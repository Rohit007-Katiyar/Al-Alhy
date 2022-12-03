using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.League;

public record GetDatesRequest(int LeagueId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Leageue/Dates";
}
