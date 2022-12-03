using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Preferences;

public record GetPreferenceRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Preferences";
  public string Lang { get; set; } = Languages.Ar;
  [FromHeader] public Guid FanId { get; set; }
}
