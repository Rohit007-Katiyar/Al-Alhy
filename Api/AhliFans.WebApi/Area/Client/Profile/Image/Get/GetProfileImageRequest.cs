using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Profile;

public record GetProfileImageRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Profile/Image";
}
