using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Client.Notification.Manual.GetById;

public record GetNotificationByIdRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Notification";
  [FromHeader]public int NotificationId { get; set; }
}
