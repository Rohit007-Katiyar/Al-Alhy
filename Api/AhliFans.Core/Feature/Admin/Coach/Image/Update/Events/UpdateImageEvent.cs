using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Coach.Image.Update.Events;

public record UpdateImageEvent(int CoachId, IFormFile CoachImage) :IRequest<ActionResult>;
