using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Account.LinkSocialMedia.LinkFaceBook;

public record LinkFaceBookRequest(string AccessToken)
{
  public const string Route = $"{nameof(Areas.Client)}/Link/FaceBook";
}
