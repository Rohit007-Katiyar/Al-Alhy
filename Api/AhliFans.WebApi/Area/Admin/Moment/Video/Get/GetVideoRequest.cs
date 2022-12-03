using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Moment;

public record GetVideoRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Moment/Video/{{Momentd}}";
  public int MomentId { get; set; }
}
