using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.Core.Feature.Admin.MatchCenter.MatchStatistics.Groups;

public record EditStatisticGroupEvent(int Id, string Name, string NameAr, bool IsEnabled) : IRequest<ActionResult>;
