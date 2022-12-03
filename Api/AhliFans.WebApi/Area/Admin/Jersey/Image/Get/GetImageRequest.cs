using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Jersey.Image;

public record GetImageRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Jersey/Image/{{JerseyId}}";
  public int JerseyId { get; set; }
}
