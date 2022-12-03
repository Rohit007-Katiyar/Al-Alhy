using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.ManageUsers.Fan.GetImage.Events;

public record GetFanImageEvent(Guid FanId) : IRequest<ActionResult>;
