using AhliFans.Core.Feature.Enums;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.MatchCenter.GetAll;

public record GetAllMatchesRequest
{
  public const string Route = $"{nameof(Areas.Client)}/MatchCenter/Matches";
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public MatchTypes MatchType { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
