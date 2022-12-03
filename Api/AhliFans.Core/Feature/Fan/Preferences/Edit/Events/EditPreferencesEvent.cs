using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Preferences.Edit.Events;

public record EditPreferencesEvent(int? PlayerId, int? LocalTrophyId, string? FavoritePlayerAllTime, string? FavoriteCoachAllTime, int? AfricanTrophyId, int? MatchId, string? FavoriteMoment) :IRequest<ActionResult>;
