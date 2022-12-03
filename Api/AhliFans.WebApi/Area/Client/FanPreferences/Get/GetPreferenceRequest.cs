using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.FanPreferences;

public record GetPreferenceRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Preferences";
  public string Lang { get; set; } = Languages.Ar;
}
