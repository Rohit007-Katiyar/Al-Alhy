using AhliFans.Core.Feature.Security.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Groups;

public record EditStatisticGroupRequest(int Id, string Name, string NameAr, bool IsEnabled) : IRequest<ActionResult>
{
  public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Groups";
};
