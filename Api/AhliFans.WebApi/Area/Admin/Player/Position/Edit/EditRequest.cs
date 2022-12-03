using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Player.Position;

public record EditRequest(int PositionId,int? GeneralPositionId, string? Name, string? NameAr, string? Symbol)
{
  public const string Route = $"{nameof(Areas.Admin)}/Player/Position";
}
