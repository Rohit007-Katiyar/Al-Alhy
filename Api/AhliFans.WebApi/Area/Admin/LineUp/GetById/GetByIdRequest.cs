using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.LineUp;

public record GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/LineUp";
  [FromHeader]public int MatchId { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
