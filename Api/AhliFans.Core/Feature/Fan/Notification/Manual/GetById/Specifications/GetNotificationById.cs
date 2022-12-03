using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Notification.Manual.GetById.Specifications;

public sealed class GetNotificationById : Specification<FanNotification>, ISingleResultSpecification
{
  public GetNotificationById(int notificationId)
  {
    Query
      .Include(x=>x.Notification)
      .Where(x => x.NotificationId == notificationId);
  }
}
