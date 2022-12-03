using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Season;

public record GetAllRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Seasons";
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public string? Name { get; set; }
  public DateTime? StartDate { get; set; }
  public DateTime? EndDate { get; set; }
  public string Lang { get; set; } = Languages.Ar;
  public bool IsDeleted { get; set; }
}
