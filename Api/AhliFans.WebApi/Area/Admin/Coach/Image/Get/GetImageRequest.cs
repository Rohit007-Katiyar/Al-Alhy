using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Coach.Image;

public record GetImageRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Coach/Image/{{CoachId}}";
  public int CoachId { get; set; }
}
