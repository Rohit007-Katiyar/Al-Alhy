using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Trophy.Image.Update.Events;

public record UpdateImageEvent(int TrophyId, IFormFile TrophyImage) :IRequest<ActionResult>;
