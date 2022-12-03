using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Coach.SocialMediaAccounts.GetAll.Specification;

public sealed class GetAccountsOfCoach : Specification<SocialMediaAccount>
{
  public GetAccountsOfCoach(int coachId)
  {
    Query
      .Where(x => x.CoachId == coachId && !x.IsDeleted);
  }
}
