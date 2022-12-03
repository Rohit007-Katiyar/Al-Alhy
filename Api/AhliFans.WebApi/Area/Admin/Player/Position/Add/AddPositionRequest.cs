using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Player.Position;

public record AddPositionRequest(string Name,string NameAr,string? Symbol,int GeneralPositionId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Player/Position";
}
