using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.Match.Media.Images.GetAll;

public record GetAllImagesRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Match/Media/Images";
  [FromHeader]public int MatchId { get; set; }
}
