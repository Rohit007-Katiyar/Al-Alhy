using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.Match;

public record GetAllMatchVideoEvent(int MatchId) : IRequest<ActionResult>;
