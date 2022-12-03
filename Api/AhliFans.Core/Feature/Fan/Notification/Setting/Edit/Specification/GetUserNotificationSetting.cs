using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Notification.Setting.Edit.Specification;

public sealed class GetUserNotificationSetting : Specification<NotificationSetting>, ISingleResultSpecification
{
  public GetUserNotificationSetting(Guid fanId)
  {
    Query
      .Where(x => x.FanId == fanId);
  }
}
