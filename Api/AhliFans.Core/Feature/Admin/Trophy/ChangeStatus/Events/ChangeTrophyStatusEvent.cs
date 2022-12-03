using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.ChangeStatus.Events;

public record ChangeTrophyStatusEvent(int TrophyId) :IRequest<ActionResult>;
