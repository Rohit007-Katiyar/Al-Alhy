using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Trophy;

public record GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Trophy";
  [FromHeader] public int TrophyId { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
