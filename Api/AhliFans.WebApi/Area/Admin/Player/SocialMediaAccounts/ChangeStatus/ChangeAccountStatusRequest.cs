using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Player.SocialMediaAccounts.ChangeStatus;

public record ChangeAccountStatusRequest(int AccountId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Player/Account";
}
