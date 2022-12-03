using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups.Coefficients;

public record AddStatisticGroupCoefficientEvent(int StatisticTypeId, string Name, string NameAr, bool IsPercentage) : IRequest<ActionResult>;

