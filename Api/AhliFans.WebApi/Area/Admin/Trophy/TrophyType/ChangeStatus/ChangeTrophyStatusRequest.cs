using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Trophy.TrophyType;

public record ChangeTrophyStatusRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Trophy/Type/Status";
  [FromHeader] public int TypeId { get; set; }
}
