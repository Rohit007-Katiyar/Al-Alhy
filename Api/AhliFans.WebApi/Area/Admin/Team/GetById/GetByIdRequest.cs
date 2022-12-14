using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Team;

public record GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Team";
  [FromHeader]public int TeamId { get; set; }
  public string Lang { get; set; } = Languages.Ar;

}
