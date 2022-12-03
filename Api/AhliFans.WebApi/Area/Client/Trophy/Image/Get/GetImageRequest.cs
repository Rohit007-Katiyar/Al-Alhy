using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.Trophy;

public record GetImageRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Trophy/Image/{{TrophyId}}";
  public int TrophyId { get; set; }
}
