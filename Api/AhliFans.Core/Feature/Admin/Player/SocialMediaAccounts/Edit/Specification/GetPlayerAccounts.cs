using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.Edit.Specification;

public sealed class GetPlayerAccounts : Specification<SocialMediaAccount>
{
  public GetPlayerAccounts(int playerId)
  {
    Query
      .Where(x => x.PlayerId == playerId);
  }
}
