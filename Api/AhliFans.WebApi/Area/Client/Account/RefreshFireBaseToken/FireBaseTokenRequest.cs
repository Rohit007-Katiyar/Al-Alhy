using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Account.RefreshFireBaseToken;

public record FireBaseTokenRequest(string Token)
{
  public const string Route = $"{nameof(Areas.Client)}/FireBase/Token";
}
