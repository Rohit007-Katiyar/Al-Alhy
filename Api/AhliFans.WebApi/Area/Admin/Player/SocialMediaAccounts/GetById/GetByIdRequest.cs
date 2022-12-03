using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Player.SocialMediaAccounts.GetById;

public record GetByIdRequest(int AccountId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Player/Account";
}
