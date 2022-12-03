
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Account;

public record TokenRequest(string EmailOrPhoneNumber, string Password)
{
  public const string Route = $"{nameof(Areas.Admin)}/Account/token";
}
