using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Account.Login;

public record LoginRequest (string EmailOrPhoneNumber, string Password)
{
  public const string Route = $"{nameof(Areas.Client)}/Account/Login";
}
