using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter;

public record GetMatchImageEvent(int ImageId):IRequest<ActionResult>;
