using AhliFans.Core.Feature.Security.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Security.Specifications;
public sealed class GetByPhoneNumberWithOtp<T> : Specification<T>, ISingleResultSpecification where T : User
{
  public GetByPhoneNumberWithOtp(string phoneNumber)
  {
    Query
      .Include(x=>x.Otp)
      .Where(user => user.PhoneNumber == phoneNumber);
  }
}
