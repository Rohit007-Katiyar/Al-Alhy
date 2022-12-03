using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Client.Coach;

public record GetByIdRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Coach";
  [FromHeader] public int Coach { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
