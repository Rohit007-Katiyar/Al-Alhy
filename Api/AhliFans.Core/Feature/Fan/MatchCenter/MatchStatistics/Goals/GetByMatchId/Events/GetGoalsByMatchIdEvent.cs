using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Fan.MatchCenter.MatchStatistics;

public record GetGoalsByMatchIdEvent(int MatchId, string Language = Languages.Ar) : IRequest<ActionResult>;