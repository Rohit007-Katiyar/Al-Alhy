using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public record GetStatisticGroupByIdEvent(int StatisticGroupId) : IRequest<ActionResult>;
