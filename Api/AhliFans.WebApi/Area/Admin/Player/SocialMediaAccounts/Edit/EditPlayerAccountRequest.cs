using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Player.SocialMediaAccounts.Edit;

public record EditPlayerAccountRequest(int PlayerId, string? FaceBookAccount, string? InstaAccount, string? TwitterAccount)
{
  public const string Route = $"{nameof(Areas.Admin)}/Player/Account";
}
