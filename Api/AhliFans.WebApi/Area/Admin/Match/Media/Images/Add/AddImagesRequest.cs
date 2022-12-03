using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Match.Media.Images;

public record AddImagesRequest(List<IFormFile> Images,int MatchId)
{
  public const string Route = $"{nameof(Areas.Admin)}/Match/Media/Images";
}
