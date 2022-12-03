using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Player.Image;

public record GetImageRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Player/Image/{{PlayerId}}";
  public int PlayerId { get; set; }
}
