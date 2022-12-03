using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Player.GetImage.Events;
public record GetPlayerImageEvent(int PlayerId):IRequest<ActionResult>;
