using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Account.SignUp;

public record SignUpRequest(string FullName, string? Email, string Password, string ConfirmPassword, string PhoneNumber, 
   DateTime? BirthDate,int Country,int City,Gender? Gender = Gender.Male)
{
  public const string Route = $"{nameof(Areas.Client)}/Account/SignUp";

}
