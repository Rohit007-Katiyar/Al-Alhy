using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Client.MatchCenter;

public record GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Client)}/LineUp";
  [FromHeader]public int MatchId { get; set; }
  public bool IsSubstitution { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
