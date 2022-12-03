using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.League;

public record GetLeagueRequest(int? LeagueId, string? LeagueName)
{
  public const string Route = $"{nameof(Areas.Client)}/Leageue";
  public string Lang { get; set; } = Languages.Ar;
}
