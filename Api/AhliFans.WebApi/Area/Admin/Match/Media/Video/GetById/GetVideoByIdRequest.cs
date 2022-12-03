using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Match;

public record GetVideoByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Match/Media/Video/{{VideoId}}";
  public int VideoId { get; set; }
}
