using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Account.LinkSocialMedia.LinkGmail;

public record LinkGmailRequest(string Email)
{
  public const string Route = $"{nameof(Areas.Client)}/Link/Gmail";

}
