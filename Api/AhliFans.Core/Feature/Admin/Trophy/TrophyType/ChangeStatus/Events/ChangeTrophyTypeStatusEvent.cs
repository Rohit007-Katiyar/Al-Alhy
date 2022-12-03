using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.TrophyType.ChangeStatus.Events;

public record ChangeTrophyTypeStatusEvent(int TypeId) :IRequest<ActionResult>;
