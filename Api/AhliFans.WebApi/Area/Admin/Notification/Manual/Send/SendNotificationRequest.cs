using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Notification.Manual;

public record SendNotificationRequest(string Header, string Body, IFormFile Icon, string? Link)
{
  public const string Route = $"{nameof(Areas.Admin)}/Notification/Send";
}
