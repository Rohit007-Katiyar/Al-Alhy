using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.Profile.Image.Update.Events;
public record UpdateImageEvent(IFormFile ProfileImage) : IRequest<ActionResult>;
