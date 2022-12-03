using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Player.Add.Specification;

public sealed class IsPlayerNumberExist : Specification<Entities.Player>
{
  public IsPlayerNumberExist(int? playerNumber)
  {
    Query
      .Where(x => x.Number == playerNumber);
  }
}
