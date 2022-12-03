using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Account.GmailLogin;

public record GmailLoginRequest(string Email,string UserName)
{
  public const string Route = $"{nameof(Areas.Client)}/GmailLogin";
}
