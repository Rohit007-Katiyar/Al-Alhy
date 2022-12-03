using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.MediaPhoto.Image.Get;

public class GetMediaPhotoImageRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/MediaPhoto/Image/{{PhotoId}}";
  public int PhotoId { get; set; }
}
