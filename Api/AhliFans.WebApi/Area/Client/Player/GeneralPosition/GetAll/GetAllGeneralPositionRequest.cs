using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Player;

public record GetAllGeneralPositionRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Player/Position/General";
  public string Lang { get; set; } = Languages.Ar;
}
