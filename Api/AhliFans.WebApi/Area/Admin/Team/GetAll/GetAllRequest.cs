using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Team;

public record GetAllRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Teams";
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public string? TeamName { get; set; }
  public bool IsDeleted { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
