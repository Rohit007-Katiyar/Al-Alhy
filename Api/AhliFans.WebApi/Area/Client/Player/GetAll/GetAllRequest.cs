using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Player;

public record GetAllRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Players";

  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public string? PlayerName { get; set; }
  public string Lang { get; set; } = Languages.Ar;
  public bool IsDeleted { get; set; }
}
