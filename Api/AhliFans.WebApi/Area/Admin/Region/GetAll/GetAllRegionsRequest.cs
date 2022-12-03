#nullable disable
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Region;

public record GetAllRegionsRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Regions";
  public string Name { get; set; }
  public string Lang { get; set; } = Languages.Ar;
  public bool IsDeleted { get; set; }
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
}
