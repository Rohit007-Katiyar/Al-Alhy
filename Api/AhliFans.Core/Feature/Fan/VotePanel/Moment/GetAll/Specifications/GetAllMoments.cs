using AhliFans.Core.Feature.Enums;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.VotePanel.Moment.GetAll.Specifications;

public sealed class GetAllMoments : Specification<Entities.Moment>
{
  public GetAllMoments(int pageIndex,int pageSize,MomentVoteTypes type)
  {
    Query
      .Include(x=>x.Match)
      .ThenInclude(y=>y.OpponentTeam)
      .Include(x=>x.Player)
      .Where(x => x.IsAvailable && x.Type == type)
      .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(m =>m.MomentTime); 
  }
}
