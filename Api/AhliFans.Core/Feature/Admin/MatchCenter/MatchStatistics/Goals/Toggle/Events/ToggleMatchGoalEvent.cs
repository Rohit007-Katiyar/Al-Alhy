using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public record ToggleMatchGoalEvent(int GoalId) : IRequest<ActionResult>;