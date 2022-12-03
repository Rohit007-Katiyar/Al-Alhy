using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Player.Position.GeneralPosition;

public record GetAllGeneralPositionRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Player/Position/General";
  public string Lang { get; set; } = Languages.Ar;
}
