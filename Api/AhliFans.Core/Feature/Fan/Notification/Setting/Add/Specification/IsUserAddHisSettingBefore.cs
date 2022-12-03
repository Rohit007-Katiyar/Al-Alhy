using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Notification.Setting.Add.Specification;

public sealed class IsUserAddHisSettingBefore : Specification<NotificationSetting>
{
  public IsUserAddHisSettingBefore(Guid fanId)
  {
    Query
      .Where(x => x.FanId == fanId);
  }
}
