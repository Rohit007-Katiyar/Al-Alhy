using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Match;

public record GetImageByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Match/Media/Image/{{ImageId}}";
  public int ImageId { get; set; }
}
