using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Position.ChangeStatus.Events;
public record ChangePositionStatusEvent(int PositionId) :IRequest<ActionResult>;
