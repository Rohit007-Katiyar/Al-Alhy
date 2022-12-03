using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Client.MatchCenter.media.Videos;

public record GetAllVideoRequest
{
  public const string Route = $"{nameof(Areas.CompareTo)}/Match/Media/Videos";
  [FromHeader]public int MatchId { get; set; }
}
