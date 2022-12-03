using AhliFans.Core.Feature.Entities;
using Ardalis.Specification;

namespace AhliFans.Core.Feature.Admin.Location.Cities.Specifications;

public sealed class GetAllCities : Specification<City>
{
  public GetAllCities(int countryId,string? name)
  {
    if (true)
    {
      Query
        .Where(x => x.CountryId == countryId);
    }

    if (!string.IsNullOrEmpty(name))
    {
      Query
        .Where(x => x.NameAr.Contains(name) || x.Name.Contains(name));
    }
  }
}
