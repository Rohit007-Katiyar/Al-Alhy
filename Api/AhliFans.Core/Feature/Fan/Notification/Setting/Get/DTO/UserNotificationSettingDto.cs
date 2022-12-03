namespace AhliFans.Core.Feature.Fan.Notification.Setting.Get.DTO;

public record UserNotificationSettingDto(bool? EnableAll, bool? PlaySounds, bool? News, bool? MatchStatus, bool? NightMode, string? From, string? To);
