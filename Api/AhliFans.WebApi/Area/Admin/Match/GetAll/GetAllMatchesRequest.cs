using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;
using MatchType = AhliFans.Core.Feature.Enums.MatchTypes;

namespace AhliFans.WebApi.Area.Admin.Match;

public record GetAllMatchesRequest
{
  public const string Route = $"{nameof(Areas.Admin)}/Matches";

  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public int LeagueId { get; set; }
  public int LeagueDataId { get; set; }
  public MatchType MatchTypes { get; set; }
  public string Lang { get; set; } = Languages.Ar;
  public bool IsDeleted { get; set; }
  public bool? IsAvailable { get; set; }
}
