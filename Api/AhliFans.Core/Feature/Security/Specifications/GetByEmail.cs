using AhliFans.Core.Feature.Security.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Security.Specifications;
public sealed class GetByEmail<T> : Specification<T>, ISingleResultSpecification where T : User
{
  public GetByEmail(string email)
  {
    Query.
      Where(user => user.Email == email);
  }
}
