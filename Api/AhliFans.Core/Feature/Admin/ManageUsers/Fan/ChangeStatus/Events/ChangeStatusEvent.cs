using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.ManageUsers.Fan.ChangeStatus.Events;

public record ChangeStatusEvent(Guid FanId) : IRequest<ActionResult>;
