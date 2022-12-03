using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public record EditMatchGoalEvent(int Id, int? PlayerId, int Minute, bool IsForAhly) : IRequest<ActionResult>;