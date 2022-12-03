using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.MatchCenter.media.Videos;

public record GetVideoByIdRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Match/Media/Video/{{VideoId}}";
  public int VideoId { get; set; }
}
