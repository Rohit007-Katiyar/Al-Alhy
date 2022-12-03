using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Notification.Manual;

public record GetManualNotificationRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Notification";
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
}
