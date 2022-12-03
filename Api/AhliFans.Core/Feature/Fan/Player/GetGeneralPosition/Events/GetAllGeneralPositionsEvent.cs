using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Player.GetGeneralPosition.Events;

public record GetAllGeneralPositionsEvent(string Lang):IRequest<ActionResult>;
