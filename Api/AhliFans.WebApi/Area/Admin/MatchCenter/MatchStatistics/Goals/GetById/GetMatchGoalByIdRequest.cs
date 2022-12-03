using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics.Goals;

public record GetMatchGoalByIdRequest()
{
  [FromRoute] public int Id { get; set; }
  [FromQuery] public string? Lang { get; set; }
  public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/Goal/{{Id}}";
};