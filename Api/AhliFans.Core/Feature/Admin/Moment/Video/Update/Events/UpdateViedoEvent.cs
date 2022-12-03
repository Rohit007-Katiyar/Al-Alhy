using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Moment;

public record UpdateViedoEvent(int MomentId, IFormFile MomentVideo) :IRequest<ActionResult>;
