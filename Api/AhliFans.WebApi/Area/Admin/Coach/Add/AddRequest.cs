using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Coach;

public record AddRequest(string? FaceBookAccount, string? InstaAccount, string? TwitterAccount)
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach";
  public int CityId { get; set; }
  public int CountryId { get; set; }
  public int TitleId { get; set; }
  public string FirstName { get; set; } = null!;
  public string FirstNameAr { get; set; } = null!;
  public string LastName { get; set; } = null!;
  public string LastNameAr { get; set; } = null!;
  public DateTime BirthDate { get; set; }
  public DateTime DateSigned { get; set; }
  public string Biography { get; set; } = null!;
  public string BiographyAr { get; set; } = null!;
  public IFormFile? Pic { get; set; }
  public bool IsCurrent { get; set; }
  public int TeamCategoryId { get; set; }
}
