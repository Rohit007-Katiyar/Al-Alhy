using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Account.ResendOtp;

public record ResendOtpRequest(string PhoneNumber)
{
  public const string Route = $"{nameof(Areas.Client)}/ResendOtp";
}
