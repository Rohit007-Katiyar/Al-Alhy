using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Position.GetById.Events;

public record GetPositionByIdEvent(int PositionId):IRequest<ActionResult>;
