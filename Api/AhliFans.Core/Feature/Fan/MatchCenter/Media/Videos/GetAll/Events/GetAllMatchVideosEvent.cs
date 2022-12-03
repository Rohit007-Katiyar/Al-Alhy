using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter.Videos;

public record GetAllMatchVideosEvent(int MatchId) : IRequest<ActionResult>;
