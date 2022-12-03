using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Trophy.Image;

public record GetImageRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Trophy/Image/{{TrophyId}}";
  public int TrophyId { get; set; }
}
