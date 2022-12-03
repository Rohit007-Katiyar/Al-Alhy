using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Moment.GetAll;

public record GetAllMomentsRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Moments";
  public string Lang { get; set; } = Languages.Ar;
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public bool IsAvailable { get; set; }
}
