using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Notification.Manual.Get.Specifications;

public sealed class GetAllNotification : Specification<Entities.Notification>
{
  public GetAllNotification(int pageIndex, int pageSize)
  {
    Query
      .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.SendTime);
  }
}
