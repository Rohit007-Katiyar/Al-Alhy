using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Account;

public record ResendOtpRequest(string PhoneNumber)
{
  public const string Route = $"{nameof(Areas.Admin)}/ResendOtp";
}
