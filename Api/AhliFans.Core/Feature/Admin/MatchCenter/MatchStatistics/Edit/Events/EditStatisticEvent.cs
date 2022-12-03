using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics;

public record EditStatisticEvent(int Id, int Value, int MatchId, int StatisticsTypeId, int StatisticsCoefficientId) : IRequest<ActionResult>;
