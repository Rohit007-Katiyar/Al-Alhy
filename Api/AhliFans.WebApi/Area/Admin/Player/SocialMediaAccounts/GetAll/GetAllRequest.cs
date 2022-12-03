using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Player.SocialMediaAccounts.GetAll;

public record GetAllRequest(int PlayerId,bool IsDeleted)
{
  public const string Route = $"{nameof(Areas.Admin)}/Player/Accounts";
}
