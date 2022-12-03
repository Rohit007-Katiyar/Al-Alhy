using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Coach.SocialMediaAccounts.GetAll;

public record GetAllRequest(int CoachId, bool IsDeleted)
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Accounts";
}
