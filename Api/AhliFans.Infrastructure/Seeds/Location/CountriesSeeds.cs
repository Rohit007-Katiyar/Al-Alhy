using AhliFans.Core.Feature.Entities;
using AhliFans.Infrastructure.Data;
using AhliFans.SharedKernel.APIServices.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AhliFans.Infrastructure.Seeds.Location;

public class CountriesSeeds
{
  public static async Task Initialize(IServiceProvider serviceProvider)
  {
    await using var dbContext = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null);

    if (dbContext.Countries.Count() <= 1)
    {
      var names = Countries.GetAllCountries();

      List<Country> countries = new List<Country>();
      if (names.Result != null)
      {
        countries.AddRange(names.Result!.Select(name => new Country() { NameAr = name.translations.fa, Name = name.name}).Where(x=>!x.Name.Contains("Egypt")||!x.NameAr.Contains("مصر")));
      }

      dbContext.Countries.AddRange(countries);
      SeedData(dbContext);
    }

  }
  public static void SeedData(AppDbContext dbContext)
  {
    dbContext.SaveChanges();
  }
}
