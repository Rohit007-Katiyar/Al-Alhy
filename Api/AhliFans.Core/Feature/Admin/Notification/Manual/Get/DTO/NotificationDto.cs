namespace AhliFans.Core.Feature.Admin.Notification.Manual.Get.DTO;

public record NotificationDto(string Header, string Body, string? Link, DateTime SendTime);
