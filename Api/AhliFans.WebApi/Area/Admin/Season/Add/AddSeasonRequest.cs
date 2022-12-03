using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Season;

public record AddSeasonRequest(string Name, string NameAr, DateTime StartDate, DateTime EndDate)
{
  public const string Route = $"{nameof(Areas.Admin)}/Season";
}
