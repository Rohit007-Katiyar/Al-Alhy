using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Client.Admin.Player.SocialMediaAccounts.GetAll;

public record GetAllAccountsRequest(int PlayerId)
{
  public const string Route = $"{nameof(Areas.Client)}/Player/Accounts";
}
