using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Position.GetGeneralPosition.Events;

public record GetAllGeneralPositionsEvent(string Lang):IRequest<ActionResult>;
