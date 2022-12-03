using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.LineUp;

public record GetAllLineUpRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/LineUps";
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public DateTime? Date { get; set; }
  public string? OpponentTeam { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
