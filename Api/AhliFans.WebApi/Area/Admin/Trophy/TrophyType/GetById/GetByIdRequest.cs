using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Trophy.TrophyType;

public record GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Trophy/Type";
  [FromHeader] public int TrophyTypeId { get; set; }
}
