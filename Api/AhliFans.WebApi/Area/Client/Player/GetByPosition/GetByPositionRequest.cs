using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Player;

public record GetByPositionRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Players/Positions/General";
  public int? TeamId { get; set; }
  public int GeneralPosition { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
