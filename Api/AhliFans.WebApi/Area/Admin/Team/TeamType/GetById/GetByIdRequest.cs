using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Team.TeamType;

public record GetByIdRequest(int TeamTypeId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Team/Type";
}
