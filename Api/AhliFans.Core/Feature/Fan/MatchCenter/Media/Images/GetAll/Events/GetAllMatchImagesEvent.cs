using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter;

public record GetAllMatchImagesEvent(int MatchId,string ImageUrl) : IRequest<ActionResult>;
