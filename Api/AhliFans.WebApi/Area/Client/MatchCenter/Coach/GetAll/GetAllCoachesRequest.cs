using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.MatchCenter.Coach.GetAll;

public record GetAllCoachesRequest
{
  public const string Route = $"{nameof(Areas.Client)}/MatchCenter/Coaches";
  public string Lang { get; set; } = Languages.Ar;
}
