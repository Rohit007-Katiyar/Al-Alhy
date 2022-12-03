using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.MatchCenter.MatchStatistics;

public record GetMatchStatisticByIdRequest()
{
  [FromRoute(Name = "Id")] public int Id { get; set; }

  [FromQuery(Name = "Lang")] public string? Lang { get; set; }
  public const string Route = $"{nameof(Areas.Admin)}/MatchCenter/MatchStatistics/{{Id}}";
};