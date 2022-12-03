using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetById.Events;

public record GetFanByIdEvent(Guid FanId):IRequest<ActionResult>;
