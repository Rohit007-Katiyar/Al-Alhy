using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Team;

public record AddTeamRequest(int TypeId, int RegionId, string Name, string NameAr, IFormFile? Logo)
{
  public const string Route = $"{nameof(Areas.Admin)}/Team";
}
