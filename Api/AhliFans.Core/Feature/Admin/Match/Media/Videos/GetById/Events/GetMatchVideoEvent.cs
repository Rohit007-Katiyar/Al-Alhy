using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match;

public record GetMatchVideoEvent(int VideoId):IRequest<ActionResult>;
