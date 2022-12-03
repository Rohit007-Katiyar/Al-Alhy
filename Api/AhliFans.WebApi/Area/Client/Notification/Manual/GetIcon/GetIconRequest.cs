using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Notification;

public record GetIconRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Notification/Icon/{{NotificationId}}";
  public int NotificationId { get; set; }
}
