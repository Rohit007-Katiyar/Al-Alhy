using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.League.Get.Specifications;

public sealed class GetAllLeagues : Specification<Entities.League>
{
  public GetAllLeagues(int? leagueId,string leagueName,bool isDeleted)
  {
    if (true)
    {
      Query
        .Include(x => x.Dates.Where(d => !d.IsDeleted))
        .Where(x => x.IsDeleted == isDeleted);
    }

    if (leagueId is not null && leagueId != 0)
    {
      Query
        .Where(x=>x.Id == leagueId);
    }

    if (!string.IsNullOrEmpty(leagueName))
    {
      Query
        .Where(x => x.Name.Contains(leagueName)|| x.Name.Contains(leagueName));
    }
  }
}
