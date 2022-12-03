using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AhliFans.WebApi.Area.Admin.MediaPhoto.GetById;

public class GetPhotoByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/MediaPhoto/{{PhotoId}}";
  public int PhotoId { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
