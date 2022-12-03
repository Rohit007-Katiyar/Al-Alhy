using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Trophy;

public record ChangeTrophyStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Trophy/Status";
  [FromHeader] public int TrophyId { get; set; }
}
