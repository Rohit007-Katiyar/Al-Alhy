using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Player.GetAll.Specifications;

public sealed class GetAllPlayers : Specification<Entities.Player>
{
  public GetAllPlayers(int pageIndex, int pageSize, string playerName,bool isDeleted)
  {
    if (true)
    {
      Query
        .Where(x=>x.IsDeleted == isDeleted)
        .Skip(((pageIndex - 1) * pageSize)).Take(pageSize).OrderByDescending(x=>x.Date);
    }

    if (!string.IsNullOrEmpty(playerName))
    {
      Query
        .Where(x => x.Name!.Contains(playerName) || x.NameAr!.Contains(playerName));
    }
  }
}
