using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public record EditStatisticGroupCoefficientEvent(int Id, int StatisticTypeId, string Name, string NameAr, bool IsPercentage) : IRequest<ActionResult>;
