using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.GetAll.Specification;

public sealed class GetAccountsOfCoach : Specification<SocialMediaAccount>
{
  public GetAccountsOfCoach(int coachId, bool isDeleted)
  {
    Query
      .Where(x => x.CoachId == coachId && x.IsDeleted == isDeleted && !string.IsNullOrEmpty(x.SocialMediaAccount1));
  }
}
