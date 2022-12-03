using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Honor.ChangeStatus.Events;

public record ChangeCoachHonorStatusEvent(int HonorId) :IRequest<ActionResult>;
