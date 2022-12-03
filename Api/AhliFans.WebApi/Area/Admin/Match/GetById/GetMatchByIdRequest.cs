using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Match;

public record GetMatchByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Matche";
  [FromHeader] public int MatchId { get; set; }
  public string Lang { get; set; } = Languages.Ar;

}
