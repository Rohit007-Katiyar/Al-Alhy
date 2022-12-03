using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.LineUp.GetAll.Specifications;

public sealed class GetAllLineUps : Specification<MatchLineUp>
{
  public GetAllLineUps(int pageIndex,int pageSize,DateTime? date,string? opponentTeam)
  {
    if (true)
    {
      Query
        .Include(x=>x.Match)
        .ThenInclude(y=>y.OpponentTeam)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Date);
    }

    if (date != null)
    {
      Query
        .Where(x => x.Date >= date);
    }

    if (!string.IsNullOrEmpty(opponentTeam))
    {
      Query
        .Where(x => x.Match.OpponentTeam.Name.Contains(opponentTeam) || x.Match.OpponentTeam.NameAr.Contains(opponentTeam));
    }
  
  }
}
