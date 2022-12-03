using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Moment.GetAll.Specification;

public sealed class GetAllMoments : Specification<Entities.Moment>
{
  public GetAllMoments(int pageIndex,int pageSize,bool isAvailable)
  {
    Query
      .Include(x=>x.Player)
      .Include(x=>x.Match)
      .ThenInclude(y=>y.OpponentTeam)
      .Where(x=>x.IsAvailable == isAvailable)
      .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.MomentTime);
  }
}
