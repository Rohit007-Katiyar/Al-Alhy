using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Notification.Manual.Send.Specification;

public sealed class FilterUserNotificationSetting : Specification<NotificationSetting>
{
  public FilterUserNotificationSetting()
  {
    Query
      .Include(x=>x.Fan)
      .Where(x=>x.EnableAll == true || (x.NightMode == true && DateTime.Now.Hour <= Convert.ToInt32(x.To) && DateTime.Now.Hour >= Convert.ToInt32(x.From))); 
  }
}
