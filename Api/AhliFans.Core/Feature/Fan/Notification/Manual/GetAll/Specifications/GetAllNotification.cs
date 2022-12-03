using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Notification;

public sealed class GetAllNotification : Specification<Entities.FanNotification>
{
  public GetAllNotification(int pageIndex, int pageSize,Guid fanId)
  {
    Query
      .Include(x=>x.Notification)
      .Where(x=>x.FanId == fanId)
      .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Data);
  }
}
