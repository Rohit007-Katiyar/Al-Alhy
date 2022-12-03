using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Account.FaceBookLogin;

public record FaceBookLoginRequest(string AccessToken)
{
  public const string Route = $"{nameof(Areas.Client)}/FbLogin";
}
