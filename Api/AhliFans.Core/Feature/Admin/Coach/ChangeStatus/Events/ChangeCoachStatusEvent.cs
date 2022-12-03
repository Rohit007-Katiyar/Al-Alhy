using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.ChangeStatus.Events;

public record ChangeCoachStatusEvent(int CoachId) :IRequest<ActionResult>;
