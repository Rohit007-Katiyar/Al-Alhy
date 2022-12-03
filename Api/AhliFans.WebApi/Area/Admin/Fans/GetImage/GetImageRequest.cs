using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Fans;

public record GetImageRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Fan/Profile/{{FanId}}";
  public Guid FanId { get; set; }
}
