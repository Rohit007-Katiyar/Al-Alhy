using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Team;

public record EditTeamRequest(int TeamId, int? TypeId, int? RegionId, string? Name, string? NameAr)
{
  public const string Route = $"{nameof(Areas.Admin)}/Teams";
}
