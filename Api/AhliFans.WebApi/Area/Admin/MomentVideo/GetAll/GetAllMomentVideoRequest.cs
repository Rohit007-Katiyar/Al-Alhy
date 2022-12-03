using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.MomentVideo.GetAll;

public class GetAllMomentVideoRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/MomentVideos";
  public string? SearchWord { get; set; }
  public string Lang { get; set; } = Languages.Ar;
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public bool IsDeleted { get; set; }
}
