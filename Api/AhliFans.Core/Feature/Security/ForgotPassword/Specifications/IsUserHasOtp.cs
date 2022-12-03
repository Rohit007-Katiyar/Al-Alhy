using AhliFans.Core.Feature.Security.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Security.ForgotPassword.Specifications;

public sealed class IsUserHasOtp : Specification<UserOtp>, ISingleResultSpecification
{
  public IsUserHasOtp(Guid userId)
  {
    Query
      .Where(x => x.UserId == userId);
  }
}
