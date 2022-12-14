using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Match.Media.Images.Add.Specifications;

public sealed class IsMatchExist : Specification<Entities.Match>
{
  public IsMatchExist(int matchId)
  {
    Query
      .Where(x => x.Id == matchId);
  }
}
