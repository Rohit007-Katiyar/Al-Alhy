using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Player.Position;

public record GetPositionByIdRequest(int PositionId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Player/Position";
}
