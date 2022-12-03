using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public record GetStatisticGroupCoefficientByIdEvent(int StatisticGroupCoefficientId) : IRequest<ActionResult>;
