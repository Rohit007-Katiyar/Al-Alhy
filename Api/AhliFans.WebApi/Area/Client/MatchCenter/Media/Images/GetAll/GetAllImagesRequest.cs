using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Client.MatchCenter;

public record GetAllImagesRequest
{
  public const string Route = $"{nameof(Areas.CompareTo)}/Match/Media/Images";
  [FromHeader]public int MatchId { get; set; }
}
