using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Player.Position.GetAll.Specifications;

public sealed class GetAllPositions : Specification<Entities.Position>
{
  public GetAllPositions(string name,bool isDeleted)
  {
    if (true)
    {
      Query
        .Include(x=>x.GeneralPosition)
        .OrderBy(x=>x.Date)
        .Where(x=>x.IsDeleted == isDeleted);
    }

    if (!string.IsNullOrEmpty(name))
    {
      Query
        .Where(x => x.Name.Contains(name) || x.NameAr.Contains(name) || x.Symbol!.Contains(name));
    }
  }
}
