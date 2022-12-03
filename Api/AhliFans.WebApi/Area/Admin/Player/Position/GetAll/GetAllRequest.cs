#nullable disable
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Player.Position;

public record GetAllRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Player/Positions";
  public string Lang { get; set; } = Languages.Ar;
  public string Name { get; set; }
  public bool IsDeleted { get; set; }
}
