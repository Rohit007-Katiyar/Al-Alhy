using AhliFans.Core.Feature.Entities;
using Microsoft.EntityFrameworkCore;

namespace AhliFans.Infrastructure.Seeds.MatchStatistics;

public static class MatchStatisticsSeeder
{
  public static void SeedMatchStatistics(this ModelBuilder modelBuilder)
  {
    var types = new List<MatchStatisticsType>()
        {
            new MatchStatisticsType
            {
                Id = 1,
                Name = "General",
                NameAr = "عام",
                IsEnabled = true,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsType
            {
                Id = 2,
                Name = "Attacking",
                NameAr = "هجوم",
                IsEnabled = false,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsType
            {
                Id = 3,
                Name = "Defending",
                NameAr = "دفاع",
                IsEnabled = false,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            }
        };
    modelBuilder.Entity<MatchStatisticsType>().HasData(types);
    modelBuilder.SeedCoefficients();
  }

  private static void SeedCoefficients(this ModelBuilder modelBuilder)
  {
    var generalCoefficients = new List<MatchStatisticsTypeCoefficient>()
        {
            new MatchStatisticsTypeCoefficient()
            {
                Id = 1,
                Name = "Possession",
                NameAr = "استحواذ",
                IsPercentage = true,
                MatchStatisticsTypeId = 1,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsTypeCoefficient()
            {
                Id = 2,
                Name = "Shots On Target",
                NameAr = "تسديدات علي المرمي",
                IsPercentage = false,
                MatchStatisticsTypeId = 1,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsTypeCoefficient()
            {
                Id = 3,
                Name = "Passes",
                NameAr = "تمريرات",
                IsPercentage = false,
                MatchStatisticsTypeId = 1,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsTypeCoefficient()
            {
                Id = 4,
                Name = "Corners",
                NameAr = "ركنيات",
                IsPercentage = false,
                MatchStatisticsTypeId = 1,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsTypeCoefficient()
            {
                Id = 5,
                Name = "Free Kicks",
                NameAr = "ضربات حرة",
                IsPercentage = false,
                MatchStatisticsTypeId = 1,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            }
        };

    var attackingCoefficients = new List<MatchStatisticsTypeCoefficient>()
        {
            new MatchStatisticsTypeCoefficient()
            {
                Id = 6,
                Name = "Penalties",
                NameAr = "ضربات الجزاء",
                IsPercentage = false,
                MatchStatisticsTypeId = 2,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsTypeCoefficient()
            {
                Id = 7,
                Name = "Pass Accuracy",
                NameAr = "دقة التمريرات",
                IsPercentage = true,
                MatchStatisticsTypeId = 2,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsTypeCoefficient()
            {
                Id = 8,
                Name = "Chances Created",
                NameAr = "اتاحة فرص",
                IsPercentage = false,
                MatchStatisticsTypeId = 2,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsTypeCoefficient()
            {
                Id = 9,
                Name = "Crosses",
                NameAr = "تقاطعات",
                IsPercentage = false,
                MatchStatisticsTypeId = 2,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsTypeCoefficient()
            {
                Id = 10,
                Name = "Crosses Success",
                NameAr = "تقاطعات ناجحة",
                IsPercentage = true,
                MatchStatisticsTypeId = 2,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            }
        };

    var defendingCoefficients = new List<MatchStatisticsTypeCoefficient>()
        {
            new MatchStatisticsTypeCoefficient()
            {
                Id = 11,
                Name = "Tackles Made",
                NameAr = "تدخلات مصنوعة",
                IsPercentage = false,
                MatchStatisticsTypeId = 3,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsTypeCoefficient()
            {
                Id = 12,
                Name = "Interceptions",
                NameAr = "اعتراضات",
                IsPercentage = false,
                MatchStatisticsTypeId = 3,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsTypeCoefficient()
            {
                Id = 13,
                Name = "Blocked sheets",
                NameAr = "تصديات",
                IsPercentage = false,
                MatchStatisticsTypeId = 3,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsTypeCoefficient()
            {
                Id = 14,
                Name = "Clearances",
                NameAr = "تخليص",
                IsPercentage = false,
                MatchStatisticsTypeId = 3,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            },
            new MatchStatisticsTypeCoefficient()
            {
                Id = 15,
                Name = "Goalkeeper Saves",
                NameAr = "انقاذات حارس المرمي",
                IsPercentage = false,
                MatchStatisticsTypeId = 3,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now
            }
        };

    var coefficients = generalCoefficients.Concat(attackingCoefficients).Concat(defendingCoefficients);
    modelBuilder.Entity<MatchStatisticsTypeCoefficient>().HasData(coefficients);
  }
}