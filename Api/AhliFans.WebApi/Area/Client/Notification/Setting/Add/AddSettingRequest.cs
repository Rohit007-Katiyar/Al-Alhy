using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Notification.Setting.Add;

public record AddSettingRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Notifications/Setting";
  public Guid FanId { get; set; }
  public bool? EnableAll { get; set; } = true;
  public bool? PlaySounds { get; set; } = true;
  public bool? News { get; set; }
  public bool? MatchStatus { get; set; }
  public bool? NightMode { get; set; }
  public string? From { get; set; }
  public string? To { get; set; }
}
