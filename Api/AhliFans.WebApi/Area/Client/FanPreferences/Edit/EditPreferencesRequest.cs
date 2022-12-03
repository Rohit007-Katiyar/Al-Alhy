using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.FanPreferences;

public record EditPreferencesRequest(int? PlayerId, int? LocalTrophyId, string? FavoritePlayerAllTime, string? FavoriteCoachAllTime, int? AfricanTrophyId, int? MatchId, string? FavoriteMoment)
{
  public const string Route = $"{nameof(Areas.Client)}/Preferences";
}
