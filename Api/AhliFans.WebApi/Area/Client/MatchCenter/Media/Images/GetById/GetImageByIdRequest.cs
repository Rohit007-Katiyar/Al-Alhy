using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.MatchCenter;

public record GetImageByIdRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Match/Media/Image/{{ImageId}}";
  public int ImageId { get; set; }
}
