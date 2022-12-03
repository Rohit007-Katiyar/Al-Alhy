using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Match;

public record GetAllVideoRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Match/Media/Videos";
  [FromHeader]public int MatchId { get; set; }
}
