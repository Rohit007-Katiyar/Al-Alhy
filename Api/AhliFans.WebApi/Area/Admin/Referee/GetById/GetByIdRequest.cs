using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Referee;

public record GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Referee";
  [FromHeader] public int RefereeId { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
