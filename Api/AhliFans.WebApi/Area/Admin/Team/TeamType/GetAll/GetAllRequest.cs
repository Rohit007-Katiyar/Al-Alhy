using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Team.TeamType;

public record GetAllRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Team/Types";
  public string Lang { get; set; } = Languages.Ar;
  public bool IsDeleted { get; set; }
}
