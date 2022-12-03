using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match.Media.Images.Add.Events;

public record AddMatchMediaImageEvent(List<IFormFile> Images,int MatchId):IRequest<ActionResult>;
