using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Coach;

public record ChangeCoachStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Status";
  [FromHeader]public int CoachId { get; set; }
}
