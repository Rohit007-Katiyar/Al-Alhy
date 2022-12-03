using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Player.Image.Update.Events;

public record UpdateImageEvent(int PlayerId,IFormFile PlayerImage):IRequest<ActionResult>;
