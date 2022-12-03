using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Preferences.Add.Events;

public record AddPreferencesEvent(int? PlayerId, int? LocalTrophyId, string? FavoritePlayerAllTime, string? FavoriteCoachAllTime, int? AfricanTrophyId, int? MatchId, string? FavoriteMoment, Guid? UserId = null) :IRequest<ActionResult>;
