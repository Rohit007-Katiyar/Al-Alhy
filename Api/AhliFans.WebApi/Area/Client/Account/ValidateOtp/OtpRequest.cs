using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Account.ValidateOtp;

public record OtpRequest(string PhoneNumber,string Code)
{
  public const string Route = $"{nameof(Areas.Client)}/Account/ValidateOtp";
}
