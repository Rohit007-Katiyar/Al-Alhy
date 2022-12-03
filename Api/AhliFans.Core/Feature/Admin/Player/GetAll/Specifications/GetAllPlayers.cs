using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Player.GetAll.Specifications;

public sealed class GetAllPlayers : Specification<Entities.Player>
{
  public GetAllPlayers(int pageIndex, int pageSize, string playerName, bool isDeleted)
  {
     if (pageIndex==0 && pageSize==0)
    {
      Query
        .Where(x => x.IsDeleted == isDeleted)
        .OrderByDescending(x => x.Date);
    }
    else if (true)
    {
      Query
        .Where(x => x.IsDeleted == isDeleted)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x => x.Date);
    }

    if (!string.IsNullOrEmpty(playerName))
    {
      Query
        .Where(x => x.Name!.Contains(playerName) || x.NameAr!.Contains(playerName));
    }
  }
}
