using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Goals;

public record AddMatchGoalEvent(int MatchId, int? PlayerId, int Minute, bool IsForAhly) : IRequest<ActionResult>;