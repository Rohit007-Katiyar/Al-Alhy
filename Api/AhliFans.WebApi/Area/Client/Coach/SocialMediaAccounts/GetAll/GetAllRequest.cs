using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Coach.SocialMediaAccounts.GetAll;

public record GetAllRequest(int CoachId)
{
  public const string Route = $"{nameof(Areas.Client)}/Coach/Accounts";
}
