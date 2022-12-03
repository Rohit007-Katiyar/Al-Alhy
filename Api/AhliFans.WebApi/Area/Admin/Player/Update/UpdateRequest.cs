using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Player.Update;

public record UpdateRequest(string? FaceBookAccount, string? InstaAccount, string? TwitterAccount)
{
  public const string Route = $"{nameof(Areas.Admin)}/Player";
  public int PlayerId { get; set; }
  public int? PositionId { get; set; }
  public int? Number { get; set; }
  public string? Name { get; set; }
  public string? NameAr { get; set; }
  public DateTime? BirthDate { get; set; }
  public DateTime? DateSigned { get; set; }
  public int? Height { get; set; }
  public int? Weight { get; set; }
  public int? CityOfBirth { get; set; }
  public string? Biography { get; set; }
  public string? BiographyAr { get; set; }

  public int? TeamCategoryId { get; set; }
}
