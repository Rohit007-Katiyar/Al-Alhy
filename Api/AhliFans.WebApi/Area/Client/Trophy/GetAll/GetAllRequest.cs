#nullable disable
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using JetBrains.Annotations;

namespace AhliFans.WebApi.Area.Client.Trophy;

public record GetAllRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Trophies";
  public int? TrophyTypeId { get; set; }
  [CanBeNull] public string Name { get; set; }
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public string Lang { get; set; } = Languages.Ar;
}
