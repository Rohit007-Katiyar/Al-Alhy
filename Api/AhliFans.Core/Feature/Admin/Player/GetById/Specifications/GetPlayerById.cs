using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Player.GetById.Specifications;
public sealed class GetPlayerById : Specification<Entities.Player>, ISingleResultSpecification
{
  public GetPlayerById(int playerId)
  {
    Query
      .Include(x=>x.Country)
      .Include(x=>x.CityOfBirth)
      .ThenInclude(y=>y!.Country)
      .Include(z=>z.Position)
      .Include(p => p.TeamCategory)
      .Where(x => x.Id == playerId);
  }
}
