using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Coach.SocialMediaAccounts.GetById;

public record GetByIdRequest(int AccountId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Account";
}
