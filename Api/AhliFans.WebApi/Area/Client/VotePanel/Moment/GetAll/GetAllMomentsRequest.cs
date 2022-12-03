using AhliFans.Core.Feature.Enums;
using AhliFans.Core.Feature.Localization;
using AhliFans.Core.Feature.Security.Enums;

namespace AhliFans.WebApi.Area.Client.VotePanel.Moment.GetAll;

public record GetAllMomentsRequest
{
  public const string Route = $"{nameof(Areas.Client)}/Moments";
  public int PageIndex { get; set; } = 1;
  public int PageSize { get; set; } = 10;
  public MomentVoteTypes MomentType { get; set; }
  public string Lang { get; set; } = Languages.Ar;
}
