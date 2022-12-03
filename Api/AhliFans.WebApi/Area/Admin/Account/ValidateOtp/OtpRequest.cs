using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Account;

public record OtpRequest(string PhoneNumber,string Code)
{
  public const string Route = $"{nameof(Areas.Admin)}/Account/ValidateOtp";
}
