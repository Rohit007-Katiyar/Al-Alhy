using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using JetBrains.Annotations;

namespace AhliFans.WebApi.Area.Admin.MediaPhoto.GetAll;

public class GetAllPhotoRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/MediaPhotos";
  public string? SearchWord { get; set; }
  public string Lang { get; set; } = Languages.Ar;
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public bool IsDeleted { get; set; }
}
