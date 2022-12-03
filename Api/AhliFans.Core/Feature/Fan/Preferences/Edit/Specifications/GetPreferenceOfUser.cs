using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Fan.Preferences.Edit.Specifications;

public sealed class GetPreferenceOfUser : Specification<FanPreference>, ISingleResultSpecification
{
      public GetPreferenceOfUser(Guid userId)
      {
        Query
          .Where(x => x.FanId == userId);
      }
}

