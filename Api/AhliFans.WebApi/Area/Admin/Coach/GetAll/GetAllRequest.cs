#nullable disable
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using JetBrains.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach;

public record GetAllRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Coachs";
  [CanBeNull] public string SearchWord { get; set; }
  public string Lang { get; set; } = Languages.Ar;
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public bool IsDeleted { get; set; }
}
