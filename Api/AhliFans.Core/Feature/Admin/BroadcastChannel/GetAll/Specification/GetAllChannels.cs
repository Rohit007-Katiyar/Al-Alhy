using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.BroadcastChannel.GetAll.Specification;

public sealed class GetAllChannels : Specification<Entities.BroadcastChannel>
{
  public GetAllChannels(int pageIndex,int pageSize)
  {
    Query
      .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Date);
  }
}
