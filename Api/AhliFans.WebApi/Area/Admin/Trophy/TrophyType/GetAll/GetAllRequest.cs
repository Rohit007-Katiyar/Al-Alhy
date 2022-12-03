#nullable disable
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Trophy.TrophyType;

public record GetAllRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Trophy/Types";
  public string Name { get; set; }
  public string Lang { get; set; } = Languages.Ar; 
  public bool IsDeleted { get; set; }
}
