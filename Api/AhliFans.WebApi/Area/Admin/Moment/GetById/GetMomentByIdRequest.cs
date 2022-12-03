using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Admin.Moment.GetById;

public record GetMomentByIdRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Moment";
  public string Lang { get; set; } = Languages.Ar;
  public int MomentId { get; set; }
}
