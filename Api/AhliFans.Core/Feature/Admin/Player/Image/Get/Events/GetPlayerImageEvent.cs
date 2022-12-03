using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Image.Get.Events;
public record GetPlayerImageEvent(int PlayerId):IRequest<ActionResult>;
