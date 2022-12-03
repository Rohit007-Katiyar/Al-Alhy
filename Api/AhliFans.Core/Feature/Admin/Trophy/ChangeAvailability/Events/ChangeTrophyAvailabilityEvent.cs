using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.ChangeAvailability.Events;
public record ChangeTrophyAvailabilityEvent(int MatchId) :IRequest<ActionResult>;
