using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Location.Countries.Specifications;

public sealed class GetCountries : Specification<Country>
{
  public GetCountries(string? name)
  {
    if (!string.IsNullOrEmpty(name))
    {
      Query
        .Where(country => country.Name.Contains(name) || country.NameAr.Contains(name));
    }
  }
}
