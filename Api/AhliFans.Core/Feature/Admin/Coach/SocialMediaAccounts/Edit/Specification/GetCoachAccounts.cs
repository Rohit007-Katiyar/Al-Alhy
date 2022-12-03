using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Coach.SocialMediaAccounts.Edit.Specification;

public sealed class GetCoachAccounts : Specification<SocialMediaAccount>
{
  public GetCoachAccounts(int coachId)
  {
    Query
      .Where(x => x.CoachId == coachId);
  }
}
