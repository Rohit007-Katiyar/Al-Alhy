using AhliFans.Core.Feature.Localization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public record GetMatchGoalByIdEvent(int GoalId, string Language = Languages.Ar) : IRequest<ActionResult>;