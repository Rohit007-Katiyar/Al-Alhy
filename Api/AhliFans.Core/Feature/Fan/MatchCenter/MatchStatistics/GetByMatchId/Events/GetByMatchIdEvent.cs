using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics;

public record GetByMatchIdEvent(int MatchId, string Language = Languages.Ar) : IRequest<ActionResult>;