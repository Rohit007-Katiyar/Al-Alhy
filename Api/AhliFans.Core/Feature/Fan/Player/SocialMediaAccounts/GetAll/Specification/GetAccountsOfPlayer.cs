using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Player.SocialMediaAccounts.GetAll.Specification;

public sealed class GetAccountsOfPlayer : Specification<SocialMediaAccount>
{
  public GetAccountsOfPlayer(int playerId)
  {
    Query
      .Where(x => x.PlayerId == playerId && !x.IsDeleted);
  }
}
