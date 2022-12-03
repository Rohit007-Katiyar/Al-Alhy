using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.LineUp.Substitution.GetByMatch;

public record GetByMatchRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Substitution";
  [FromHeader]public int MatchId { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
