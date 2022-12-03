using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.ChangeAvailability.Events;
public record ChangeMatchAvailabilityEvent(int MatchId) :IRequest<ActionResult>;
