namespace AhliFans.Core.Feature.Fan.Notification;

public record FanNotificationDto(int Id,string Header, string Body, string? Link, DateTime SendTime,bool Read,string ImageUrl);
