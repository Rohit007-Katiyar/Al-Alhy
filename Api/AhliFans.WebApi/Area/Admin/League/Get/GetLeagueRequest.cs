using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.League;

public record GetLeagueRequest(int? LeagueId, string? LeagueName)
{
  public const string Route = $"{nameof(Areas.Admin)}/Leageue";
  public string Lang { get; set; } = Languages.Ar;
  public bool IsDeleted { get; set; }
}
