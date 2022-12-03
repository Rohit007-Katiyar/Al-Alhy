using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Coach.SocialMediaAccounts.ChangeStatus;

public record ChangeAccountStatusRequest(int AccountId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Account";
}
