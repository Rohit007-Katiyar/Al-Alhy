using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Notification.Manual.GetCount.Specification;

public sealed class GetFanNotificationCount : Specification<FanNotification>
{
  public GetFanNotificationCount(Guid fanId)
  {
    Query
      .Where(x => x.FanId == fanId && !x.Read);
  }
}
