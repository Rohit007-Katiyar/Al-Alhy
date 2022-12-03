using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public record GetGoalsByMatchIdEvent(int MatchId, string Language = Languages.Ar) : IRequest<ActionResult>;