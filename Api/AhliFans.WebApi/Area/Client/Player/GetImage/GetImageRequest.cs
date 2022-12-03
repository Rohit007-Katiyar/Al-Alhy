using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Player;

public record GetImageRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Player/Image/{{PlayerId}}";
  public int PlayerId { get; set; }
}
