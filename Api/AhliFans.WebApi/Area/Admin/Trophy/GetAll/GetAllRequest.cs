#nullable disable
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using JetBrains.Annotations;

namespace AhliFans.WebApi.Area.Admin.Trophy;

public record GetAllRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Trophies";
  public int? TrophyTypeId { get; set; }
  [CanBeNull] public string Name { get; set; }
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public bool IsDeleted { get; set; }
  public bool? IsAvailable { get; set; }
  public string Lang { get; set; } = Languages.Ar;

}
