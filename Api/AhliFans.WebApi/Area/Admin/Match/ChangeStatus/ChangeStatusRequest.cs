using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Match;

public record ChangeStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Match/Status";
  [FromHeader] public int MatchId { get; set; }

}
