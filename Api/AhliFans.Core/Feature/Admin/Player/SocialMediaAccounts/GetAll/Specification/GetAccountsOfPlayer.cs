using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Player.SocialMediaAccounts.GetAll.Specification;

public sealed class GetAccountsOfPlayer : Specification<SocialMediaAccount>
{
  public GetAccountsOfPlayer(int playerId, bool isDeleted)
  {
    Query
      .Where(x => x.PlayerId == playerId && x.IsDeleted == isDeleted && !string.IsNullOrEmpty(x.SocialMediaAccount1));
  }
}
