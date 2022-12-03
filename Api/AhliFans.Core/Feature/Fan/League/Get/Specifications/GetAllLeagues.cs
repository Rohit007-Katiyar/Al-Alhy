using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.League.Get.Specifications;

public sealed class GetAllLeagues : Specification<Entities.League>
{
  public GetAllLeagues(int? leagueId,string leagueName)
  {
    if (true)
    {
      Query
        .Include(x => x.Dates);
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
