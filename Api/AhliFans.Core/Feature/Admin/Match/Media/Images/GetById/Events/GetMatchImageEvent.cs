using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.Media.Images.GetById.Events;

public record GetMatchImageEvent(int ImageId):IRequest<ActionResult>;
