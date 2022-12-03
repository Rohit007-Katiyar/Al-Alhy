#nullable disable
using AhliFans.Core.Feature.Security.Enums;
using JetBrains.Annotations;

namespace AhliFans.WebApi.Area.Admin.Coach;

public record UpdateRequest([CanBeNull] string FaceBookAccount, [CanBeNull] string InstaAccount, [CanBeNull] string TwitterAccount)
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach";
  public int CoachId { get; set; }
  public int NationalityId { get; set; }
  public int CountryId { get; set; }
  public int CityId { get; set; }
  public int TitleId { get; set; }
  public string FirstName { get; set; }
  public string FirstNameAr { get; set; }
  public string LastName { get; set; }
  public string LastNameAr { get; set; }
  public DateTime? BirthDate { get; set; }
  public DateTime? DateSigned { get; set; }
  public string Biography { get; set; }
  public string BiographyAr { get; set; }
  public bool IsCurrent { get; set; }

  public int? TeamCategoryId { get; set; }
}
