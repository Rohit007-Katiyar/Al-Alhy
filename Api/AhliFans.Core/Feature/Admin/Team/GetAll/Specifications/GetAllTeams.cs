using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Team.GetAll.Specifications;

public sealed class GetAllTeams : Specification<Entities.Team>
{
  public GetAllTeams(int pageIndex, int pageSize, string? teamName,bool isDeleted)
  {
    if (true)
    {
      Query
        .Include(x=>x.Type)
        .Where(x=>x.IsDeleted == isDeleted)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize);
    }

    if (!string.IsNullOrEmpty(teamName))
    {
      Query
        .Where(x => x.NameAr.Contains(teamName) || x.Name.Contains(teamName));
    }
   
  }
}
