using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Account.SocialMediaRegistration;

public record RegistrationRequest(string FullName, string? Email, 
  string PhoneNumber, DateTime? BirthDate, int Country, int City, Gender? Gender = Gender.Male)
{
  public const string Route = $"{nameof(Areas.Client)}/Account/SocialMediaRegistration";

}
