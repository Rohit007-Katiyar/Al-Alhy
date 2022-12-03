using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Coach.SocialMediaAccounts.Add;

public record AddAccountRequest(int CoachId, string? FaceBookAccount, string? InstaAccount, string? TwitterAccount)
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Account";
}
